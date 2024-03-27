module training5 // Assembly Automation

open System
open System.Runtime.InteropServices
open System.Collections
open System.Collections.Generic
open System.Drawing
open System.Diagnostics
open System.Reflection
open System.Text.RegularExpressions
open System.IO

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

open FSharp.Idioms.Literal
open FSharp.SolidWorks
open FSharp.Idioms
open Dir

let LESSONDIR =
    Path.Combine(TRAININGDIR, "Lesson05 - Assembly Automation")

let FILEDIR =
    Path.Combine(LESSONDIR, "Case Study\\Guitar Effect Pedal")

/// Do some validation before running routines....
let getSafeSelFace (swSelMgr:SelectionMgr) =
    let SelObjType =
        swSelMgr
        |> SelectionMgrUtils.getSelectedObjectType3 1 SelectionMgrUtils.Mark.All

    match SelObjType with
    | swSelectType_e.swSelFACES ->
        //Get the selected face, ignore marks
        let swSelFace =
            swSelMgr
            |> SelectionMgrUtils.getSelectedObject6 1 SelectionMgrUtils.Mark.All
            :?> Face2

        //Create a Safe Entity so we can select it when the face
        //becomes invalid
        let swSafeSelFace = (swSelFace :?> Entity).GetSafeEntity()

        swSafeSelFace
    | _ ->
        failwith "You did not select a face."

//We need to find out where the target component "lives" in the assembly
//There are 2 types of space in an assembly doc. Assembly Space, and Component space
//Think of the assembly space as the town where you live.
//Think of the Component space as the Address of your house in that town
let EstablishTargetComponentsTransform(swSafeSelFace: Entity) =
    let swComponent =
        swSafeSelFace.GetComponent() :?> Component2 //Set the component to the entity objects owning component

    //Set the forms swCompTransform member to store this transform for later use.
    let swCompTransform = swComponent.Transform2
    swCompTransform

// this sub routine will open the component that you want to add to the assembly
let OpenComponentModelToAddToAssembly (strCompModelname: string) (assemblyTitle: string) (swApp: ISldWorks) =
    // We open the document invisible to the user *must set this back to true when program ends, or else any
    // parts that the user opens in the UI will be invisible! - See the finalize method
    //swApp
    //|> SldWorksUtils.documentVisible false swDocumentTypes_e.swDocPART

    //Open the component. This must be open or the AddComponent method will fail
    {
        FileName = strCompModelname
        Type = swDocumentTypes_e.swDocPART
        Options = swOpenDocOptions_e.swOpenDocOptions_Silent
        Configuration = ""
    }.openDoc(swApp)
    |> ignore

    //swApp
    //|> SldWorksUtils.documentVisible true swDocumentTypes_e.swDocPART

    //Reactivate the assembly because that is where the rest of the work is done
    let swModel =
        swApp
        |> SldWorksUtils.activateDoc3
            assemblyTitle
            false
            swRebuildOnActivation_e.swDontRebuildActiveDoc

    let swAssy = swModel :?> IAssemblyDoc
    swAssy

//These next several routines set up Collections of geometry gathered from the selected face
//this first routine traverses all the loops on the selected face.
//if the loop is an inner loop then it gets an array of all of the edges belonging to that loop
//then one by one it checks each edge to see if it is a complete circle. if it is then it adds the
//Edge object and it's corresponding curve to their appropriate collections.
let EstablishCircularCurveAndEdgeCollections (swSelFace: Face2) =
    let swLoops =
        swSelFace
        |> Face2Utils.getLoopSeq

    //if it's an inner loop, get the array of edges belonging to the loop
    let swEdges =
        swLoops
        |> Seq.filter(fun swLoop -> swLoop.IsOuter() |> not)
        |> Seq.collect(fun swLoop ->
            swLoop.GetEdges()
            :?> obj[]
            |> Array.map (fun obj -> obj :?> Edge)
        )

    //Set the current curve object
    //if the curve is a complete circle then ...
    let circles =
        swEdges
        |> Seq.map(fun swEdge ->
            
            swEdge.GetCurve() :?> Curve
            |> Pair.ofApp swEdge
        )
        |> Seq.filter(fun (swEdge,swCurve) -> swCurve.IsCircle())
        |> Seq.filter(fun (swEdge,swCurve) ->
            let dStart, dEnd, bIsClosed, bIsPeriodic =
                swCurve
                |> CurveUtils.getEndParams
            bIsClosed
        )
    circles

//not only do we need all of the edges and curves, but we need the cylindrical faces
//This will help us establish the concentric mate needed to tie the control button concentrically to the hole in the chassis
//For every edge in the EdgeCollection, we want to get the cylindrical face one one side of the edge.
//Use the method GetTwoAdjacentFaces2 to get a pointer to each face that shares the edge.
//One of these will be the cylindrical face needed for mating
let EstablishCylindricalFaceCollection (circularEdgeCollection: Edge[]) =
    circularEdgeCollection
    |> Array.map(fun (circularEdge: Edge) ->
        circularEdge.GetTwoAdjacentFaces2() :?> obj[]
        |> Array.map(fun swFace -> swFace :?> Face2)
        |> Array.find(fun swFace -> 
            let surface = swFace.GetSurface() :?> Surface
            surface.IsCylinder()
        )
    )
    |> Array.map(fun swFace -> (swFace :?> Entity).GetSafeEntity())

//Now we need to establish a collection of points needed for adding the new components in the correct
//location in the assembly
//Remember that the points that we retrieve from the center location of the cylindrical face / circular edges are not in assembly coordinates.
//Whatever the center position is needs to by multiplied by the target component's transform.
//if we do not do this the new component is put in at the assembly space instead of where the component actually lives in the assembly
//When I build the collection of center points, I use the MathPoint object from the MathUtility class.
//this object has a very convenient method to multiply the point location by the transform of the target component in the assembly.
//if we didn't have this method, we'd need to work all the math out programatically
//the math classes are your friend! :)
let EstablishPointsCollection (circularCurveCollection:Curve[]) (swCompTransform:MathTransform) (swApp: ISldWorks) =
    let getPoint (circularCurve:Curve) =
        let circleParams =
            circularCurve.CircleParams :?> float[] //Fill the Circle Params array with the Circle information from the curve.

        let arrayData =                                  //Create a 3 element array to pass into the constructor of the math point object
            circleParams.[0..2]

        let swMathUtility =
            swApp
            |> SldWorksUtils.getMathUtility

        let swMathPoint =                       //use the center point locations to create a Solidworks MathPoint object
            //use the math point class to store these points
            swMathUtility
            |> MathUtilityUtils.createPoint(arrayData)         //Create the mathpoint using the location data
            //:?> MathPoint

        let swMathPoint =
            swMathPoint
            |> MathPointUtils.multiplyTransform(swCompTransform) //Now multiply the math point by the Target component//s transform.
            //:?> MathPoint
        swMathPoint
    [|
        for circularCurve in circularCurveCollection do //For every circular curve get it's center point and multiply by the transform and add it to the collection.
            getPoint circularCurve
    |]

//Now we are ready to add the new components to the assembly and automatically mate them.
//for every point in the point collection, we need to:

//1.) Add the component at that location
//2.) Add a coincident mate between the selected face on the target component, and the bottom face of the control knob (we use the top plane of the comp for that.)
//3.) Once that mate is completed, we create the concentric mate by selecting the cylindrical face from the safecylindricalface collection
//and the origin of the new component

let AddcomponentsToAssembly
    (swAssy: IAssemblyDoc)
    (swModel: IModelDoc2)
    (swSafeSelFace: IEntity)
    (assemblyName: string)
    (strCompFullPath: String)
    (safeCylindricalFaceCollection: Entity[])
    (pointCollection: MathPoint[])
    =
    //Add a coincident mate between the bottom face of the new component and the target face of the target component.....
    let selectMgr =
        swModel.SelectionManager :?> SelectionMgr

    safeCylindricalFaceCollection
    |> Array.zip pointCollection
    |> Array.iter(fun(pnt: MathPoint,safeCylindricalFace: Entity) ->
        // Get the coordinates of the transformed math points in the mathpoint collection.
        let pointData =
            pnt.ArrayData :?> float[]

        // Add the control knob at that location.
        let swComponent: Component2 =
            {
                CompName = strCompFullPath
                ConfigOption = CurrentSelectedConfig
                MaybeUseConfigForPartReferences = None
                CompCenter = pointData.[0], pointData.[1], pointData.[2]
            }.AddComponent5 swAssy

        // Get the name and instance of the newly added component for selection
        let strCompName = swComponent.Name2
        let SelData = selectMgr.CreateSelectData()

        SelData.Mark <- 1 // Mark用于设置用途
        swModel.ClearSelection2 true

        swSafeSelFace.Select4(true, SelData)
        |> ignore

        swModel
        |> ModelDoc2Utils.selectByID2
            $"Top@{strCompName}@{assemblyName}"
            "PLANE"
            (0., 0., 0.)
            true
            1
            swSelectOption_e.swSelectOptionDefault //Select the top plane of the newly added control knob.
        |> ignore

        //Add a coincident mate.
        {
            MateType = MateCOINCIDENT
            MateAlign = swMateAlign_e.swMateAlignCLOSEST
            ForPositioningOnly = false
        }.AddMate5 swAssy
        |> ignore

        swModel.ClearSelection2(true)

        safeCylindricalFace.Select4(true, SelData)
        |> ignore

        swModel
        |> ModelDoc2Utils.selectByID2
            $"Point1@Origin@{strCompName}@{assemblyName}"
            "EXTSKETCHPOINT"
            (0, 0, 0)
            true
            1
            swSelectOption_e.swSelectOptionDefault //now select the origin of the new control knob
        |> ignore

        //Add the concentric mate!
        {
            MateType = MateCONCENTRIC false
            MateAlign = swMateAlign_e.swMateAlignCLOSEST
            ForPositioningOnly = false
            //LockRotation = false
        }.AddMate5 swAssy
        |> ignore

        swModel.ClearSelection2(true)
    )

/// cmdAddComponentsAndMate_Click
let AddComponentsAndMate (swApp: ISldWorks) =
    // Guitar Effect Pedal.SLDASM
    let swModel = swApp.ActiveDoc :?> IModelDoc2
    try
    let AssemblyTitle = swModel.GetTitle()
    let assemblyName = Path.GetFileNameWithoutExtension(AssemblyTitle)
    let swSelMgr = swModel.SelectionManager :?> SelectionMgr
    let swSafeSelFace = getSafeSelFace swSelMgr
    if swSafeSelFace.IsSafe then 
        ()
    else 
        swApp.SendMsgToUser "swSafeSelFace is unsafe."

    let swCompTransform = EstablishTargetComponentsTransform swSafeSelFace

    let strCompFullPath = "control knob.SLDPRT"
    let strCompModelname = Path.Combine(FILEDIR, strCompFullPath)
    let swAssy = OpenComponentModelToAddToAssembly strCompModelname AssemblyTitle swApp
    let CircularEdgeCollection, CircularCurveCollection =
        EstablishCircularCurveAndEdgeCollections (swSafeSelFace :?> Face2)
        |> Array.ofSeq
        |> Array.unzip

    let safeCylindricalFaceCollection =
        CircularEdgeCollection
        |> EstablishCylindricalFaceCollection

    let pointCollection =
        swApp
        |> EstablishPointsCollection CircularCurveCollection swCompTransform

    AddcomponentsToAssembly
        swAssy
        swModel
        swSafeSelFace
        assemblyName
        strCompFullPath
        safeCylindricalFaceCollection
        pointCollection

    swApp.SendMsgToUser "success"
    with ex ->
        swApp.SendMsgToUser $"{ex.Message}"

            ////命令
            //cmds.add(
            //    hintOrTip: "第5章",
            //    callbackFunction: nameof(this.Training5_AddComponentsAndMate)
            //    );

        //public void Training5_AddComponentsAndMate()
        //{
        //    training5.AddComponentsAndMate(this.iSwApp);
        //}

module training5

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

open FSharp.Literals.Literal
open FSharp.SolidWorks
open FSharp.Idioms

let TRAININGDIR = @"C:\SolidWorks Training Files\API Fundamentals\"
let LESSONDIR = TRAININGDIR + @"Lesson05 - Assembly Automation\"
let FILEDIR = LESSONDIR + @"Case Study\Guitar Effect Pedal\"
  
let testSelectFace (swApp: ISldWorks) =
    let swModel = 
        swApp.ActiveDoc
        |> unbox<ModelDoc2>

    let swSelMgr = swModel.SelectionManager :?> SelectionMgr
  
    //Do some validation before running routines....
    let SelObjType = 
        swSelMgr
        |> SelectionMgrUtils.getSelectedObjectType3 1 SelectionMgrUtils.Mark.All

    match SelObjType with
    | swSelectType_e.swSelFACES ->
        //Get the selected face, ignore marks
        let swSelFace =
            swSelMgr
            |> SelectionMgrUtils.getSelectedObject6 1 SelectionMgrUtils.Mark.All
            |> unbox<Entity>
        //Create a Safe Entity so we can select it when the face
        //becomes invalid
        let swSafeSelFace = swSelFace.GetSafeEntity()
        swApp.SendMsgToUser $"{swSafeSelFace}"
    | _ ->
        swApp.SendMsgToUser "You did not select a face."

let cmdAddComponentsAndMate_Click(swApp: ISldWorks) =
  let swModel = 
    swApp.ActiveDoc
    |> unbox<ModelDoc2>

  let swSelMgr = swModel.SelectionManager :?> SelectionMgr
  
  ()

//We need to find out where the target component "lives" in the assembly
//There are 2 types of space in an assembly doc. Assembly Space, and Component space
//Think of the assembly space as the town where you live.
//Think of the Component space as the Address of your house in that town
let EstablishTargetComponentsTransform(swSafeSelFace:Entity) =
    let swComponent = 
        swSafeSelFace.GetComponent() //Set the component to the entity objects owning component
        |> unbox<Component2>

    //Set the forms swCompTransform member to store this transform for later use.
    let swCompTransform = swComponent.Transform2
    swCompTransform

// this sub routine will open the component that you want to add to the assembly
let OpenComponentModelToAddToAssembly (assemblyTitle:string) (strCompModelname : String) (swApp: ISldWorks) =
    // We open the document invisible to the user *must set this back to true when program ends, or else any
    // parts that the user opens in the UI will be invisible! - See the finalize method
    swApp
    |> SldWorksUtils.documentVisible false swDocumentTypes_e.swDocPART
                                                
    //Open the component. This must be open or the AddComponent method will fail
    swApp
    |> SldWorksUtils.openDoc6 
        strCompModelname 
        swDocumentTypes_e.swDocPART 
        swOpenDocOptions_e.swOpenDocOptions_Silent ""  
    |> ignore

    swApp
    |> SldWorksUtils.documentVisible true swDocumentTypes_e.swDocPART

    let swModel = 
        swApp
        |> SldWorksUtils.activateDoc3 assemblyTitle false swRebuildOnActivation_e.swDontRebuildActiveDoc    //Reactivate the assembly because that is where the rest of the work is done
    let swAssy = swModel :?> IAssemblyDoc

    swAssy

//These next several routines set up Collections of geometry gathered from the selected face
//this first routine traverses all the loops on the selected face.
//if the loop is an inner loop then it gets an array of all of the edges belonging to that loop
//then one by one it checks each edge to see if it is a complete circle. if it is then it adds the
//Edge object and it's corresponding curve to their appropriate collections.
let EstablishCircularCurveAndEdgeCollections(swSelFace:Face2) =
    let swLoops = 
        swSelFace
        |> Face2Utils.getLoopSeq
        |> Seq.filter(fun swLoop -> swLoop.IsOuter() |> not)

    let swEdges =
        swLoops
        |> Seq.collect(fun swLoop ->
            swLoop.GetEdges() //if it's an inner loop, get the array of edges belonging to the loop
            |> unbox<Edge[]>
        )

    swEdges
    |> Seq.map(fun swEdge ->
        //let swCurve = 
            swEdge.GetCurve() //Set the current curve object
            |> unbox<Curve>
            |> Pair.ofApp swEdge
        //swEdge,swCurve
    )
    |> Seq.filter(fun (swEdge,swCurve) -> swCurve.IsCircle())
    |> Seq.filter(fun (swEdge,swCurve) ->
        let dStart, dEnd, bIsClosed, bIsPeriodic =
            swCurve
            |> CurveUtils.getEndParams
        bIsClosed //if the curve is a complete circle then ...
    )

//not only do we need all of the edges and curves, but we need the cylindrical faces
//This will help us establish the concentric mate needed to tie the control button concentrically to the hole in the chassis
//For every edge in the EdgeCollection, we want to get the cylindrical face one one side of the edge.
//Use the method GetTwoAdjacentFaces2 to get a pointer to each face that shares the edge.
//One of these will be the cylindrical face needed for mating
let EstablishCylindricalFaceCollection(circularEdgeCollection:Edge[]) =
    let getSafeEntity (circularEdge:Edge) =
        let swFaces = 
            circularEdge
            |> EdgeUtils.getTwoAdjacentFaces2 //use this to get the 2 faces sharing the Circular edge

        //数组一定是2个元素
        let swSurfaces =
            swFaces
            |> Array.map(fun swFace ->
                swFace
                |> Face2Utils.getSurface
            )

        //When the cylindrical Face is found....
        swSurfaces
        |> Array.find(fun swSurface -> swSurface.IsCylinder())
        :?> Entity
        |> fun e -> e.GetSafeEntity()

    circularEdgeCollection
    |> Array.map getSafeEntity


//Now we need to establish a collection of points needed for adding the new components in the correct
//location in the assembly
//Remember that the points that we retrieve from the center location of the cylindrical face / circular edges are not in assembly coordinates.
//Whatever the center position is needs to by multiplied by the target component//s transform.
//if we do not do this the new component is put in at the assembly space instead of where the component actually lives in the assembly
//When I build the collection of center points, I use the MathPoint object from the MathUtility class.
//this object has a very convenient method to multiply the point location by the transform of the target component in the assembly.
//if we didn//t have this method, we//d need to work all the math out programatically
//the math classes are your friend! :)
let EstablishPointsCollection (circularCurveCollection:Curve[])(swCompTransform:MathTransform)(swApp: ISldWorks) =
    let getPoint (circularCurve:Curve) =
        let circleParams = 
            circularCurve.CircleParams //Fill the Circle Params array with the Circle information from the curve.
            |> unbox<float[]>

        let arrayData =                                  //Create a 3 element array to pass into the constructor of the math point object
            circleParams.[0..2]

        let swMathUtility = 
            swApp
            |> SldWorksUtils.getMathUtility

        let swMathPoint =                       //use the center point locations to create a Solidworks MathPoint object
            //use the math point class to store these points
            swMathUtility
            |> MathUtilityUtils.createPoint(arrayData)         //Create the mathpoint using the location data
            //|> unbox<MathPoint>

        let swMathPoint = 
            swMathPoint
            |> MathPointUtils.multiplyTransform(swCompTransform) //Now multiply the math point by the Target component//s transform.
            //|> unbox<MathPoint>
        swMathPoint
    [
        for circularCurve in circularCurveCollection do //For every circular curve get it's center point and multiply by the transform and add it to the collection.
            //PointCollection.Add swMathPoint    //Add it to the point collection for use in the mating routine.
            getPoint circularCurve
    ]

//Now we are ready to add the new components to the assembly and automatically mate them.
//for every point in the point collection, we need to:
  
//1.) Add the component at that location
//2.) Add a coincident mate between the selected face on the target component, and the bottom face of the control knob (we use the top plane of the comp for that.)
//3.) Once that mate is completed, we create the concentric mate by selecting the cylindrical face from the safecylindricalface collection
//and the origin of the new component

let AddcomponentsToAssembly (swAssy :AssemblyDoc) (swModel:ModelDoc2) 
    (swSafeSelFace:Entity)(safeCylindricalFaceCollection:Entity[]) (pointCollection:MathPoint[]) (assemblyName:string)
    (strCompFullPath : String) =

    //Add a coincident mate between the bottom face of the new component and the target face of the target component.....
    for j in 0..pointCollection.Length-1 do//For every location in the point collection ......
        let pnt:MathPoint = pointCollection.[j]
        let pointData = 
            pnt.ArrayData  //Get the coordinates of the transformed math points in the mathpoint collection.
            |> unbox<float[]>

        //Add the control knob at that location.
        let swComponent: Component2 =
            let xyz = pointData.[0], pointData.[1], pointData.[2]
            swAssy
            |> AssemblyDocUtils.addComponent5
                strCompFullPath
                swAddComponentConfigOptions_e.swAddComponentConfigOptions_CurrentSelectedConfig
                "" false "" xyz
                
        let strCompName = swComponent.Name2                   //Get the name and instance of the newly added component for selection
        let selectMgr = 
            swModel.SelectionManager
            :?>SelectionMgr
        let SelData = selectMgr.CreateSelectData()

        SelData.Mark <- 1 //Mark用于设置用途
        swModel.ClearSelection2 true
        swSafeSelFace.Select4(true, SelData)
        |> ignore

        swModel|>
        ModelDoc2Utils.selectByID2
            $"Top@{strCompName}@{assemblyName}" "PLANE"
            (0., 0., 0.) true 1 swSelectOption_e.swSelectOptionDefault //Select the top plane of the newly added control knob.
        |> ignore

        //Add a coincident mate.
        swAssy
        |> AssemblyDocUtils.addMate5
            swMateType_e.swMateCOINCIDENT
            swMateAlign_e.swMateAlignCLOSEST
            false 0 0 0 0 0 0 0 0 false false
            swMateWidthOptions_e.swMateWidth_Centered 
        |> ignore
        
        swModel.ClearSelection2(true)
        safeCylindricalFaceCollection.[j].Select4(true, SelData)
        |> ignore

        swModel
        |> ModelDoc2Utils.selectByID2
            $"Point1@Origin@{ strCompName }@{ assemblyName}"
            "EXTSKETCHPOINT"
            (0, 0, 0)
            true 1
            swSelectOption_e.swSelectOptionDefault //now select the origin of the new control knob
        |> ignore
        
        swAssy
        |> AssemblyDocUtils.addMate5
            swMateType_e.swMateCONCENTRIC
            swMateAlign_e.swMateAlignCLOSEST
            false 0 0 0 0 0 0 0 0 false false 
            swMateWidthOptions_e.swMateWidth_Centered //Add the concentric mate!
        |> ignore
        swModel.ClearSelection2(true)
      
  //For j = 1 To PointCollection.Count
  //Next j
  
  //*Question...   //What is the purpose of Entity.GetSafeEntity and the SafeCylindricalFaceCollection collection ????
  //*Answer...     //It seems that when we add a new component to the assembly, and the assembly is rebuilt..
                  //we lose the pointers to the faces that we had stored in the face collection.
                  //if we tried to call entity.Select4 on the swSelFace after a component is added to the assembly, we
                  //get an error from VB telling us that the
                  //object has disconnected from it//s client. That means that the pointer to the face is no longer valid.
                                      
                  //To fix this problem, we use the method Entity.GetSafeEntity. These pointers will not become invalid when
                  //a component is added to an assembly, and the assembly is regenerated.
                                      
                                      
                  //The same thing would happen if we tried to store pointers to the cylindrical faces needed for the
                  //concentric mate of the knob to the cylindrical face on the chasis.
                  
                  //I built a collection of safe entities so that I could ensure that these faces could still be selected
                  //even though the assembly is constantly being updated every time I add a component.


//let Finalize() =
//  //Clean up all the variables and reset SW settings
//  swApp.DocumentVisible true, swDocPART
//  Set swAssy = null
//  Set CircularCurveCollection = null
//  Set CircularEdgeCollection = null
//  Set SafeCylindricalFaceCollection = null
//  Set swModel = null
//  Set PointCollection = null
//  Set swSelFace = null
//  Set swSelMgr = null


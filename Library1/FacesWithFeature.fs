module FacesWithFeature

open FSharp.Idioms
open FSharp.Idioms.Jsons
open FSharp.Idioms.Literal
open FSharp.Idioms.Literal
open FSharp.SolidWorks
open FSharp.SolidWorks.FeatureExtrusion3
open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open SolidWorks.Interop.swpublished
open SolidWorksTools
open SolidWorksTools.File
open System
open System.Collections
open System.Collections.Generic
open System.Diagnostics
open System.Drawing
open System.IO
open System.Reflection
open System.Runtime.InteropServices
open System.Text
open System.Text.RegularExpressions
open System.Windows.Forms
open UnquotedJson
open Tanks
open Nozzles

let preselect (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2
    let swSelMgr =
        swModel.SelectionManager
        :?> SelectionMgr
    match swSelMgr.GetSelectedObject6(1, SelectionMgrUtils.Mark.All.value) with
    | :? Face2 as swSelFace  ->
        let swLoop =
            swSelFace
            |> Face2Utils.getLoopSeq
            |> Seq.exactlyOne

        let swEdge =
            swLoop.GetEdges()
            :?> obj[]
            |> Array.exactlyOne
            :?> Edge

        let swCurve =
            swEdge.GetCurve() :?> Curve

        let cylinderFace =
            swEdge.GetTwoAdjacentFaces2()
            :?> obj[]
            |> Array.map(fun swFace -> swFace :?> Face2)
            |> Array.find(fun swFace ->
                let surface = swFace.GetSurface() :?> Surface
                surface.IsCylinder()
            )
        swModel.FeatureManager.InsertMateReference2(
            BstrMateReferenceName = "圆柱配合",
            PrimaryReferenceEntity = (swSelFace :?> Entity),
            PrimaryReferenceType = int swMateReferenceType_e.swMateReferenceType_Coincident,
            PrimaryReferenceAlignment = int swMateReferenceAlignment_e.swMateReferenceAlignment_Any,
            PrimaryReferenceAlignAxes = false,
            SecondaryReferenceEntity = (cylinderFace:?> Entity),
            SecondaryReferenceType = int swMateReferenceType_e.swMateReferenceType_Concentric,
            SecondaryReferenceAlignment = int swMateReferenceAlignment_e.swMateReferenceAlignment_Any,
            SecondaryReferenceAlignAxes = false,
            TertiaryReferenceEntity = null,
            TertiaryReferenceType = int swMateReferenceType_e.swMateReferenceType_default,
            TertiaryReferenceAlignment = int swMateReferenceAlignment_e.swMateReferenceAlignment_Any
        )
        |> ignore
    | _ -> swApp.SendMsgToUser "no face2"


///
let cylinderMate (name:string) (circlePlane:Face2) (swModel:ModelDoc2)  =
    let swLoop =
        circlePlane
        |> Face2Utils.getLoopSeq
        |> Seq.exactlyOne

    let swEdge =
        swLoop.GetEdges()
        :?> obj[]
        |> Array.exactlyOne
        :?> Edge

    let swCurve =
        swEdge.GetCurve() :?> Curve

    let cylinderFace =
        swEdge.GetTwoAdjacentFaces2()
        :?> obj[]
        |> Array.map(fun swFace -> swFace :?> Face2)
        |> Array.find(fun swFace ->
            let surface = swFace.GetSurface() :?> Surface
            surface.IsCylinder()
        )

    swModel.FeatureManager.InsertMateReference2(
        BstrMateReferenceName = $"MR-{name}",
        PrimaryReferenceEntity = (circlePlane :?> Entity),
        PrimaryReferenceType = int swMateReferenceType_e.swMateReferenceType_Coincident,
        PrimaryReferenceAlignment = int swMateReferenceAlignment_e.swMateReferenceAlignment_Any,
        PrimaryReferenceAlignAxes = false,
        SecondaryReferenceEntity = (cylinderFace:?> Entity),
        SecondaryReferenceType = int swMateReferenceType_e.swMateReferenceType_Concentric,
        SecondaryReferenceAlignment = int swMateReferenceAlignment_e.swMateReferenceAlignment_Any,
        SecondaryReferenceAlignAxes = false,
        TertiaryReferenceEntity = null,
        TertiaryReferenceType = int swMateReferenceType_e.swMateReferenceType_default,
        TertiaryReferenceAlignment = int swMateReferenceAlignment_e.swMateReferenceAlignment_Any
    )
    |> ignore

let mateLibraryFeature (swFeat:Feature) (swModel:ModelDoc2) =
    let LibraryFeatureData = 
        swFeat.GetDefinition() :?> LibraryFeatureData
    LibraryFeatureData.AccessSelections(swModel, null)
    |> ignore

    let libraryName = Path.GetFileNameWithoutExtension(LibraryFeatureData.LibraryPart)
    //'Release the selections that define the library feature
    LibraryFeatureData.ReleaseSelectionAccess()

    match libraryName with
    | "法兰管口点线版" | "法兰管口平面版" ->
        let pipeFeat =
            swFeat
            |> FeatureUtils.getSubFeatureSeq
            |> Seq.find(fun subFeat ->
                let s = "pipe"
                subFeat.Name.[0..s.Length-1] = s
            )

        let circlePlane = 
            pipeFeat.GetFaces()
            :?> obj[]
            |> Array.map(fun x -> x :?> Face2)
            |> Array.find(fun swFace ->
                let surface = swFace.GetSurface() :?> Surface
                surface.IsPlane()
            )
        cylinderMate swFeat.Name circlePlane swModel
    | _ -> ()

let main (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> ModelDoc2

    swModel.FirstFeature()
    |> FeatureUtils.getFeatureSeq
    |> Seq.filter(fun swFeat -> swFeat.GetTypeName() = "LibraryFeature")
    |> Seq.iter(fun swFeat ->
        mateLibraryFeature swFeat swModel
    )

let extractDnPn (x) =
    let rgx = Regex(@"^DN (\d+) PN (\d+(\.\d+)?)$")
    let gs = rgx.Match(x).Groups
    let dn = Double.Parse gs.[1].Value
    let pn = Double.Parse gs.[2].Value
    dn,pn

let getNormalFromLibraryFeature (libraryFeatureData: LibraryFeatureData) (swMathUtility: MathUtility) =
    //' Get its placement type
    let placementPlane,placementPlaneType =
        libraryFeatureData.GetPlacementPlane2(int swLibFeatureData_e.swLibFeatureData_PartRespect)

    match enum<swSelectType_e> placementPlaneType with
    | swSelectType_e.swSelFACES ->
        let placementPlane = placementPlane :?> Face2
        placementPlane.Normal :?> float []

    | swSelectType_e.swSelDATUMPLANES ->
        let placementPlane = placementPlane :?> RefPlane
        MathUtilityExtend.getNormal placementPlane swMathUtility

    | _ -> failwith ""

let getSketchEntitiesFromLibraryFeature (libraryFeatureData: LibraryFeatureData) =
    let rec loop (maybeP: SketchPoint option) (maybeS: SketchSegment option) (ls: list<swSelectType_e*obj>) =
        match ls with
        | [] -> maybeP.Value, maybeS
        | (tp,vRef) :: tail ->
            match tp with
            | swSelectType_e.swSelSKETCHPOINTS ->
                let maybeP = vRef :?> SketchPoint |> Some
                loop maybeP maybeS tail

            | swSelectType_e.swSelSKETCHSEGS ->
                let maybeS = vRef :?> SketchSegment |> Some
                loop maybeP maybeS tail

            | _ -> failwith ""

    //' Get the references
    let vRefs,vRefType,vRefName = libraryFeatureData.GetReferences3(int swLibFeatureData_e.swLibFeatureData_PartRespect)
    let skPt, maybeSeg =
        vRefType
        :?> int[]
        |> Array.map(enum<swSelectType_e>)
        |> Array.zip <| (vRefs :?> obj[])
        |> Array.toList
        |> loop None None
    skPt, maybeSeg

let getNozzles (swModel:ModelDoc2) (swMathUtility: MathUtility) =
    swModel
    |> ModelDoc2Utils.getFeatureSeq
    |> Seq.filter(fun swFeature -> swFeature.GetTypeName() = "LibraryFeature")
    |> Seq.choose(fun swFeature ->
        let nozzleName = swFeature.Name
        let LibraryFeatureData =
            swFeature.GetDefinition() 
            :?> LibraryFeatureData
        LibraryFeatureData.AccessSelections(swModel, null)
        |> ignore

        //' Get the name of the active library feature configuration
        let ConfigurationName = LibraryFeatureData.ConfigurationName
        let dn,pn = extractDnPn ConfigurationName

        let libraryName = Path.GetFileNameWithoutExtension(LibraryFeatureData.LibraryPart)
        let skPt, maybeSeg = getSketchEntitiesFromLibraryFeature LibraryFeatureData
        let pt = MathUtilityExtend.getGlobalCoordinates skPt swMathUtility

        let maybeLocation =
            match libraryName with
            | "法兰管口点线版" ->
                // 垂直圆柱面管口
                let angle =
                    match enum<swSketchSegments_e> (maybeSeg.Value.GetType()) with
                    | swSketchSegments_e.swSketchLINE ->
                        let swSkLine = maybeSeg.Value :?> SketchLine
                        swSkLine.Angle*180.0/Math.PI
                    | _ -> failwith ""

                WallNozzle(pt.[1],angle,0.0,0.0)
                |> Some
            | "平面上150mm管柱" | "法兰管口平面版" ->
                let n = getNormalFromLibraryFeature LibraryFeatureData swMathUtility
                let x = pt.[0]
                let y = pt.[2]

                let angle = (atan2 y x)*180.0/Math.PI
                let radius = sqrt (x*x+y*y)
                RoofNozzle(x,y,angle,radius)
                |> Some

            | _ -> None
        //'Release the selections that define the library feature
        LibraryFeatureData.ReleaseSelectionAccess()

        maybeLocation
        |> Option.map(fun location -> {
            code = nozzleName
            PN = pn
            DN = dn
            location = location
        })
    )

let tankInfo (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> ModelDoc2
    let CusPropMgr = swModel.Extension.CustomPropertyManager("")
    let swMathUtility = swApp.GetMathUtility() :?> MathUtility

    let tankName = Path.GetFileNameWithoutExtension(swModel.GetTitle())

    let sb = StringBuilder()
    sb.Append $"{tankName}\n" |> ignore

    // 读属性
    let names = 
        CusPropMgr.GetNames() 
        :?> obj[]
        |> Array.map (fun x -> x :?> string)

    names
    |> Seq.iter(fun nm ->
        let s =
            CusPropMgr
            |> CustomPropertyManagerUtils.GetUpdatedProperty nm
            |> snd
        sb.Append $"{nm}={s}\n" |> ignore
    )

    getNozzles swModel swMathUtility
    |> Seq.iter(fun nozzle ->
        sb.Append $"{stringify nozzle}\n" |> ignore
    )
    //swApp.SendMsgToUser (sb.ToString())
    let s = sb.ToString()
    let path = Path.Combine(Dir.CommandData,"tankinfo.txt")
    File.WriteAllText(path,s)
    swApp.SendMsgToUser path

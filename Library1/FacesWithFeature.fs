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

let createCylinderMateRef (name:string) (circlePlane:Face2) (cylinderFace:Face2) (swModel:IModelDoc2) =
    let planeEntity = circlePlane :?> Entity
    let cylinderEntity = cylinderFace :?> Entity
    swModel.FeatureManager.InsertMateReference2(
        BstrMateReferenceName = name,
        PrimaryReferenceEntity = planeEntity,
        PrimaryReferenceType = int swMateReferenceType_e.swMateReferenceType_Coincident,
        PrimaryReferenceAlignment = int swMateReferenceAlignment_e.swMateReferenceAlignment_AntiAligned,
        PrimaryReferenceAlignAxes = false,
        SecondaryReferenceEntity = cylinderEntity,
        SecondaryReferenceType = int swMateReferenceType_e.swMateReferenceType_Concentric,
        SecondaryReferenceAlignment = int swMateReferenceAlignment_e.swMateReferenceAlignment_Any,
        SecondaryReferenceAlignAxes = false,
        TertiaryReferenceEntity = null,
        TertiaryReferenceType = int swMateReferenceType_e.swMateReferenceType_default,
        TertiaryReferenceAlignment = int swMateReferenceAlignment_e.swMateReferenceAlignment_Any
    )
    |> ignore

/// 从圆截面获取邻近的圆柱面
let getCylinderFaceFromCake (cakeFace:Face2) =
    let swLoop =
        cakeFace
        |> Face2Utils.getLoopSeq
        |> Seq.exactlyOne

    let swEdge =
        swLoop.GetEdges()
        :?> obj[]
        |> Array.exactlyOne
        :?> Edge

    swEdge.GetTwoAdjacentFaces2()
    :?> obj[]
    |> Array.map(fun swFace -> swFace :?> Face2)
    |> Array.find(fun swFace ->
        let surface = swFace.GetSurface() :?> Surface
        surface.IsCylinder()
    )

/// 从环行截面获取里面较小的圆柱面
let getCylinderFaceFromCollar (collarPlane:Face2) =
    // 此处有两个圆，一个小圆，一个大圆，选择小圆
    let swEdge =
        collarPlane
        |> Face2Utils.getLoopSeq
        |> Seq.collect(fun swLoop ->
            swLoop.GetEdges()
            :?> obj[]
        )
        |> Seq.map(fun obj ->
            let swEdge = obj :?> Edge
            let swCurve = swEdge.GetCurve() :?> Curve
            // center.x, center.y, center.z, axis.x, axis.y, axis.z, radius
            let arr = swCurve.CircleParams :?> float[]
            let r = arr.[6]
            swEdge,r
        )
        |> Seq.minBy snd
        |> fst

    swEdge.GetTwoAdjacentFaces2()
    :?> obj[]
    |> Array.map(fun obj -> obj :?> Face2)
    |> Array.find(fun swFace ->
        let surface = swFace.GetSurface() :?> Surface
        surface.IsCylinder()
    )

let insertCylinderMateRef (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2
    let swSelMgr =
        swModel.SelectionManager
        :?> SelectionMgr
    match swSelMgr.GetSelectedObject6(1, SelectionMgrUtils.Mark.All.value) with
    | :? Face2 as swSelFace  ->
        let cylinderFace = getCylinderFaceFromCake swSelFace
        createCylinderMateRef "" swSelFace cylinderFace swModel
    | _ -> swApp.SendMsgToUser "no face2"

let mateLibraryFeature (swFeat:Feature) (swModel:ModelDoc2) =
    let LibraryFeatureData = 
        swFeat.GetDefinition() :?> LibraryFeatureData
    LibraryFeatureData.AccessSelections(swModel, null)
    |> ignore

    //'Release the selections that define the library feature
    LibraryFeatureData.ReleaseSelectionAccess()

    match Path.GetFileNameWithoutExtension(LibraryFeatureData.LibraryPart) with
    | "Axis Nozzle A" | "Plane Nozzle A" ->
        let pipeFeat =
            swFeat
            |> FeatureUtils.getSubFeatureSeq
            |> Seq.find(fun subFeat ->
                subFeat.Name.StartsWith "Pipe"
            )

        let collarPlane = 
            pipeFeat.GetFaces()
            :?> obj[]
            |> Array.map(fun x -> x :?> Face2)
            |> Array.find(fun swFace ->
                let surface = swFace.GetSurface() :?> Surface
                surface.IsPlane()
            )
        let cylinderFace = getCylinderFaceFromCollar collarPlane
        createCylinderMateRef swFeat.Name collarPlane cylinderFace swModel

    | _ -> ()

/// 配合参考法兰口
let generateNozzleMateRefs (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> ModelDoc2

    swModel.FirstFeature()
    |> FeatureUtils.getFeatureSeq
    |> Seq.filter(fun swFeat -> swFeat.GetTypeName() = "LibraryFeature")
    |> Seq.iter(fun swFeat ->
        mateLibraryFeature swFeat swModel
    )

/// 从nozzle a configuration 提取dn,pn
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
    let vRefs = vRefs :?> obj[]
    let skPt, maybeSeg =
        vRefType
        :?> int[]
        |> Array.map (enum<swSelectType_e>)
        |> Array.zip <| vRefs
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

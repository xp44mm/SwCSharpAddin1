module Asia

open System
open System.Runtime.InteropServices
open System.Collections
open System.Collections.Generic
open System.Drawing
open System.Diagnostics
open System.Reflection
open System.Text.RegularExpressions
open System.Windows.Forms

open System.IO

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

open FSharp.SolidWorks
open FSharp.SolidWorks.FeatureExtrusion3

open FSharp.Idioms
open FSharp.Idioms.Jsons
open FSharp.Idioms.Literal

open Tanks
open UnquotedJson
open System.Text

let tank1 = "立式平底罐"
let tank2 = "立式圆底罐"
let workPath = @"D:\崔胜利\凯帝隆\湖北武穴锂宝\solidworks3\"

let activateDoc name (swApp: ISldWorks) =
    let mutable errors = 0
    let res =
        swApp.ActivateDoc3(
            Name               = name,
            UseUserPreferences = false,
            Option             = int swRebuildOnActivation_e.swDontRebuildActiveDoc,
            Errors             = &errors)
    if errors = 0 then
        res
    else
        failwith $"{enum<swActivateDocError_e> errors}"

//https://help.solidworks.com/2023/english/api/sldworksapi/SolidWorks.Interop.sldworks~SolidWorks.Interop.sldworks.IModelDocExtension~SaveAs3.html
let saveAs (filename:string) (swModel:IModelDoc2) =
    let mutable errors = 0
    let mutable warnings = 0

    swModel.Extension.SaveAs(
        Name = Path.Combine(workPath, filename),
        Version = int swSaveAsVersion_e.swSaveAsCurrentVersion,
        Options = int swSaveAsOptions_e.swSaveAsOptions_Silent,
        ExportData = null,
        Errors = &errors,
        Warnings = &warnings
        )
    |> ignore

    if errors <> 0 then
        failwith $"{enum<swFileSaveError_e> errors}"

    if warnings <> 0 then
        failwith $"{enum<swFileSaveWarning_e> warnings}"

let save (swModel:IModelDoc2) =
    let mutable errors = 0
    let mutable warnings = 0

    swModel.Save3(
        Options = int swSaveAsOptions_e.swSaveAsOptions_Silent,
        Errors = &errors,
        Warnings = &warnings
        )
    |> ignore

    if errors <> 0 then
        failwith $"{enum<swFileSaveError_e>errors}"

    if warnings <> 0 then
        failwith $"{enum<swFileSaveWarning_e>warnings}"

let loadData() =
    //let path = Path.Combine(Dir.CommandData,"tanks.js")
    //let text = File.ReadAllText(path)
    let text =
        if Clipboard.ContainsText(TextDataFormat.UnicodeText) then
            Clipboard.GetText(TextDataFormat.UnicodeText)
        else failwith "Clipboard.ContainsText"

    let json = Json.parse text
    let ls =
        match json with
        | Json.Array ls ->
            ls
            |> List.map Tank.from
        | _ -> failwith "schema mismatch"
    let a,b =
        ls
        |> List.partition(fun x ->
            match x with
            | VerticalTank tank -> true
            | LegTank tank -> false
        )

    let a =
        a
        |> List.map(fun x ->
            match x with
            | VerticalTank tank ->
                tank
            | LegTank tank -> failwith "")

    let b =
        b
        |> List.map(fun x ->
            match x with
            | LegTank tank -> tank
            | VerticalTank tank -> failwith "")

    a,b

/// 当前文档另存为许多其他文件，并修改一些属性
/// 批量生成箱子零件
let generate (swApp: ISldWorks) =
    let rec loop1 src (tanks: TankP list) =
        match tanks with
        | [] -> ()
        | tank :: tail ->
            let bitcode = tank.bitcode
            let filename = $"{bitcode}.SLDPRT"
            saveAs filename src
            let swModel = activateDoc filename swApp :?> ModelDoc2
            let CusPropMgr = swModel.Extension.CustomPropertyManager("")
            CusPropMgr.Set2(FieldName = "直径", FieldValue = sprintf "%f" tank.直径)
            |> ignore
            CusPropMgr.Set2(FieldName = "高度", FieldValue = sprintf "%f" tank.高度)
            |> ignore
            save swModel
            loop1 swModel tail

    let tanks1,tanks2 = loadData()
    let temp1 = 
        OpenDocExecutor.from(tank1,"",swOpenDocOptions_e.swOpenDocOptions_Silent).openDoc swApp
    loop1 temp1 tanks1

    let swModel = swApp.ActiveDoc :?> IModelDoc2
    swModel.GetPathName()
    |> swApp.CloseDoc

    let rec loop2 src (tanks: TankY list) =
        match tanks with
        | [] -> ()
        | tank :: tail ->
            let bitcode = tank.bitcode
            let filename = $"{bitcode}.SLDPRT"
            saveAs filename src
            let swModel = activateDoc filename swApp :?> ModelDoc2
            let CusPropMgr = swModel.Extension.CustomPropertyManager("")
            CusPropMgr.Set2(FieldName = "直径", FieldValue = sprintf "%f" tank.直径)
            |> ignore
            CusPropMgr.Set2(FieldName = "高度", FieldValue = sprintf "%f" tank.高度)
            |> ignore
            CusPropMgr.Set2(FieldName = "ChordHeight", FieldValue = sprintf "%f" tank.ChordHeight)
            |> ignore
            CusPropMgr.Set2(FieldName = "BottomHeight", FieldValue = sprintf "%f" tank.BottomHeight)
            |> ignore
            save swModel
            loop2 swModel tail

    let temp2 = OpenDocExecutor.from(tank2,"",swOpenDocOptions_e.swOpenDocOptions_Silent).openDoc swApp
    loop2 temp2 tanks2

    let swModel = swApp.ActiveDoc :?> IModelDoc2
    swModel.GetPathName()
    |> swApp.CloseDoc


/// 从tsv文件读取参考平面数据
let loadPlanes() =
    let text =
        if Clipboard.ContainsText(TextDataFormat.UnicodeText) then
            Clipboard.GetText(TextDataFormat.UnicodeText)
        else failwith "Clipboard.ContainsText"

    let json = Json.parse text

    match json with
    | Json.Array ls ->
        ls
        |> List.map (fun j ->
            match j with
            | Json.Object [
                "basePlane", Json.String plane
                "distance", Json.Number dist
                ] -> plane,dist
            | _ -> failwith "schema mismatch"
        )
    | _ -> failwith "schema mismatch"


let getLibraryFeatureData (swApp: ISldWorks) =
    let swMathUtility = swApp.GetMathUtility() :?> MathUtility

    let swModel = swApp.ActiveDoc :?> ModelDoc2
    let tankName = Path.GetFileNameWithoutExtension(swModel.GetTitle())

    let sb = StringBuilder()
    sb.Append(tankName+"\n") |> ignore

    swModel
    |> ModelDoc2Utils.getFeatureSeq
    |> Seq.filter(fun swFeature -> swFeature.GetTypeName() = "LibraryFeature")
    |> Seq.iter(fun swFeature ->
        let nozzleName = swFeature.Name
        sb.Append($"\n{nozzleName} ") |> ignore
        let LibraryFeatureData = 
            swFeature.GetDefinition() 
            :?> LibraryFeatureData
        LibraryFeatureData.AccessSelections(swModel, null)
        |> ignore

        //' Get the name of the active library feature configuration
        let ConfigurationName = LibraryFeatureData.ConfigurationName
        sb.Append $"ConfigurationName = {ConfigurationName}\n" |> ignore

        let libraryName = Path.GetFileNameWithoutExtension(LibraryFeatureData.LibraryPart)
        sb.Append($"{libraryName}\n") |> ignore

        //' Get its placement type
        let placementPlane,placementPlaneType =
            LibraryFeatureData.GetPlacementPlane2(int swLibFeatureData_e.swLibFeatureData_PartRespect)
        let maybeNormal =
            match enum<swSelectType_e> placementPlaneType with
            | swSelectType_e.swSelFACES ->
                let placementPlane = placementPlane :?> Face2
                let n = placementPlane.Normal :?> float []
                //sb.Append $"Normal = {stringify n}\n" |> ignore
                Some n
            | swSelectType_e.swSelDATUMPLANES ->
                let placementPlane = placementPlane :?> RefPlane
                let n = MathUtilityExtend.getNormal placementPlane swMathUtility
                //sb.Append $"Normal = {stringify n}\n" |> ignore
                Some n
            | _ -> None
        let rec loop (maybeP:SketchPoint option) (maybeS:SketchSegment option) (ls:list<swSelectType_e*obj>) =
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
        let vRefs,vRefType,vRefName = LibraryFeatureData.GetReferences3(int swLibFeatureData_e.swLibFeatureData_PartRespect)
        let skPt, maybeSeg =
            vRefType
            :?> int[]
            |> Array.map(enum<swSelectType_e>)
            |> Array.zip <| (vRefs :?> obj[])
            |> Array.toList
            |> loop None None

        let pt = MathUtilityExtend.getGlobalCoordinates skPt swMathUtility
        let maybeLine =
            maybeSeg
            |> Option.map(fun skSeg ->
                
                match enum<swSketchSegments_e>(skSeg.GetType()) with
                | swSketchSegments_e.swSketchLINE ->
                    let swSkLine = skSeg :?> SketchLine
                    //方位角
                    let orientation = swSkLine.Angle
                    let skPt = swSkLine.GetStartPoint2():?> SketchPoint
                    let pt = MathUtilityExtend.getGlobalCoordinates skPt swMathUtility
                    orientation,pt
                | _ -> failwith ""
            )

        //'Release the selections that define the library feature
        LibraryFeatureData.ReleaseSelectionAccess()

        match libraryName with
        | "法兰管口点线版" ->
            // 垂直圆柱面管口
            let angle,startPoint = maybeLine.Value
            sb.Append($"Point: {stringify pt}\n") |> ignore
            sb.Append($"angle: {stringify (angle*180.0/Math.PI)}\n") |> ignore
            sb.Append($"another Point: {stringify startPoint}\n") |> ignore

        | "平面上150mm管柱" | "法兰管口平面版" ->
            sb.Append($"replacement Plane: {stringify maybeNormal.Value}\n") |> ignore
            sb.Append($"Point: {stringify pt}\n") |> ignore

        | _ -> failwith libraryName

    )
    let s = sb.ToString()
    let path = Path.Combine(Dir.CommandData,"LibraryFeature.txt")
    File.WriteAllText(path,s)
    swApp.SendMsgToUser path


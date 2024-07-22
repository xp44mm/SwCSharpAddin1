module Harbor

open FSharp.Idioms
open FSharp.Idioms.Jsons
open FSharp.Idioms.Literal
open FSharp.SolidWorks
open FSharp.SolidWorks.FeatureExtrusion3
open Nozzles
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
open Tanks
open UnquotedJson

/// 批量创建参考平面
let createPlanes (swApp: ISldWorks) =
    match Clipboard.tryParseTsv swApp with 
    | None -> ()
    | Some tsvArr ->
    let swModel = swApp.ActiveDoc :?> IModelDoc2
    let swSelMgr =
        swModel.SelectionManager
        :?> SelectionMgr

    let createPlane (plane:string) (dist:float) =
        swModel.ClearSelection2 true
        swModel.Extension.SelectByID2(
            Name = plane,
            Type = "PLANE",
            X = 0.0,
            Y = 0.0,
            Z = 0.0,
            Append = false,
            Mark = 0,
            Callout = null,
            SelectOption = int swSelectOption_e.swSelectOptionDefault
        )
        |> ignore

        let swFeature =
            let firstConstraint =
                [
                    swRefPlaneReferenceConstraints_e.swRefPlaneReferenceConstraint_Distance
                    if dist < 0 then
                        swRefPlaneReferenceConstraints_e.swRefPlaneReferenceConstraint_OptionFlip
                ]
                |> Seq.reduce(|||)
            swModel.FeatureManager.InsertRefPlane(
                FirstConstraint = int firstConstraint,
                FirstConstraintAngleOrDistance = Math.Abs dist/1e3,
                SecondConstraint = 0,
                SecondConstraintAngleOrDistance = 0,
                ThirdConstraint = 0,
                ThirdConstraintAngleOrDistance = 0)
            :?> Feature

        swFeature

    //剪切板内容
    tsvArr
    |> Array.filter(fun fs ->
        match fs with
        | [||]
        | [|""|] -> false
        | _ -> true)
    |> Array.map (fun fs ->
        match fs with
        | [|plane;dist|] ->
            plane, Double.Parse dist
        | _ -> failwith $"{stringify fs}"
    )
    |> Array.iter(fun (plane, dist) ->
        let tag =
            match plane with
            | "Top Plane" -> "EL"
            | "Front Plane" -> "F"
            | "Right Plane" -> "R"
            | _ -> failwith ""

        let frdName = $"{tag}{dist}"

        let swFeature = createPlane plane dist
        swFeature.Name <- frdName
    )

let mateCoordinate (baseCoordSys:string, compCoordSys:string) (swModel:IModelDoc2) (swAssy:IAssemblyDoc) =
    // 为新组件添加配合
    swModel.ClearSelection2 true

    swModel.Extension.SelectByID2(
        Name = baseCoordSys, // "v0101a@罐区建筑-1@罐区装配体"
        Type = "COORDSYS",
        X = 0.0,
        Y = 0.0,
        Z = 0.0,
        Append = false,
        Mark = 0,
        Callout = null,
        SelectOption = int swSelectOption_e.swSelectOptionDefault
        )
    |> ignore

    swModel.Extension.SelectByID2(
        Name = compCoordSys, // "Coordinate System1@V0101A-1@罐区装配体",
        Type = "COORDSYS",
        X = 0.0,
        Y = 0.0,
        Z = 0.0,
        Append = true,
        Mark = 0,
        Callout = null,
        SelectOption = int swSelectOption_e.swSelectOptionDefault
        )
    |> ignore

    {
        MateType = MateCOORDINATE
        MateAlign = swMateAlign_e.swMateAlignALIGNED
        ForPositioningOnly = false
    }.AddMate5 swAssy
    |> ignore

    swModel.ClearSelection2 true

type SolidWorksFile = 
    {
        PathName: string
        Title: string
        FileNameWithoutExtension: string
        DirectoryName:string
    }

    static member from(swModel:IModelDoc2) =
        let path = swModel.GetPathName()
        let title = swModel.GetTitle()

        //必须先保存装配体,才能获取有效路径
        {
            PathName = path
            Title = title
            FileNameWithoutExtension = Path.GetFileNameWithoutExtension(title)
            DirectoryName = Path.GetDirectoryName(path)
        }

type CoordSysCoordinate = 
    {
        refid: string
        motherCoordSys: string
        compFileName: string
        compConfig: string
        compCoordSys: string
    }



// 获取坐标系特征，既坐标系名称，组件名称，(如果需要，读取位号型号对照表)打开的文件名称，插入组件。
// 用坐标系特征，和插入组件零件中的唯一坐标系，他们俩重合配合。
// 当文件名是位号时，组件参考空着
// 当文件名是设备名称，配置是型号名，组件参考填写位号。

/// 装配体添加子零件：基础装配体里面所有坐标系，每个坐标系添加一个零件，每个零件有唯一一个坐标系。

/// 装配体有一个基础零件，里面所有坐标系，每个坐标系名称是位号
/// 读取剪贴板里面的位号零件对照表：位号，位号.part或者
/// 位号，pump.part 配置名称

/// 插入组件到装配体
let manyComp (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2
    let assyFile = SolidWorksFile.from swModel

    // 获得母装配体第一层所有零件信息包括refid
    // 坐标系的名称
    let addmate (rowData:CoordSysCoordinate) =
        // 关闭打开的零件
        swApp.CloseDoc rowData.compFileName
        
        let _ = OpenDocExecutor.from(rowData.compFileName,rowData.compConfig).OpenDocAndShowConfiguration swApp

        // Reactivate the assembly because that is where the rest of the work is done
        let swModel = 
            DocActivator.just(assyFile.Title,false,swRebuildOnActivation_e.swDontRebuildActiveDoc).ActivateDoc3(swApp)
            :?> IModelDoc2

        let swAssy = swModel :?> IAssemblyDoc

        // 新添加的组件
        let newComponent =
            (id<AddComponent5Params> {
                CompName = rowData.compFileName
                ConfigOption = AddComponentConfigOptions.CurrentSelectedConfig
                MaybeUseConfigForPartReferences = Some rowData.compConfig // part config
                CompCenter = 0.0,0.0,0.0
            }).AddComponent5 swAssy

        // 新添加组件的坐标系
        let compCoordSys =
            [rowData.compCoordSys; newComponent.Name2; assyFile.FileNameWithoutExtension]
            |> String.concat "@"

        /// 基础零件的坐标系
        let motherCoordSys =
            [ rowData.motherCoordSys; assyFile.FileNameWithoutExtension ]
            |> String.concat "@"

        mateCoordinate (motherCoordSys,compCoordSys) swModel swAssy

        newComponent.ComponentReference <- rowData.refid

        //// 关闭打开的零件
        //swApp.CloseDoc rowData.compFileName
    
    let existingComps (refids:string Set) =
        let swConfMgr = swModel.ConfigurationManager
        let rootComp =
            swConfMgr.ActiveConfiguration.GetRootComponent3 true

        rootComp.GetChildren()
        :?> obj[]
        |> Array.map(fun obj -> obj :?> Component2)
        |> Array.choose(fun comp -> 
            let refid = comp.ComponentReference
            if refids.Contains refid then
                Some refid
            else None
            )
        |> Set.ofArray

    match Clipboard.tryParseTsv swApp with 
    | None -> ()
    | Some tsvArr ->
    let rows =
        //剪切板内容
        tsvArr
        |> Array.filter(fun fs ->
            match fs with
            | [||] | [|""|] -> false
            | _ -> true
            )
        |> Array.map (fun fs ->
            match fs with
            | [| refid; motherCoordSys; compFileName; compConfig; compCoordSys |] ->
                //let refid = 
                //    let first = (motherCoordSys.Split [|'@'|]).[0]
                //    Regex.Replace(first,"CS$","")

                {
                    refid = refid
                    motherCoordSys = motherCoordSys
                    compFileName = compFileName
                    compConfig = compConfig
                    compCoordSys = compCoordSys
                }
            | _ -> failwith $"{stringify fs}"
        )

    let refids = 
        rows
        |> Array.map(fun row -> row.refid)
        |> Set.ofArray

    let existingComps = existingComps refids

    rows
    |> Array.filter(fun rowData ->
        existingComps.Contains rowData.refid |> not
    )
    |> Array.iter(fun rowData ->
        addmate rowData
    )
    
    swModel.EditRebuild3() |> ignore


/// 从零件中获取所有坐标系
let getAllOfCoordinateSystems (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> ModelDoc2
    let sb = StringBuilder()

    swModel.FirstFeature()
    |> FeatureUtils.getFeatureSeq
    |> Seq.filter(fun swFeature -> swFeature.GetTypeName2() = "CoordSys" )
    |> Seq.iter(fun swFeature ->
        sb.Append $"{swFeature.Name}\n" |> ignore
        match swFeature.GetSpecificFeature2() with
        | null ->
            //sb.Append $"Specific null\n" |> ignore
            let cSysData = swFeature.GetDefinition() :?> CoordinateSystemFeatureData
            cSysData.AccessSelections(swModel, null)
            |> ignore

            let swXform = cSysData.Transform
            cSysData.ReleaseSelectionAccess()

            let swMathUtility = swApp.GetMathUtility() :?> MathUtility

            let arr = swXform.ArrayData :?> float[]

            let xAxis = arr.[0..2]
            let yAxis = arr.[3..5]
            let zAxis = arr.[6..8]

            let origin = 
                arr.[9..11]
                |> Array.map((*) 1000.)

            let nozzle = NozzlePlace.from (origin,zAxis)

            let outp =
                [
                    $"Origin = {stringify origin} mm"
                    //$"X = { stringify xAxis }"
                    //$"Y = { stringify yAxis }"
                    $"Z = { stringify zAxis }"
                    //$"Scale = { arr.[12]}"

                    $"Nozzle={stringify nozzle}"

                ]
                |> String.concat "\r\n"
            sb.AppendLine(outp) |> ignore

        | s ->
            sb.Append $"Specific {s.GetType().Name}\n" |> ignore
            ()
    )
    let s = sb.ToString()
    //let path = Path.Combine(Dir.CommandData,"CoordSys.txt")
    //File.WriteAllText(path,s)
    match
        swApp.SendMsgToUser2(
            Message = s,
            Icon = int swMessageBoxIcon_e.swMbInformation,
            Buttons = int swMessageBoxBtn_e.swMbYesNo)
        |> enum<swMessageBoxResult_e>
    with
    | swMessageBoxResult_e.swMbHitYes -> 
        Clipboard.SetText s
    | _ -> ()

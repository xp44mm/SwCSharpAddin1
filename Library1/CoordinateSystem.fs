module CoordinateSystem


open FSharp.Idioms
open FSharp.Idioms.Jsons
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

//添加或修改多个文件属性

//从零件中获取所有坐标系
let getAllOfCoordinateSystems (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2
    let sb = StringBuilder()

    swModel.FirstFeature()
    |> FeatureUtils.getFeatureSeq
    |> Seq.filter(fun swFeature -> swFeature.GetTypeName2() = "CoordSys" )
    |> Seq.iter(fun swFeature ->
        sb.Append $"{swFeature.Name}\n" |> ignore
        match swFeature.GetSpecificFeature2() with
        | null ->
            //sb.Append $"Specific null\n" |> ignore
            let data = swFeature.GetDefinition() :?> CoordinateSystemFeatureData
            //sb.Append $"data {stringifyTypeDynamic(data.GetType())}\n" |> ignore
            ()
        | s ->
            //sb.Append $"Specific {stringifyTypeDynamic(s.GetType())}\n" |> ignore
            ()
    )
    let s = sb.ToString()
    let path = Path.Combine(Dir.CommandData,"CoordSys.txt")
    File.WriteAllText(path,s)
    swApp.SendMsgToUser path

/// 收集零件/装配体所有坐标系，为他们生成配合参考
let collectCoordSysMateRefs (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2
    //let selectionMgr = swModel.SelectionManager :?> SelectionMgr
    swModel.FirstFeature()
    |> FeatureUtils.getFeatureSeq
    |> Seq.filter(fun swFeature -> swFeature.GetTypeName2() = "CoordSys" )
    |> Seq.iter(fun swFeature ->
        let name = swFeature.Name
        swModel.ClearSelection2 true

        swModel.Extension.SelectByID2(
            Name = name,
            Type = "COORDSYS",
            X = 0.0,
            Y = 0.0,
            Z = 0.0,
            Append = true,
            Mark = 1,
            Callout = null,
            SelectOption = int swSelectOption_e.swSelectOptionDefault)
        |> ignore

        swModel.FeatureManager.InsertMateReference2(
            BstrMateReferenceName = name,

            PrimaryReferenceEntity = null,
            PrimaryReferenceType = int swMateReferenceType_e.swMateReferenceType_Coincident,
            PrimaryReferenceAlignment = int swMateReferenceAlignment_e.swMateReferenceAlignment_Any,
            PrimaryReferenceAlignAxes = true,

            SecondaryReferenceEntity = null,
            SecondaryReferenceType = int swMateReferenceType_e.swMateReferenceType_default,
            SecondaryReferenceAlignment = int swMateReferenceAlignment_e.swMateReferenceAlignment_Any,
            SecondaryReferenceAlignAxes = false,

            TertiaryReferenceEntity = null,
            TertiaryReferenceType = int swMateReferenceType_e.swMateReferenceType_default,
            TertiaryReferenceAlignment = int swMateReferenceAlignment_e.swMateReferenceAlignment_Any
        )
        |> ignore

        swModel.ClearSelection2 true

    )

// this sub routine will open the component that you want to add to the assembly
let OpenComponentModelToAddToAssembly (fileName: string, configName:string) (assemblyTitle: string) (swApp: ISldWorks) =
    //Open the component. This must be open or the AddComponent method will fail
    let compModel =
        swApp
        |> SldWorksUtils.openDoc6
            fileName
            swDocumentTypes_e.swDocPART
            swOpenDocOptions_e.swOpenDocOptions_Silent
            configName
    //|> ignore

    // Shows the named configuration by switching to that configuration and making it the active configuration.
    compModel.ShowConfiguration2 configName
    |> ignore

    //Reactivate the assembly because that is where the rest of the work is done
    let swModel =
        swApp
        |> SldWorksUtils.activateDoc3
            assemblyTitle
            false
            swRebuildOnActivation_e.swDontRebuildActiveDoc

    let swAssy = swModel :?> IAssemblyDoc

    swAssy

let mateCoordinate (baseCoordSys,compCoordSys) (swModel:IModelDoc2) (swAssy:IAssemblyDoc) =
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


// 获取坐标系特征，既坐标系名称，组件名称，(如果需要，读取位号型号对照表)打开的文件名称，插入组件。
// 用坐标系特征，和插入组件零件中的唯一坐标系，他们俩重合配合。
// 当文件名是位号时，组件参考空着
// 当文件名是设备名称，配置是型号名，组件参考填写位号。

/// 装配体添加子零件：基础装配体里面所有坐标系，每个坐标系添加一个零件，每个零件有唯一一个坐标系。

/// 装配体有一个基础零件，里面所有坐标系，每个坐标系名称是位号
/// 读取剪贴板里面的位号零件对照表：位号，位号.part或者
/// 位号，pump.part 配置名称
let addManyCompToCoordSys (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2

    let assyPath = swModel.GetPathName()
    let assyTitle = swModel.GetTitle()
    let assyName = Path.GetFileNameWithoutExtension(assyTitle) // = "罐区装配体"
    //必须先保存装配体
    let assyDir = Path.GetDirectoryName(assyPath)

    let swConfMgr = swModel.ConfigurationManager
    let rootComp =
        swConfMgr.ActiveConfiguration.GetRootComponent3 true

    let baseComp =
        rootComp.GetChildren()
        :?> obj[]
        |> Array.map(fun obj -> obj :?> Component2)
        |> Seq.exactlyOne

    let baseName = baseComp.Name2

    let text =
        if Clipboard.ContainsText(TextDataFormat.UnicodeText) then
            Clipboard.GetText(TextDataFormat.UnicodeText)
        else failwith "Clipboard.ContainsText"

    let bitcodes = Bitcodes.parseToMap text

    baseComp.FirstFeature()
    |> FeatureUtils.getFeatureSeq
    |> Seq.filter(fun swFeature -> swFeature.GetTypeName2() = "CoordSys" && bitcodes.ContainsKey swFeature.Name)
    |> Seq.iter(fun coordSysFeature ->
        let bitcode = coordSysFeature.Name
        let file,config = bitcodes.[bitcode]
        let fileName = Path.Combine(assyDir,$"{file}.SLDPRT")
        let swAssy = OpenComponentModelToAddToAssembly (fileName,config) assyTitle swApp

        // 新添加的组件
        let newComponent =
            {
                CompName = fileName
                ConfigOption = AddComponentConfigOptions.CurrentSelectedConfig
                MaybeUseConfigForPartReferences = Some config
                CompCenter = 0.,0.,0.
            }.AddComponent5 swAssy

        /// 基础零件的坐标系
        let baseCoordSys =
            [ bitcode; baseName; assyName ]
            |> String.concat "@"

        // 新添加组件的坐标系
        let compCoordSys =
            let coordSysInNewComp =
                newComponent.FirstFeature()
                |> FeatureUtils.getFeatureSeq
                |> Seq.find(fun swFeature -> swFeature.GetTypeName2() = "CoordSys" )
            [ coordSysInNewComp.Name; newComponent.Name2; assyName ]
            |> String.concat "@"

        mateCoordinate (baseCoordSys,compCoordSys) (swModel) (swAssy)

        if StringComparer.OrdinalIgnoreCase.Equals(file, bitcode) && config = "" then
            ()
        else
            newComponent.ComponentReference <- bitcode

        swApp.CloseDoc fileName

    )

    swModel.EditRebuild3() |> ignore


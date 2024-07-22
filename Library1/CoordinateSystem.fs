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
        // 选择坐标系
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
    let compModel = OpenDocExecutor.from(fileName,configName).OpenDocAndShowConfiguration swApp

    // Reactivate the assembly because that is where the rest of the work is done
    let swModel = 
        DocActivator.just(assemblyTitle,false,swRebuildOnActivation_e.swDontRebuildActiveDoc).ActivateDoc3(swApp)

    let swAssy = swModel :?> IAssemblyDoc

    swAssy



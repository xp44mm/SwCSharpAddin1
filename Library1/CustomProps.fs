﻿module CustomProps

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

let main (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2

    let CusPropMgr = swModel.Extension.CustomPropertyManager("")
    CusPropMgr.Add3(
        FieldName = "MyTest",
        FieldType = int swCustomInfoType_e.swCustomInfoText,
        FieldValue = "This is a test.",
        OverwriteExisting = int swCustomPropertyAddOption_e.swCustomPropertyReplaceValue
    )
    |> ignore

    // Retrieve the value of a custom property called MyTest
    let Value,ResValue = 
        let mutable valOut = ""
        let mutable resolvedValOut = ""
        let mutable wasResolved = false
        let mutable linkToProperty = false
        let i =
            CusPropMgr.Get6(
                FieldName = "MyTest",
                UseCached = false,
                ValOut = &valOut,
                ResolvedValOut = &resolvedValOut,
                WasResolved = &wasResolved,
                LinkToProperty = &linkToProperty
            )
            |> enum<swCustomInfoGetResult_e>
        if not wasResolved || i <> swCustomInfoGetResult_e.swCustomInfoGetResult_ResolvedValue then
            swApp.SendMsgToUser "CusPropMgr.Get6"
            failwith "CusPropMgr.Get6"
        else
            valOut,resolvedValOut
    
    swApp
    |> SldWorksUtils.sendMsgToUser2
        ResValue
        swMessageBoxIcon_e.swMbInformation
        swMessageBoxBtn_e.swMbOk
    |> ignore

    // Change the value of a custom property called MyTest
    let Value = "Test has now changed!"
    let SetStatus = 
        CusPropMgr.Set2(FieldName = "MyTest", FieldValue = Value)

    // Retrieve the new value // 与第一次retrieve代码相同
    let Value,ResValue = 
        CusPropMgr
        |> CustomPropertyManagerUtils.GetUpdatedProperty "MyTest"
    
    swApp
    |> SldWorksUtils.sendMsgToUser2
        ResValue
        swMessageBoxIcon_e.swMbInformation
        swMessageBoxBtn_e.swMbOk
    |> ignore

let CustomPropertyTraversal (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2

    let CusPropMgr = swModel.Extension.CustomPropertyManager("")
    let addNumberProp name value =
        CusPropMgr.Add3(
            FieldName = name,
            FieldType = int swCustomInfoType_e.swCustomInfoNumber,
            FieldValue = value,
            OverwriteExisting = int swCustomPropertyAddOption_e.swCustomPropertyReplaceValue
        )
        |> ignore

    let _ = addNumberProp "MyProp1" "1"
    let _ = addNumberProp "MyProp2" "2"
    let _ = addNumberProp "MyProp3" "3"
    let _ = addNumberProp "MyProp4" "4"

    let names = 
        CusPropMgr.GetNames() 
        :?> obj[]
        |> Array.map (fun x -> x :?> string)
    
    names
    |> String.concat "\n"
    |> swApp.SendMsgToUser

    let Count = CusPropMgr.Count

    swApp
    |> SldWorksUtils.sendMsgToUser2
        $"You have {Count} custom properties."
        swMessageBoxIcon_e.swMbInformation
        swMessageBoxBtn_e.swMbOk
    |> ignore

let CustomPropsConfig (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2
    let docPref = DocUserPreference(swModel)

    let density = 2700.0

    docPref.swMaterialPropertyDensity swUserPreferenceOption_e.swDetailingNoOptionSpecified <- density

    let ConfigNames = 
        swModel.GetConfigurationNames()
        :?> obj[]
        |> Array.map(fun x -> x :?> string)

    ConfigNames
    |> Seq.iter(fun configname ->
        swModel.ShowConfiguration2 configname
        |> ignore

        let CusPropMgr = swModel.Extension.CustomPropertyManager(configname)

        let massprops = 
            let ok = int swMassPropertiesStatus_e.swMassPropertiesStatus_OK
            let mutable status = ok
            let arr =
                swModel.Extension.GetMassProperties2(
                    Accuracy = 1, 
                    Status = &status, 
                    UseSelected = false)
            if status <> ok then
                swApp.SendMsgToUser $"{enum<swMassPropertiesStatus_e>status}"
                [||]
            else
                arr :?> float[]

        let addTextProp name value =
            CusPropMgr.Add3(
                FieldName = name,
                FieldType = int swCustomInfoType_e.swCustomInfoText,
                FieldValue = value,
                OverwriteExisting = int swCustomPropertyAddOption_e.swCustomPropertyReplaceValue
            )
            |> ignore

        addTextProp $"Density - {configname}" 
            $"{density / 1000.0}"
        addTextProp $"Mass - {configname}" 
            $"{massprops.[5] * 1000.0}"
        addTextProp $"Volume - {configname}" 
            $"{massprops.[3] * 1000.0 * 1000.0}"
        addTextProp $"Area - {configname}" 
            $"{massprops.[4] * 100.0 * 100.0}"
    )


            ////命令
            //cmds.add(
            //    hintOrTip: "第8章",
            //    callbackFunction: nameof(this.Training8_CustomProps_main)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第8章属性遍历",
            //    callbackFunction: nameof(this.Training8_CustomPropertyTraversal)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第8章属性在配置特定",
            //    callbackFunction: nameof(this.Training8_CustomPropsConfig)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第8章文件摘要信息",
            //    callbackFunction: nameof(this.Training8_CustomFileSummary)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第8章文档特性",
            //    callbackFunction: nameof(this.Training8_DocumentAttributes)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第8章CNCDrilling",
            //    callbackFunction: nameof(this.Training8_CNCDrilling)
            //    );

        //public void Training8_CustomProps_main()
        //{
        //    CustomProps.main(this.iSwApp);
        //}

        //public void Training8_CustomPropertyTraversal()
        //{
        //    CustomProps.CustomPropertyTraversal(this.iSwApp);
        //}

        //public void Training8_CustomPropsConfig()
        //{
        //    CustomProps.CustomPropsConfig(this.iSwApp);
        //}

        //public void Training8_CustomFileSummary()
        //{
        //    CustomFileSummary.main(this.iSwApp);
        //}

        //public void Training8_DocumentAttributes()
        //{
        //    DocumentAttributes.main(this.iSwApp);
        //}

        //public void Training8_CNCDrilling()
        //{
        //    Training8.CNCDrilling.main(this.iSwApp);
        //}

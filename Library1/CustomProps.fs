module CustomProps

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

let GetUpToDateProperty (fieldName:string) (cusPropMgr:ICustomPropertyManager) =
        let mutable valOut = ""
        let mutable resolvedValOut = ""
        let mutable wasResolved = false
        let mutable linkToProperty = false
        let i =
            cusPropMgr.Get6(
                FieldName = fieldName,
                UseCached = false,
                ValOut = &valOut,
                ResolvedValOut = &resolvedValOut,
                WasResolved = &wasResolved,
                LinkToProperty = &linkToProperty
            )
            |> enum<swCustomInfoGetResult_e>
        if not wasResolved || i <> swCustomInfoGetResult_e.swCustomInfoGetResult_ResolvedValue then
            //swApp.SendMsgToUser "CusPropMgr.Get6"
            failwith "CusPropMgr.Get6"
        else
            valOut,resolvedValOut

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
        |> GetUpToDateProperty "MyTest"
    
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

    let AddStatus = addNumberProp "MyProp1" "1"
    let AddStatus = addNumberProp "MyProp2" "2"
    let AddStatus = addNumberProp "MyProp3" "3"
    let AddStatus = addNumberProp "MyProp4" "4"

    let names = 
        CusPropMgr.GetNames() 
        :?> obj[]
        |> Array.map (fun x -> x:?>string)
    
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

        //let AddStatus = CusPropMgr.Add3(, 
        //    int swCustomInfoType_e.swCustomInfoText, $"{density / 1000.0}", int swCustomPropertyAddOption_e.swCustomPropertyReplaceValue)

        //let AddStatus = CusPropMgr.Add3("Mass - " + configname, 
        //    int swCustomInfoType_e.swCustomInfoText, , int swCustomPropertyAddOption_e.swCustomPropertyReplaceValue)

        //let AddStatus = CusPropMgr.Add3("Volume - " + configname, 
        //    int swCustomInfoType_e.swCustomInfoText, $"{massprops.[3] * 1000.0 * 1000.0}", int swCustomPropertyAddOption_e.swCustomPropertyReplaceValue)

        //let AddStatus = CusPropMgr.Add3("Area - " + configname, 
        //    int swCustomInfoType_e.swCustomInfoText, $"{massprops.[4] * 100.0 * 100.0}", int swCustomPropertyAddOption_e.swCustomPropertyReplaceValue)

    )
    //for configname in retval do
    //    //swApp.SendMsgToUser2 configname, swMbInformation, swMbOk
    //    swModel.ShowConfiguration2 configname
    //    |> ignore
    //    //let massprops: Variant
    //    let mutable status = 0


    //    ()



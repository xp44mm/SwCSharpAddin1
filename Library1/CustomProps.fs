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

//let swApp: SldWorks.SldWorks
//let swModel: SldWorks.ModelDoc2
//let Value: String

let main
    (swApp: SldWorks)
    (swModel: ModelDoc2)
    =

    //Set swApp = Application.SldWorks
    //Set swModel = swApp.ActiveDoc
    let CusPropMgr = swModel.Extension.CustomPropertyManager("")
    let AddStatus = 
        CusPropMgr
        |> CustomPropertyManagerUtils.add3 
            "MyTest"
            swCustomInfoType_e.swCustomInfoText
            "This is a test."
            swCustomPropertyAddOption_e.swCustomPropertyReplaceValue

    // Retrieve the value of a custom property called MyTest
    //let _,Value,ResValue,_ = 
    let rcd =
        CusPropMgr
        |> CustomPropertyManagerUtils.get6 "MyTest" false
    
    swApp
    |> SldWorksUtils.sendMsgToUser2
        rcd.resolvedValOut
        swMessageBoxIcon_e.swMbInformation
        swMessageBoxBtn_e.swMbOk
    |> ignore

    // Change the value of a custom property called MyTest
    let Value = "Test has now changed!"
    let SetStatus = 
        CusPropMgr 
        |> CustomPropertyManagerUtils.set2 "MyTest" Value

    // Retrieve the new value
    //Value = ""
    //ResValue = ""
    let rcd = 
        CusPropMgr
        |> CustomPropertyManagerUtils.get6 "MyTest" false
        //CusPropMgr
        //.Get5()

    swApp
    |> SldWorksUtils.sendMsgToUser2
        rcd.resolvedValOut
        swMessageBoxIcon_e.swMbInformation
        swMessageBoxBtn_e.swMbOk
    |> ignore

let CustomPropertyTraversal
    (swApp: SldWorks)
    (swModel: ModelDoc2)
    =
    //Set swApp = Application.SldWorks
    //Set swModel = swApp.ActiveDoc
    let CusPropMgr = swModel.Extension.CustomPropertyManager("")

    let AddStatus = 
        CusPropMgr
        |> CustomPropertyManagerUtils.add3 
            "MyProp1"
            swCustomInfoType_e.swCustomInfoNumber
            "1"
            swCustomPropertyAddOption_e.swCustomPropertyReplaceValue

    let AddStatus = 
        CusPropMgr
        |> CustomPropertyManagerUtils.add3 
            "MyProp2"
            swCustomInfoType_e.swCustomInfoNumber
            "2"
            swCustomPropertyAddOption_e.swCustomPropertyReplaceValue

    let AddStatus = 
        CusPropMgr
        |> CustomPropertyManagerUtils.add3 
            "MyProp3"
            swCustomInfoType_e.swCustomInfoNumber
            "3"
            swCustomPropertyAddOption_e.swCustomPropertyReplaceValue

    let AddStatus = 
        CusPropMgr
        |> CustomPropertyManagerUtils.add3 
            "MyProp4"
            swCustomInfoType_e.swCustomInfoNumber
            "4"
            swCustomPropertyAddOption_e.swCustomPropertyReplaceValue

    let names = 
        CusPropMgr
        |> CustomPropertyManagerUtils.getNames

    for name in names do
        swApp
        |> SldWorksUtils.sendMsgToUser2
            name
            swMessageBoxIcon_e.swMbInformation
            swMessageBoxBtn_e.swMbOk
        |> ignore

        //swApp.SendMsgToUser2(name, int swMessageBoxIcon_e.swMbInformation, int swMessageBoxBtn_e.swMbOk)
        //|> ignore
    let Count = CusPropMgr.Count
    swApp
    |> SldWorksUtils.sendMsgToUser2
        $"You have {Count} custom properties."
        swMessageBoxIcon_e.swMbInformation
        swMessageBoxBtn_e.swMbOk
    |> ignore

let CustomPropsConfig 
    (swModel: ModelDoc2)
    (swApp: SldWorks)
    =

//let swApp: SldWorks.SldWorks
//let swModel: SldWorks.ModelDoc2
//let CusPropMgr: SldWorks.CustomPropertyManager
//let AddStatus: Long
//let retval(): String
//let i: int

    //Set swApp = Application.SldWorks
    //Set swModel = swApp.ActiveDoc
    let density = 2700.0
    //swModel
    //|> ModelDoc2Utils.setUserPreferenceDouble
    //    swUserPreferenceDoubleValue_e.swMaterialPropertyDensity
    //    swUserPreferenceOption_e.swDetailingNoOptionSpecified
    //    density
    //|> ignore

    let docPref = DocUserPreference(swModel)
    docPref.swMaterialPropertyDensity swUserPreferenceOption_e.swDetailingNoOptionSpecified <- density

    //let retval = 
    //    swModel.GetConfigurationNames()
    //    |> unbox<string[]>

    //for configname in retval do
    //    //swApp.SendMsgToUser2 configname, swMbInformation, swMbOk
    //    swModel.ShowConfiguration2 configname
    //    |> ignore
    //    //let massprops: Variant
    //    let mutable status = 0
    //    let massprops = 
    //        swModel.Extension.GetMassProperties2(1, &status, false)
    //        |> unbox<float[]>
    //    let CusPropMgr = swModel.Extension.CustomPropertyManager(configname)
    //    let AddStatus = CusPropMgr.Add3("Density - " + configname, 
    //        int swCustomInfoType_e.swCustomInfoText, $"{density / 1000.0}", int swCustomPropertyAddOption_e.swCustomPropertyReplaceValue)
    //    let AddStatus = CusPropMgr.Add3("Mass - " + configname, 
    //        int swCustomInfoType_e.swCustomInfoText, $"{massprops.[5] * 1000.0}", int swCustomPropertyAddOption_e.swCustomPropertyReplaceValue)
    //    let AddStatus = CusPropMgr.Add3("Volume - " + configname, 
    //        int swCustomInfoType_e.swCustomInfoText, $"{massprops.[3] * 1000.0 * 1000.0}", int swCustomPropertyAddOption_e.swCustomPropertyReplaceValue)
    //    let AddStatus = CusPropMgr.Add3("Area - " + configname, 
    //        int swCustomInfoType_e.swCustomInfoText, $"{massprops.[4] * 100.0 * 100.0}", int swCustomPropertyAddOption_e.swCustomPropertyReplaceValue)
    //    ()



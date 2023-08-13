module training3

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
open FSharp.SolidWorks


let systemOptions(swApp: ISldWorks) =
    swApp
    |> SldWorksUtils.setUserPreferenceToggle swUserPreferenceToggle_e.swInputDimValOnCreate true

    swApp
    |> SldWorksUtils.getUserPreferenceToggle swUserPreferenceToggle_e.swInputDimValOnCreate
    |> sprintf "%b"
    |> swApp.SendMsgToUser

    swApp
    |> SldWorksUtils.setUserPreferenceToggle swUserPreferenceToggle_e.swInputDimValOnCreate true

    swApp
    |> SldWorksUtils.setUserPreferenceDoubleValue swUserPreferenceDoubleValue_e.swDrawingDetailViewScale 1.5

    swApp
    |> SldWorksUtils.getUserPreferenceDoubleValue swUserPreferenceDoubleValue_e.swDrawingDetailViewScale
    |> sprintf "%f"
    |> swApp.SendMsgToUser

    let viewportColor = Color.FromArgb(128, 255, 128).ToArgb()
    swApp
    |> SldWorksUtils.setUserPreferenceIntegerValue swUserPreferenceIntegerValue_e.swSystemColorsViewportBackground viewportColor
    |> ignore

    swApp
    |> SldWorksUtils.getUserPreferenceIntegerValue swUserPreferenceIntegerValue_e.swSystemColorsViewportBackground
    |> sprintf "%d"
    |> swApp.SendMsgToUser

    let value = @"C:\Temp"

    swApp
    |> SldWorksUtils.setUserPreferenceStringValue swUserPreferenceStringValue_e.swBackupDirectory value
    |> ignore

    swApp
    |> SldWorksUtils.getUserPreferenceStringValue swUserPreferenceStringValue_e.swBackupDirectory
    |> swApp.SendMsgToUser

    swApp
    |> SldWorksUtils.setUserPreferenceIntegerValue
        swUserPreferenceIntegerValue_e.swEdgesHiddenEdgeDisplay
        (int swEdgesHiddenEdgeDisplay_e.swEdgesHiddenEdgeDisplayDashed)
    |> ignore

    // View Rotation - Mouse Speed
    //
    // 0 = Slow
    // 100 = Fast
    swApp
    |> SldWorksUtils.setUserPreferenceIntegerValue
        swUserPreferenceIntegerValue_e.swViewRotationMouseSpeed 50
    |> ignore

    // View Rotation - ViewAnimationSpeed
    // 0 = Off
    // 0.5 = Fast
    // 1.0
    // 1.5
    // 2.0
    // 2.5
    // 3.0 = Slow
    swApp
    |> SldWorksUtils.setUserPreferenceDoubleValue
        swUserPreferenceDoubleValue_e.swViewAnimationSpeed 2.0
    |> ignore

/// 先打开一个文档，再运行宏
let documentProperties (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc |> unbox<ModelDoc2>

    swModel
    |> ModelDoc2Utils.setUserPreferenceToggle
        swUserPreferenceToggle_e.swDetailingDualDimensions
        swUserPreferenceOption_e.swDetailingDimension
        true
    |> ignore

    swModel
    |> ModelDoc2Utils.getUserPreferenceToggle
        swUserPreferenceToggle_e.swDetailingDualDimensions
        swUserPreferenceOption_e.swDetailingDimension
    |> sprintf "%b"
    |> swApp.SendMsgToUser

// 焊件偏爱值的自动设置
let weldment (swModel: ModelDoc2) =
    let toggle (v:bool) (x:swUserPreferenceToggle_e) =
        swModel
        |> ModelDoc2Utils.setUserPreferenceToggle
            x swUserPreferenceOption_e.swDetailingNoOptionSpecified v
        |> ignore

    swUserPreferenceToggle_e.swWeldmentEnableAutomaticCutList
    |> toggle true
    swUserPreferenceToggle_e.swWeldmentEnableAutomaticUpdate
    |> toggle true
    swUserPreferenceToggle_e.swWeldmentRenameCutlistDescriptionPropertyValue
    |> toggle true
    swUserPreferenceToggle_e.swWeldmentCollectIdenticalBodies
    |> toggle true
    swUserPreferenceToggle_e.swDisableDerivedConfigurations
    |> toggle false

    ()


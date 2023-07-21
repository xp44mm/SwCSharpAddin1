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


let systemOptions(swApp: ISldWorks) =
    swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swInputDimValOnCreate, true)

    swApp.GetUserPreferenceToggle(int swUserPreferenceToggle_e.swInputDimValOnCreate)
    |> sprintf "%b"
    |> swApp.SendMsgToUser

    swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swInputDimValOnCreate, true)

    swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDrawingDetailViewScale, 1.5)
    |> ignore

    swApp.GetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e.swDrawingDetailViewScale)
    |> sprintf "%f"
    |> swApp.SendMsgToUser

    let viewportColor = Color.FromArgb(128, 255, 128).ToArgb()
    swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsViewportBackground, viewportColor)
    |> ignore

    swApp.GetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swSystemColorsViewportBackground)
    |> sprintf "%d"
    |> swApp.SendMsgToUser

    let value = @"C:\Temp"
    swApp.SetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swBackupDirectory, value)
    |> ignore

    swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swBackupDirectory)
    |> swApp.SendMsgToUser

    swApp.SetUserPreferenceIntegerValue(
        int swUserPreferenceIntegerValue_e.swEdgesHiddenEdgeDisplay,
        int swEdgesHiddenEdgeDisplay_e.swEdgesHiddenEdgeDisplayDashed)
    |> ignore
    
    // View Rotation - Mouse Speed
    //
    // 0 = Slow
    // 100 = Fast
    swApp.SetUserPreferenceIntegerValue(int swUserPreferenceIntegerValue_e.swViewRotationMouseSpeed, 50)
    |> ignore

    // View Rotation - ViewAnimationSpeed
    // 0 = Off
    // 0.5 = Fast
    // 1.0
    // 1.5
    // 2.0
    // 2.5
    // 3.0 = Slow
    swApp.SetUserPreferenceDoubleValue(int swUserPreferenceDoubleValue_e. swViewAnimationSpeed, 2.0)
    |> ignore

/// 先打开一个文档，再运行宏
let documentProperties (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc |> unbox<ModelDoc2>

    swModel.Extension.SetUserPreferenceToggle(
        int swUserPreferenceToggle_e.swDetailingDualDimensions,
        int swUserPreferenceOption_e.swDetailingDimension,
        true)
    |> ignore

    swModel.Extension.GetUserPreferenceToggle(
        int swUserPreferenceToggle_e.swDetailingDualDimensions,
        int swUserPreferenceOption_e.swDetailingDimension
        )
    |> sprintf "%b"
    |> swApp.SendMsgToUser




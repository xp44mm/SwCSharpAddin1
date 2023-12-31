﻿module training3

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
    let sysPref = SwUserPreference(swApp)

    sysPref.swInputDimValOnCreate <- true

    sysPref.swInputDimValOnCreate
    |> sprintf "%b"
    |> swApp.SendMsgToUser

    sysPref.swDrawingDetailViewScale <- 1.5

    sysPref.swDrawingDetailViewScale
    |> sprintf "%f"
    |> swApp.SendMsgToUser

    let viewportColor = Color.FromArgb(128, 255, 128).ToArgb()

    sysPref.swSystemColorsViewportBackground <- viewportColor

    sysPref.swSystemColorsViewportBackground
    |> sprintf "%d"
    |> swApp.SendMsgToUser

    let value = @"C:\Temp"

    sysPref.swBackupDirectory <- value

    sysPref.swBackupDirectory
    |> swApp.SendMsgToUser

    sysPref.swEdgesHiddenEdgeDisplay <- int swEdgesHiddenEdgeDisplay_e.swEdgesHiddenEdgeDisplayDashed


    // View Rotation - Mouse Speed
    //
    // 0 = Slow
    // 100 = Fast
    //swApp
    //|> SldWorksUtils.setUserPreferenceIntegerValue
    //    swUserPreferenceIntegerValue_e.swViewRotationMouseSpeed 50
    //|> ignore

    sysPref.swViewRotationMouseSpeed <- 50

    sysPref.swViewRotationMouseSpeed
    |> sprintf "swViewRotationMouseSpeed:%d"
    |> swApp.SendMsgToUser

    // View Rotation - ViewAnimationSpeed
    // 0 = Off
    // 0.5 = Fast
    // 1.0
    // 1.5
    // 2.0
    // 2.5
    // 3.0 = Slow
    sysPref.swViewAnimationSpeed <- 2.0

    sysPref.swViewAnimationSpeed <- 2.0

    sysPref.swViewAnimationSpeed
    |> sprintf "swViewAnimationSpeed:%f"
    |> swApp.SendMsgToUser

/// 先打开一个文档，再运行宏
let documentProperties (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> ModelDoc2

    let docPref = DocUserPreference(swModel)

    docPref.swDetailingDualDimensions(swUserPreferenceOption_e.swDetailingDimension) <- true

    docPref.swDetailingDualDimensions(swUserPreferenceOption_e.swDetailingDimension)
    |> sprintf "%b"
    |> swApp.SendMsgToUser


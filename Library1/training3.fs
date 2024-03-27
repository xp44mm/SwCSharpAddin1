module training3 //Setting System Options and Document Defaults

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
    let sysPref = SysUserPreference(swApp)

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




////命令
//cmds.add(
//    hintString: "第3章之系统选项",
//    toolTip: "",
//    callbackFunction: nameof(this.Training3_systemOptions),
//    enableMethod: nameof(this.Always),
//    menuTBOption: swCommandItemType_e.swMenuItem
//    );

////命令
//cmds.add(
//    hintString: "第3章之文档属性",
//    toolTip: "",
//    callbackFunction: nameof(this.Training3_documentProperties),
//    enableMethod: nameof(this.Always),
//    menuTBOption: swCommandItemType_e.swMenuItem
//    );

//public void Training3_systemOptions()
//{
//    training3.systemOptions(this.iSwApp);
//}

//public void Training3_documentProperties()
//{
//    training3.documentProperties(this.iSwApp);
//}

module training2_existingDocs

open System
open System.Runtime.InteropServices
open System.Collections
open System.Collections.Generic
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

let TRAININGDIR = @"D:\崔胜利\My SolidWorks\API Fundamentals"
let TEMPLATEDIR = @"D:\崔胜利\My SolidWorks\Training Templates"
let FILEDIR = @"D:\崔胜利\My SolidWorks\API Fundamentals\Lesson02 - Object Model Basics\Case Study"

let connectToSolidWorks (swApp: ISldWorks) =
    let partDoc =
        {
            FileName = Path.Combine(FILEDIR, "Sample.SLDPRT")
            Type = swDocumentTypes_e.swDocPART
            Options = swOpenDocOptions_e.swOpenDocOptions_Silent
            Configuration = ""
        }.openDoc(swApp)

    // check loadFile4
    let ImportedModelDoc =
        let path = Path.Combine(FILEDIR, "Sample.igs")
        swApp
        |> SldWorksUtils.loadFile4 path "" null

    // check CreateNewWindow
    swApp.CreateNewWindow()
    swApp.ArrangeWindows 1
    ()

// 需要先打开一个文件
let ToolbarAndCustomProperty (swApp: ISldWorks) =
    let swModel = 
        swApp.ActiveDoc :?> IModelDoc2

    let toolbars =
        [
            swToolbar_e.swFeatureToolbar
            swToolbar_e.swMacroToolbar
            swToolbar_e.swMainToolbar
            swToolbar_e.swSketchToolbar
            swToolbar_e.swSketchToolsToolbar
            swToolbar_e.swStandardToolbar
            swToolbar_e.swStandardViewsToolbar
            swToolbar_e.swViewToolbar
        ]

    toolbars
    |> Seq.iter(fun tb ->
        swModel
        |> ModelDoc2Utils.setToolbarVisibility tb false
    )

    swModel.Extension.CustomPropertyManager("").Add3(
        FieldName = "MyInfo",
        FieldType = int swCustomInfoType_e.swCustomInfoText,
        FieldValue = "MyData",
        OverwriteExisting = int swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd
    )
    |> ignore

//注意：源零件不能只有焊件
let MirrorPart (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2
    let swPart = swApp.ActiveDoc :?> IPartDoc

    //执行之前保存原文件名
    let partname = swModel.GetTitle() // sheetmetalsample.SLDPRT

    let x = 
        swModel
        |> ModelDoc2Utils.selectByID2 "Top" "PLANE" (0.0,0.0,0.0) false 0 swSelectOption_e.swSelectOptionDefault

    let mirFeat,mirModel =
        swPart
        |> PartDocUtils.mirrorPart2 false swMirrorPartOptions_e.swMirrorPartOptions_ImportSolids

    mirModel.ShowNamedView2("*Isometric", 7)
    mirModel.ViewZoomtofit2()

    swApp.ArrangeWindows 1

    // 重新选中源文件
    let swModel =
        swApp
        |> SldWorksUtils.activateDoc3 partname false swRebuildOnActivation_e.swRebuildActiveDoc
        :?> ModelDoc2

    let _ = 
        swModel
        |> ModelDoc2Utils.deSelectByID "Top" "PLANE" (0.0, 0.0, 0.0)
    ()
// 打开 sheetmetalsample
let InsertCavity (swApp: ISldWorks) =
    let swModel = 
        swApp.ActiveDoc :?> IModelDoc2

    let swAssy = 
        swApp.ActiveDoc :?> IAssemblyDoc

    let assyname = Path.GetFileNameWithoutExtension(swModel.GetTitle())
    
    // EditPart2 sheetmetalsample-1
    let boolstatus =
        swModel
        |> ModelDoc2Utils.selectByID2 $"sheetmetalsample-1@{assyname}" "COMPONENT" (0., 0., 0.)
            false 0 swSelectOption_e.swSelectOptionDefault

    let status = 
        swAssy
        |> AssemblyDocUtils.editPart2 true false

    // InsertCavity4 plug-1
    swModel.ClearSelection2 true

    let boolstatus =
        swModel
        |> ModelDoc2Utils.selectByID2 $"plug-1@{assyname}" "COMPONENT" (0., 0., 0.)
            false 0 swSelectOption_e.swSelectOptionDefault

    swAssy.InsertCavity4(10, 10, 10, true, 1, -1)

    // EditSuppress2 plug-1
    swAssy.EditAssembly()
    let _ =
        swModel
        |> ModelDoc2Utils.selectByID2 "plug-1@sheetmetalsample" "COMPONENT" (0., 0., 0.)
            false 0 swSelectOption_e.swSelectOptionDefault

    swModel.EditSuppress2()
    |> ignore

open System.Drawing

let CreateLayer (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2
    let swDraw = swApp.ActiveDoc :?> IDrawingDoc

    swModel.ClearSelection2 true
    let retval = 
        swDraw.CreateLayer2(
            Layername  = "MyRedLayer", 
            LayerDesc  = "Red", 
            LayerColor = Color.FromArgb(255, 0, 0).ToArgb(),
            LayerStyle = int swLineStyles_e.swLineSTITCH, 
            LayerWidth = int swLineWeights_e.swLW_THICK, 
            BOn        = true, 
            BPrint     = true)
    ()








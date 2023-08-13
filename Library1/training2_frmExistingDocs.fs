module training2_frmExistingDocs

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

let TRAININGDIR = @"C:\Users\cuisl\Documents\"
let TEMPLATEDIR = @"C:\ProgramData\SOLIDWORKS\SOLIDWORKS 2022\templates\"

let partpath = Path.Combine(TRAININGDIR, "cstick.SLDPRT")

let cmdConnect_Click (swApp: ISldWorks) =

    //If chkOpen.Value = True Then
    let _ =
        swApp
        |> SldWorksUtils.openDoc6 partpath
            swDocumentTypes_e.swDocPART 
            swOpenDocOptions_e.swOpenDocOptions_Silent
            ""

    //If chkLoad.Value = True Then
    //let mutable errors = 0
    let ImportedModelDoc =
        let path = Path.Combine(TRAININGDIR, "cstick.igs")
        swApp
        |> SldWorksUtils.loadFile4 path "" null

    //If chkNewWindow.Value = True Then
    swApp.CreateNewWindow()
    swApp.ArrangeWindows 1

let cmdNewModel_Click(swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc |> unbox<IModelDoc2>
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

    let custPropMan = swModel.Extension.CustomPropertyManager("")
    let _ = 
        custPropMan
        |> CustomPropertyManagerUtils.add3
            "MyInfo" swCustomInfoType_e.swCustomInfoText
            "MyData" swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd
    ()

//注意：源零件不能只有焊件
let cmdPart_Click(swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc |> unbox<IModelDoc2>
    let swPart = swModel :?> IPartDoc

    //执行之前保存原文件名
    let partname = swModel.GetTitle()

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
        |> unbox<ModelDoc2>

    let _ = 
        swModel
        |> ModelDoc2Utils.deSelectByID "Top" "PLANE" (0.0, 0.0, 0.0)
    ()

let cmdAssy_Click(swApp: ISldWorks) =
    let swModel = 
        swApp.ActiveDoc
        |> unbox<ModelDoc2>

    let swAssy = 
        swModel :?> AssemblyDoc

    let assyname = Path.GetFileNameWithoutExtension(swModel.GetTitle())
    
    // EditPart2 sheetmetalsample-1
    let boolstatus =
        swModel
        |> ModelDoc2Utils.selectByID2 $"sheetmetalsample-1@{assyname}" "COMPONENT" (0., 0., 0.)
            false 0 swSelectOption_e.swSelectOptionDefault

    let status = 
        //let mutable info = 0
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

let cmdDraw_Click (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc |> unbox<ModelDoc2>
    let swDraw = swModel :?> DrawingDoc

    swModel.ClearSelection2 true
    let retval = 
        swDraw.CreateLayer2("MyRedLayer", "Red", Color.FromArgb(255, 0, 0).ToArgb(),
        int swLineStyles_e.swLineSTITCH, int swLineWeights_e.swLW_THICK, true, true)
    ()

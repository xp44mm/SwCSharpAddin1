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


let TRAININGDIR = @"C:\Users\cuisl\Documents\"
let TEMPLATEDIR = @"C:\ProgramData\SOLIDWORKS\SOLIDWORKS 2022\templates\"

let partpath = Path.Combine(TRAININGDIR, "cstick.SLDPRT")

let cmdConnect_Click (swApp: ISldWorks) =

    //If chkOpen.Value = True Then
    let mutable fileerror = 0
    let mutable filewarning = 0
    let _ =
        swApp.OpenDoc6(partpath, int swDocumentTypes_e.swDocPART, int swOpenDocOptions_e.swOpenDocOptions_Silent, "", &fileerror, &filewarning)

    //If chkLoad.Value = True Then
    let mutable errors = 0
    let ImportedModelDoc =
        swApp.LoadFile4(Path.Combine(TRAININGDIR, "cstick.igs"), "", null, &errors)

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
        swModel.SetToolbarVisibility(int tb,false)
    )

    let custPropMan = swModel.Extension.CustomPropertyManager("")
    let _ = custPropMan.Add3("MyInfo", int swCustomInfoType_e.swCustomInfoText, "MyData", int swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd)
    ()

//注意：源零件不能只有焊件
let cmdPart_Click(swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc |> unbox<IModelDoc2>
    let swPart = swModel :?> IPartDoc

    //执行之前保存原文件名
    let partname = swModel.GetTitle()


    let _ = swModel.Extension.SelectByID2("Top", "PLANE", 0, 0, 0, false, 0, null, 0)

    let mirFeat,mirModel =
        swPart.MirrorPart2(false,int swMirrorPartOptions_e.swMirrorPartOptions_ImportSolids)

    mirModel.ShowNamedView2("*Isometric", 7)
    mirModel.ViewZoomtofit2()

    swApp.ArrangeWindows 1

    // 重新选中源文件
    let swModel =
        let mutable errors = 0
        swApp.ActivateDoc3(partname, false,int swRebuildOnActivation_e.swRebuildActiveDoc, &errors)
        |> unbox<ModelDoc2>

    let _ = swModel.DeSelectByID("Top", "PLANE", 0.0, 0.0, 0.0)
    ()

let cmdAssy_Click(swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc |> unbox<ModelDoc2>
    let swAssy = swModel :?> AssemblyDoc

    let assyname = Path.GetFileNameWithoutExtension(swModel.GetTitle())
    
    // EditPart2 sheetmetalsample-1
    let boolstatus =
        swModel.Extension.SelectByID2(
        $"sheetmetalsample-1@{assyname}", "COMPONENT", 0, 0, 0, 
        false, 0, null, 0)

    let mutable info = 0
    let _ = swAssy.EditPart2(true, false, &info)

    // InsertCavity4 plug-1
    swModel.ClearSelection2 true

    let boolstatus =
        swModel.Extension.SelectByID2(
        $"plug-1@{assyname}", "COMPONENT", 0, 0, 0, 
        true, 0, null, 0)

    swAssy.InsertCavity4(10, 10, 10, true, 1, -1)

    // EditSuppress2 plug-1
    swAssy.EditAssembly()
    let _ =
        swModel.Extension.SelectByID2(
        "plug-1@sheetmetalsample", "COMPONENT", 0, 0, 0, 
        true, 0, null, 0)

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

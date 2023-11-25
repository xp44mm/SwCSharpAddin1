module training2

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

let connectToSolidWorks (swApp: ISldWorks) =
    swApp.SendMsgToUser $"RevisionNumber:{swApp.RevisionNumber}"

    swApp.DisplayStatusBar true
    //swApp.SendMsgToUser $"DisplayStatusBar Ok!"

    let lang = swApp.GetCurrentLanguage()
    swApp.SendMsgToUser $"SOLIDWORKS is currently using the {lang} language."

let TRAININGDIR = @"D:\崔胜利\My SolidWorks\API Fundamentals"
let TEMPLATEDIR = @"D:\崔胜利\My SolidWorks\Training Templates"
let FILEDIR = @"D:\崔胜利\My SolidWorks\API Fundamentals\Lesson02 - Object Model Basics\Case Study"

let sampleNote (text) (swModel: ModelDoc2) =
    let swNote =
        swModel.InsertNote(text)
        |> unbox<INote>

    let swAnnotation =
        swNote.GetAnnotation()
        |> unbox<IAnnotation>

    swAnnotation.SetPosition(0.01, 0.01, 0.0)
    |> ignore

let NewModel_Part (swApp: ISldWorks) =
    let swModel =
        let tmpl = Path.Combine(TEMPLATEDIR, "Part_MM.prtdot")
        swApp
        |> SldWorksUtils.newDocument tmpl swDwgPaperSizes_e.swDwgPaperAsize 0.0 0.0

    swModel.InsertFamilyTableNew()

    swApp.SendMsgToUser "InsertFamilyTableNew"

    let text = "Sample Note"
    sampleNote text swModel
    swApp.SendMsgToUser text
    ()

let NewModel_ASM (swApp: ISldWorks) =
    let swModel =
        let tmpl = Path.Combine(TEMPLATEDIR, "Assembly_MM.asmdot")
        swApp
        |> SldWorksUtils.newDocument tmpl swDwgPaperSizes_e.swDwgPaperAsize 0.0 0.0

    swModel.InsertFamilyTableNew()

    swApp.SendMsgToUser "InsertFamilyTableNew"

    let text = "Sample Note"
    sampleNote text swModel
    swApp.SendMsgToUser text

let NewModel_DRW (swApp: ISldWorks) =
    let swModel =
        let tmpl = Path.Combine(TEMPLATEDIR, "B_Size_ANSI_MM.drwdot")
        swApp
        |> SldWorksUtils.newDocument tmpl swDwgPaperSizes_e.swDwgPaperAsize 0.0 0.0

    (swModel:?> DrawingDoc).EditSheet()

    let drawName = swModel.GetTitle()
    let partDoc =
        let filename = Path.Combine(FILEDIR ,"BlockwithDesignTable.SLDPRT")
        swApp
        |> SldWorksUtils.openDoc6 filename swDocumentTypes_e.swDocPART swOpenDocOptions_e.swOpenDocOptions_Silent ""

    let partName = partDoc.GetTitle()

    let swDrw =
        swApp
        |> SldWorksUtils.activateDoc3 drawName false swRebuildOnActivation_e.swRebuildActiveDoc
        :?> DrawingDoc

    let preparedrawingView() =
        swDrw.CreateDrawViewFromModelView3(partName,"*Isometric", 0.1, 0.1, 0.0)

    let swView = preparedrawingView()
    swView.FocusLocked <- true

    swModel
    |> ModelDoc2Utils.selectByID2(swView.GetName2()) "DRAWINGVIEW" (0.0,0.0,0.0) false 0 swSelectOption_e.swSelectOptionDefault

    swModel.InsertFamilyTableNew()

    let text = "Sample Note"
    sampleNote text swModel

    ()

let cmdPart_Click (swApp: ISldWorks) =
    let swModel =
        let tmpl = Path.Combine(TEMPLATEDIR, "gb_part.prtdot")
        swApp
        |> SldWorksUtils.newDocument tmpl swDwgPaperSizes_e.swDwgPaperAsize 0.0 0.0

    let swPart = swModel :?> IPartDoc

    swModel.SketchManager.InsertSketch true
    let _ = swModel.SketchManager.CreateCornerRectangle(0, 0, 0, 0.1, 0.1, 0)
    let _ = swModel.FeatureManager.FeatureExtrusion2( true, false,
        false, 0, 0, 0.1, 0.01, false, false, false, false,
        0.01745329251994, 0.01745329251994, false, false,
        false, false, true, true, true, 0, 0, false)

    swPart.EditRollback()

let cmdAssy_Click (swApp: ISldWorks) =
    let _ =

        swApp
        |>SldWorksUtils.openDoc6 "" swDocumentTypes_e.swDocPART swOpenDocOptions_e.swOpenDocOptions_Silent ""

    let swModel =
        let temp = Path.Combine(TEMPLATEDIR, "gb_assembly.asmdot")

        swApp
        |> SldWorksUtils.newDocument temp swDwgPaperSizes_e.swDwgPaperAsize 0.0 0.0

    let swAssy = swModel :?> IAssemblyDoc

    let _ =
        swAssy
        |> AssemblyDocUtils.addComponent5 
            "" 
            swAddComponentConfigOptions_e.swAddComponentConfigOptions_CurrentSelectedConfig
             "" false "" (0.0, 0.0, 0.0)
    ()

let cmdDraw_Click (swApp: ISldWorks) =

    let swDrw =
        let tmpl = Path.Combine(TEMPLATEDIR, "gb_a1.drwdot")
        swApp
        |> SldWorksUtils.newDocument tmpl swDwgPaperSizes_e.swDwgPaperAsize 0.0 0.0
        :?> DrawingDoc

    let msg =
        if swDrw.GetEditSheet() then
            "sheet"
        else "template"

    swApp.SendMsgToUser msg
    //swDrw.EditTemplate()
    //swDrw.EditSheet()
    ()

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

let TRAININGDIR = @"D:\崔胜利\My SolidWorks\solidworks trainings\SOLIDWORKS Training Files\API Fundamentals\Lesson02 - Object Model Basics\Case Study"
let TEMPLATEDIR = @"C:\ProgramData\SOLIDWORKS\SOLIDWORKS 2022\templates\"
let FILEDIR = TRAININGDIR + @"Lesson02 - Object Model Basics\Case Study\"
let partpath = @"C:\Users\cuisl\Documents\cstick.SLDPRT"


let cmdConnect (swApp: ISldWorks) =
    swApp.SendMsgToUser $"RevisionNumber:{swApp.RevisionNumber}"

    swApp.DisplayStatusBar true
    swApp.SendMsgToUser $"DisplayStatusBar Ok!"

    let lang = swApp.GetCurrentLanguage()
    swApp.SendMsgToUser $"SOLIDWORKS is currently using the {lang} language."

let sampleNote (text) (swModel: ModelDoc2) =
    let swNote =
        swModel.InsertNote(text)
        |> unbox<INote>
    let swAnnotation =
        swNote.GetAnnotation()
        |> unbox<IAnnotation>

    swAnnotation.SetPosition(0.01, 0.01, 0.0)
    |> ignore

let cmdNewModel_Part (swApp: ISldWorks) =

    let swModel =
        let tmpl = Path.Combine(TEMPLATEDIR, "gb_part.prtdot")
        swApp
        |> SldWorksUtils.newDocument tmpl swDwgPaperSizes_e.swDwgPaperAsize 0.0 0.0

    swModel.InsertFamilyTableNew()

    swApp.SendMsgToUser "InsertFamilyTableNew"

    let text = "Sample Note"
    sampleNote text swModel
    swApp.SendMsgToUser text

let cmdNewModel_ASM (swApp: ISldWorks) =
    let swModel =
        let tmpl = Path.Combine(TEMPLATEDIR, "gb_assembly.asmdot")
        swApp
        |> SldWorksUtils.newDocument tmpl swDwgPaperSizes_e.swDwgPaperAsize 0.0 0.0

    swModel.InsertFamilyTableNew()

    swApp.SendMsgToUser "InsertFamilyTableNew"

    let text = "Sample Note"
    sampleNote text swModel
    swApp.SendMsgToUser text

let cmdNewModel_DRW (swApp: ISldWorks) =
    let swModel =
        let tmpl = Path.Combine(TEMPLATEDIR, "gb_a1.drwdot")
        swApp
        |> SldWorksUtils.newDocument tmpl swDwgPaperSizes_e.swDwgPaperAsize 0.0 0.0

    let drawname = swModel.GetTitle()
    let partpath = @"C:\Users\cuisl\Documents\cstick.SLDPRT"

    let _ =
        swApp
        |> SldWorksUtils.openDoc6 partpath swDocumentTypes_e.swDocPART swOpenDocOptions_e.swOpenDocOptions_Silent ""

    let swDrw =
        swApp
        |> SldWorksUtils.activateDoc3 drawname false swRebuildOnActivation_e.swRebuildActiveDoc
        :?> DrawingDoc

    swDrw.EditSheet()

    let preparedrawingView() =
        swDrw.CreateDrawViewFromModelView3(partpath,"*Isometric", 0.1, 0.1, 0.0)

    let swView = preparedrawingView()

    swView.FocusLocked <- true

    swModel
    |> ModelDoc2Utils.selectByID2(swView.GetName2()) "DRAWINGVIEW" (0.0,0.0,0.0) false 0 swSelectOption_e.swSelectOptionDefault

    swModel.InsertFamilyTableNew()
    swApp.SendMsgToUser "InsertFamilyTableNew"

    let text = "Sample Note"
    sampleNote text swModel
    swApp.SendMsgToUser text

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
        |>SldWorksUtils.openDoc6(partpath) swDocumentTypes_e.swDocPART swOpenDocOptions_e.swOpenDocOptions_Silent ""

    let swModel =
        let temp = Path.Combine(TEMPLATEDIR, "gb_assembly.asmdot")

        swApp
        |> SldWorksUtils.newDocument temp swDwgPaperSizes_e.swDwgPaperAsize 0.0 0.0

    let swAssy = swModel :?> IAssemblyDoc

    let _ =
        swAssy
        |> AssemblyDocUtils.addComponent5 
            partpath 
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
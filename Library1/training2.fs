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

let cmdNewModel_Part (swApp: ISldWorks) =

    let swModel =
        swApp.NewDocument(Path.Combine(TEMPLATEDIR, "gb_part.prtdot"), 0, 0.0, 0.0)
        |> unbox<IModelDoc2>

    swModel.InsertFamilyTableNew()

    swApp.SendMsgToUser "InsertFamilyTableNew"

    let text = "Sample Note"
    let swNote =
        swModel.InsertNote(text)
        |> unbox<INote>
    let swAnnotation =
        swNote.GetAnnotation()
        |> unbox<IAnnotation>

    swAnnotation.SetPosition(0.01, 0.01, 0.0)
    |> ignore

    swApp.SendMsgToUser "Note"


let cmdNewModel_ASM (swApp: ISldWorks) =

    let swModel =
        swApp.NewDocument(Path.Combine(TEMPLATEDIR, "gb_assembly.asmdot"), 0, 0.0, 0.0)
        |> unbox<IModelDoc2>

    swModel.InsertFamilyTableNew()

    swApp.SendMsgToUser "InsertFamilyTableNew"

    let text = "Sample Note"
    let swNote =
        swModel.InsertNote(text)
        |> unbox<INote>
    let swAnnotation =
        swNote.GetAnnotation()
        |> unbox<IAnnotation>
    swAnnotation.SetPosition(0.01, 0.01, 0.0)
    |> ignore

    swApp.SendMsgToUser text


let cmdNewModel_DRW (swApp: ISldWorks) =
    let swModel =
        swApp.NewDocument(Path.Combine(TEMPLATEDIR, "gb_a1.drwdot"), 0, 0.0, 0.0)
        |> unbox<IModelDoc2>
    let drawname = swModel.GetTitle()
    let partpath = @"C:\Users\cuisl\Documents\cstick.SLDPRT"

    let _ =
        let mutable errors = 0
        let mutable warnings = 0
        swApp.OpenDoc6(partpath, 1, 0, "", &errors, &warnings)

    let swDrw =
        let mutable errors = 0
        swApp.ActivateDoc3(drawname, false,int swRebuildOnActivation_e.swRebuildActiveDoc, &errors)
        |> unbox<IDrawingDoc>

    swDrw.EditSheet()

    let preparedrawingView() =
        swDrw.CreateDrawViewFromModelView3(partpath,"*Isometric", 0.1, 0.1, 0.0)

    let swView = preparedrawingView()

    swView.FocusLocked <- true

    swModel.Extension.SelectByID2(swView.GetName2(), "DRAWINGVIEW", 0, 0, 0, false, 0, null, int swSelectOption_e.swSelectOptionDefault)
    |> ignore

    swModel.InsertFamilyTableNew()
    swApp.SendMsgToUser "InsertFamilyTableNew"

    let text = "Sample Note"
    let swNote =
        swModel.InsertNote(text)
        |> unbox<INote>
    let swAnnotation =
        swNote.GetAnnotation()
        |> unbox<IAnnotation>
    swAnnotation.SetPosition(0.01, 0.01, 0.0)
    |> ignore

    swApp.SendMsgToUser text

let cmdPart_Click (swApp: ISldWorks) =
    let swModel =
        swApp.NewDocument(Path.Combine(TEMPLATEDIR, "gb_part.prtdot"), 0, 0.0, 0.0)
        |> unbox<IModelDoc2>

    let swPart = swModel :?> IPartDoc

    swModel.SketchManager.InsertSketch true
    let _ = swModel.SketchManager.CreateCornerRectangle(0, 0, 0, 0.1, 0.1, 0)
    let _ = swModel.FeatureManager.FeatureExtrusion2( true, false,
        false, 0, 0, 0.1, 0.01, false, false, false, false,
        0.01745329251994, 0.01745329251994, false, false,
        false, false, true, true, true, 0, 0, false)

    swPart.EditRollback()

let cmdAssy_Click (swApp: ISldWorks) =
    let mutable fileerror = 0
    let mutable filewarning = 0
    let _ =
        swApp.OpenDoc6(partpath, int swDocumentTypes_e.swDocPART, int swOpenDocOptions_e.swOpenDocOptions_Silent, "", &fileerror, &filewarning)

    let swModel=
        swApp.NewDocument(Path.Combine(TEMPLATEDIR, "gb_assembly.asmdot"), 0, 0.0, 0.0)
        |> unbox<IModelDoc2>
    let swAssy = swModel :?> IAssemblyDoc
    let _ =
        swAssy.AddComponent5(partpath,int swAddComponentConfigOptions_e.swAddComponentConfigOptions_CurrentSelectedConfig, "", false, "", 0.0, 0.0, 0.0)
    ()

let cmdDraw_Click (swApp: ISldWorks) =
    let swDrw =
        swApp.NewDocument(Path.Combine(TEMPLATEDIR, "gb_a1.drwdot"), 0, 0.0, 0.0)
        |> unbox<IDrawingDoc>
    let msg =
        if swDrw.GetEditSheet() then
            "sheet"
        else "template"
    swApp.SendMsgToUser msg
    //swDrw.EditTemplate()
    //swDrw.EditSheet()
    ()
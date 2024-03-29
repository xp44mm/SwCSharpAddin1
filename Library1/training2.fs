﻿module training2

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

open Dir

let FILEDIR = Path.Combine(TRAININGDIR, @"Lesson02 - Object Model Basics\Case Study")

let connectToSolidWorks (swApp: ISldWorks) =
    swApp.SendMsgToUser $"RevisionNumber:{swApp.RevisionNumber}"

    swApp.DisplayStatusBar true
    //swApp.SendMsgToUser $"DisplayStatusBar Ok!"

    let lang = swApp.GetCurrentLanguage()
    swApp.SendMsgToUser $"SOLIDWORKS is currently using the {lang} language."

let sampleNote (text) (swModel: ModelDoc2) =
    let swNote =
        swModel.InsertNote(text)
        :?> INote

    let swAnnotation =
        swNote.GetAnnotation()
        :?> IAnnotation

    swAnnotation.SetPosition(0.01, 0.01, 0.0)
    |> ignore

let NewModel_Part (swApp: ISldWorks) =
    let swModel =
        let tmpl = Path.Combine(TEMPLATEDIR, "Part_MM.prtdot")
        swApp.NewDocument(tmpl, 0, 0.0, 0.0)
        :?> ModelDoc2

    swModel.InsertFamilyTableNew()
    swApp.SendMsgToUser "InsertFamilyTableNew"

    let text = "Sample Note"
    sampleNote text swModel
    swApp.SendMsgToUser text

let NewModel_ASM (swApp: ISldWorks) =
    let swModel =
        let tmpl = Path.Combine(TEMPLATEDIR, "Assembly_MM.asmdot")
        swApp.NewDocument(tmpl, 0, 0.0, 0.0)
        :?> ModelDoc2

    swModel.InsertFamilyTableNew()

    swApp.SendMsgToUser "InsertFamilyTableNew"

    let text = "Sample Note"
    sampleNote text swModel
    swApp.SendMsgToUser text

// 实际编程时，可以先打开零件，再打开图纸，避免从图纸切换到零件，又切换回图纸。
let NewModel_DRW (swApp: ISldWorks) =
    let swModel =
        let tmpl = Path.Combine(TEMPLATEDIR, "B_Size_ANSI_MM.drwdot")
        swApp.NewDocument(tmpl, int swDwgPaperSizes_e.swDwgPaperAsize, 0.0, 0.0)
        :?> ModelDoc2

    let drawName = swModel.GetTitle()
    let partDoc =
        {
            FileName = Path.Combine(FILEDIR, "BlockwithDesignTable.SLDPRT")
            Type = swDocumentTypes_e.swDocPART
            Options = swOpenDocOptions_e.swOpenDocOptions_Silent
            Configuration = ""
        }.openDoc(swApp)

    let partName = partDoc.GetTitle()

    let swDrw =
        swApp
        |> SldWorksUtils.activateDoc3 drawName false swRebuildOnActivation_e.swRebuildActiveDoc
        :?> DrawingDoc

    swDrw.EditSheet()

    let preparedrawingView() =
        swDrw.CreateDrawViewFromModelView3(partName,"*Isometric", 0.1, 0.1, 0.0)

    let swView = preparedrawingView()
    swView.FocusLocked <- true

    swModel
    |> ModelDoc2Utils.selectByID2(swView.GetName2()) "DRAWINGVIEW" (0.0,0.0,0.0) false 0 swSelectOption_e.swSelectOptionDefault

    swModel.InsertFamilyTableNew()

    let text = "Sample Note"
    sampleNote text swModel

let NewPartDoc (swApp: ISldWorks) =
    let swModel =
        let tmpl = Path.Combine(TEMPLATEDIR, "Part_MM.prtdot")
        swApp
        |> SldWorksUtils.newDocument tmpl swDwgPaperSizes_e.swDwgPaperAsize (0.0, 0.0)

    let swPart = swModel :?> IPartDoc

    swModel.SketchManager.InsertSketch true

    //swModel.SketchManager.CreateCornerRectangle(0, 0, 0, 0.1, 0.1, 0)
    swModel.SketchManager
    |> SketchManagerUtils.createCornerRectangle (0.0, 0.0, 0.0) (0.1, 0.1, 0.0) 
    |> ignore

    swModel.FeatureManager.FeatureExtrusion3(
        Sd                = true, 
        Flip              = false,
        Dir               = false, 
        T1                = 0, 
        T2                = 0, 
        D1                = 0.1, 
        D2                = 0.01, 
        Dchk1             = false, 
        Dchk2             = false, 
        Ddir1             = false, 
        Ddir2             = false,
        Dang1             = 0.01745329251994,
        Dang2             = 0.01745329251994,
        OffsetReverse1    = false, 
        OffsetReverse2    = false,
        TranslateSurface1 = false, 
        TranslateSurface2 = false, 
        Merge             = true, 
        UseFeatScope      = true, 
        UseAutoSelect     = true, 
        T0                = 0, 
        StartOffset       = 0, 
        FlipStartOffset   = false)
    |> ignore

    swPart.EditRollback()

let NewAssemblyDoc (swApp: ISldWorks) =
    let partDoc =
        {
            FileName = Path.Combine(FILEDIR, "Sample.SLDPRT")   
            Type = swDocumentTypes_e.swDocPART
            Options = swOpenDocOptions_e.swOpenDocOptions_Silent
            Configuration = ""
        }.openDoc(swApp)
            
    let swAssy = 
        let temp = Path.Combine(TEMPLATEDIR,"Assembly_MM.asmdot")
        swApp 
        |> SldWorksUtils.newDocument temp swDwgPaperSizes_e.swDwgPaperAsize (0.0, 0.0)
        :?> IAssemblyDoc

    {
        CompName = partDoc.GetTitle()
        ConfigOption = AddComponentConfigOptions.CurrentSelectedConfig
        MaybeUseConfigForPartReferences = None
        CompCenter = 0.0, 0.0, 0.0
    }.AddComponent5 swAssy
    |> ignore

let NewDrawingDoc (swApp: ISldWorks) =
    let swDrw =
        let tmpl = Path.Combine(TEMPLATEDIR, "B_Size_ANSI_MM.drwdot")
        swApp
        |> SldWorksUtils.newDocument tmpl swDwgPaperSizes_e.swDwgPaperAsize (0.0, 0.0)
        :?> IDrawingDoc

    //let msg =
    //    if swDrw.GetEditSheet() then
    //        "sheet"
    //    else "template"

    //swApp.SendMsgToUser msg
    //swDrw.EditTemplate()
    swDrw.EditSheet()
    ()
    
            ////命令
            //cmds.add(
            //    hintString: "connect to sw",
            //    toolTip: "图2-7",
            //    callbackFunction: nameof(this.Training2_3),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "new part",
            //    toolTip: "图2-12",
            //    callbackFunction: nameof(this.Training2_NewModel_Part),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "new assy",
            //    toolTip: "图2-12",
            //    callbackFunction: nameof(this.Training2_NewModel_ASM),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "new drw",
            //    toolTip: "图2-12",
            //    callbackFunction: nameof(this.Training2_NewModel_DRW),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "New PartDoc",
            //    toolTip: "图2-18",
            //    callbackFunction: nameof(this.Training2_NewPartDoc),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "New AssemblyDoc",
            //    toolTip: "图2-18",
            //    callbackFunction: nameof(this.Training2_NewAssemblyDoc),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintString: "New DrawingDoc",
            //    toolTip: "图2-18",
            //    callbackFunction: nameof(this.Training2_NewDrawingDoc),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

        //public void Training2_3()
        //{
        //    training2.connectToSolidWorks(this.iSwApp);
        //}

        //public void Training2_NewModel_Part()
        //{
        //    training2.NewModel_Part(this.iSwApp);
        //}

        //public void Training2_NewModel_ASM()
        //{
        //    training2.NewModel_ASM(this.iSwApp);
        //}

        //public void Training2_NewModel_DRW()
        //{
        //    training2.NewModel_DRW(this.iSwApp);
        //}

        //public void Training2_NewPartDoc()
        //{
        //    training2.NewPartDoc(this.iSwApp);
        //}

        //public void Training2_NewAssemblyDoc()
        //{
        //    training2.NewAssemblyDoc(this.iSwApp);
        //}

        //public void Training2_NewDrawingDoc()
        //{
        //    training2.NewDrawingDoc(this.iSwApp);
        //}

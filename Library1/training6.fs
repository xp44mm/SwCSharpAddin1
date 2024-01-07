module training6

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

open FSharp.Idioms.Literal
open FSharp.SolidWorks
open FSharp.Idioms
open Dir


let TEMPLATENAME = Path.Combine(TEMPLATEDIR, "Drawing_ANSI.drwdot")
let SCALENUM = 1.0
let SCALEDENOM = 2.0
let SAVEASPATH = "d:\\"

let ThirdAngle = true

let getViewSeq (swDraw:IDrawingDoc) =
    let rec loop (vw:obj) =
        seq {
            match vw with
            | null -> ()
            | :? IView as vw ->
                yield vw
                yield! loop (vw.GetNextView())
            | _ -> failwith $"getViewSeq:{vw.GetType()}"
        }
    swDraw.GetFirstView()
    |> loop


let main(swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2
    let swDraw = 
        swApp.NewDocument(TEMPLATENAME, int swDwgPaperSizes_e.swDwgPaperA1size, 0.0, 0.0)
        :?> IDrawingDoc

    let ConfigNamesArray = 
        swModel.GetConfigurationNames()
        :?> obj[]
        |> Array.map(fun x -> x:?> string)

    ConfigNamesArray
    |> Array.iteri(fun i configName ->
        //let retval = 
        if i > 0 then
            swDraw.NewSheet4(
                Name = configName, 
                PaperSize = int swDwgPaperSizes_e.swDwgPaperA1size, 
                TemplateIn = int swDwgTemplates_e.swDwgTemplateA1size, 
                Scale1 = SCALENUM, 
                Scale2 = SCALEDENOM, 
                FirstAngle = not ThirdAngle, 
                TemplateName = "", 
                Width = 0.0, 
                Height = 0.0, 
                PropertyViewName = "", 
                ZoneLeftMargin = 0.0, 
                ZoneRightMargin = 0.0, 
                ZoneTopMargin = 0.0, 
                ZoneBottomMargin =0.0, 
                ZoneRow = 0, 
                ZoneCol = 0)
        else
            swDraw.SetupSheet6(
                configName, 
                int swDwgPaperSizes_e.swDwgPaperA1size, 
                int swDwgTemplates_e.swDwgTemplateA1size, 
                SCALENUM, 
                SCALEDENOM, 
                not ThirdAngle, 
                "", 
                0.0, 
                0.0, 
                "", 
                false, 
                0.0, 
                0.0, 
                0.0, 
                0.0, 
                0, 
                0)
        |> ignore

        if ThirdAngle then
            swDraw.Create3rdAngleViews2(swModel.GetPathName())
        else
            swDraw.Create1stAngleViews2(swModel.GetPathName())
        |> ignore

        //let vws =
        swDraw
        |> getViewSeq
        |> Seq.iter(fun swView ->
            swView.ReferencedConfiguration <- configName
        )
            //|> Seq.toArray
        let RebuildSuccess = (swDraw:?>IModelDoc2).ForceRebuild3(true) //ModelDoc2.ForceRebuild3
        swDraw.InsertModelAnnotations3( 
            Option = int swImportModelItemsSource_e.swImportModelItemsFromEntireModel, 
            Types = int (swInsertAnnotation_e.swInsertDimensionsMarkedForDrawing ||| swInsertAnnotation_e.swInsertNotes), 
            AllViews = true, 
            DuplicateDims = true, 
            HiddenFeatureDims = true, 
            UsePlacementInSketch = false
        )
        |> ignore

        let saveAs (filenameextension:string) =
            let mutable errors = 0
            let mutable warnings = 0

            (swDraw :?> IModelDoc2).Extension.SaveAs(
                Name = $"{Path.Combine(SAVEASPATH ,configName)}.{filenameextension}",
                Version = int swSaveAsVersion_e.swSaveAsCurrentVersion,
                Options = int swSaveAsOptions_e.swSaveAsOptions_Silent,
                ExportData = null, 
                Errors = &errors, 
                Warnings = &warnings
                )
            |> ignore

            if errors <> 0 then
                failwith $"{enum<swFileSaveError_e>errors}"

            if warnings <> 0 then
                failwith $"{enum<swFileSaveWarning_e>warnings}"

        saveAs("DXF")
        saveAs("DWG")
        saveAs("JPG")
        saveAs("TIF")

        ()
    
    )

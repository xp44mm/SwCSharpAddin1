module FSharp.SolidWorks.SldWorksUtils

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

let activeDoc (swApp: ISldWorks) =
    swApp.ActiveDoc
    :?> ModelDoc2

///https://help.solidworks.com/2023/english/api/sldworksapi/solidworks.interop.sldworks~solidworks.interop.sldworks.isldworks~opendoc6.html
let openDoc6
    (fileName:string) (docType:swDocumentTypes_e) (options:swOpenDocOptions_e) (config:string)
    (swApp: ISldWorks) =
    let mutable errors = 0
    let mutable warnings = 0
    let modelDoc = swApp.OpenDoc6(
        FileName      = fileName,
        Type          = int docType,
        Options       = int options,
        Configuration = config,
        Errors        = &errors,
        Warnings      = &warnings 
        )
    if modelDoc <> null && errors = 0 && warnings = 0 then
        modelDoc
    else
        [
            if errors > 0 then 
                sprintf "openDoc6 util: %A" (enum<swFileLoadError_e> errors)
            if warnings > 0 then 
                sprintf "openDoc6 util: %A" (enum<swFileLoadWarning_e> warnings)
        ]
        |> String.concat " and "
        |> failwith

let documentVisible (visible:bool) (documentType:swDocumentTypes_e) (swApp: ISldWorks) =
    swApp.DocumentVisible(visible, int documentType)

let activateDoc3 name preferences (options:swRebuildOnActivation_e) (swApp: ISldWorks) =
    let mutable errors = 0
    let res = 
        swApp.ActivateDoc3(
            Name               = name, 
            UseUserPreferences = preferences,
            Option             = int options, 
            Errors             = &errors)
        :?> ModelDoc2
    if errors = 0 then
        res
    else
        failwith $"{enum<swActivateDocError_e>errors}"

let loadFile4 fileName argString importData (swApp: ISldWorks) =
    let mutable errors = 0
    let res = swApp.LoadFile4(
        FileName   = fileName, 
        ArgString  = argString, 
        ImportData = importData, 
        Errors     = &errors)
    if errors = 0 then
        res
    else
        failwith $"{enum<swFileLoadError_e>errors}"
         
let getMathUtility (swApp: ISldWorks) =
    swApp.GetMathUtility()
    :?> MathUtility

//swDwgPaperSizes_e
let newDocument (template) (paperSize:swDwgPaperSizes_e) (w,h) (swApp: ISldWorks) =
    swApp.NewDocument(template, int paperSize, w, h)
    :?> ModelDoc2

//用默认零件模板新建一个零件文件
let newPartDoc (swApp: ISldWorks) =
    swApp.NewDocument(
        TemplateName = SwUserPreference(swApp).swDefaultTemplatePart, 
        PaperSize = 0,
        Width = 0.0, 
        Height = 0.0)

//用默认装配体模板新建一个装配体文件
let newAssemblyDoc (swApp: ISldWorks) =
    swApp.NewDocument(
        TemplateName = SwUserPreference(swApp).swDefaultTemplateAssembly, 
        PaperSize = 0,
        Width = 0.0, 
        Height = 0.0)

let sendMsgToUser2
    (message:string)
    (icon:swMessageBoxIcon_e)
    (buttons:swMessageBoxBtn_e)
    (swApp:ISldWorks)
    =
    swApp.SendMsgToUser2(
        message,
        int icon,
        int buttons)
    |> enum<swMessageBoxResult_e>

let defineAttribute (name:string) (swApp:ISldWorks) =
    swApp.DefineAttribute name
    :?> AttributeDef

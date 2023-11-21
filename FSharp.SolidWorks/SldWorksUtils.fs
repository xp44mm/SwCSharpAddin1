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

open FSharp.SolidWorks
//open FSharp.Literals

let activeDoc (swApp: ISldWorks) =
    swApp.ActiveDoc
    |> unbox<ModelDoc2>

///https://help.solidworks.com/2023/english/api/sldworksapi/solidworks.interop.sldworks~solidworks.interop.sldworks.isldworks~opendoc6.html
let openDoc6
    (filename:string) (tp:swDocumentTypes_e) (opts:swOpenDocOptions_e) (config:string)
    (swApp: ISldWorks) =
    let mutable longstatus = 0
    let mutable longwarnings = 0
    swApp.OpenDoc6(filename, int tp, int opts, config, &longstatus, &longwarnings)


let documentVisible (visible:bool) (documentType:swDocumentTypes_e) (swApp: ISldWorks) = 
    swApp.DocumentVisible(visible, int documentType)

//swDwgPaperSizes_e
let newDocument (template) (paperSize:swDwgPaperSizes_e) (w) (h) (swApp: ISldWorks) =
    swApp.NewDocument(template, int paperSize, w, h)
    |> unbox<ModelDoc2>

let activateDoc3 name usePrefs (opts:swRebuildOnActivation_e) (swApp: ISldWorks) =
    let mutable errors = 0
    try
        swApp.ActivateDoc3(name, usePrefs,int opts, &errors)
        |> unbox<ModelDoc2>
    with _ -> failwith $"{enum<swActivateDocError_e>errors}"

let loadFile4 fileName argString importData (swApp: ISldWorks) =
    let mutable errors = 0
    try
        swApp.LoadFile4(fileName, argString, importData, &errors)
    with _ -> failwith $"{enum<swFileLoadError_e>errors}"


let getMathUtility (swApp: ISldWorks) = 
    swApp.GetMathUtility()
    |> unbox<MathUtility>

let setUserPreferenceToggle (toggle:swUserPreferenceToggle_e) (onFlag:bool) (swApp: ISldWorks) = 
    swApp.SetUserPreferenceToggle(int toggle, onFlag)

let getUserPreferenceToggle (toggle:swUserPreferenceToggle_e) (swApp: ISldWorks) = 
    swApp.GetUserPreferenceToggle(int toggle)

let setUserPreferenceDoubleValue (pref:swUserPreferenceDoubleValue_e) (value:float) (swApp: ISldWorks) = 
    swApp.SetUserPreferenceDoubleValue(int pref, value)
    |> ignore

let getUserPreferenceDoubleValue (pref:swUserPreferenceDoubleValue_e) (swApp: ISldWorks) = 
    swApp.GetUserPreferenceDoubleValue(int pref)

let setUserPreferenceIntegerValue (pref:swUserPreferenceIntegerValue_e) (value:int) (swApp: ISldWorks) = 
    swApp.SetUserPreferenceIntegerValue(int pref, value)
    |> ignore

let getUserPreferenceIntegerValue (pref:swUserPreferenceIntegerValue_e) (swApp: ISldWorks) = 
    swApp.GetUserPreferenceIntegerValue(int pref)

let setUserPreferenceStringValue (pref:swUserPreferenceStringValue_e) (value:string) (swApp: ISldWorks) = 
    swApp.SetUserPreferenceStringValue(int pref, value)
    |> ignore

let getUserPreferenceStringValue (pref:swUserPreferenceStringValue_e) (swApp: ISldWorks) = 
    swApp.GetUserPreferenceStringValue(int pref)

//用默认模板新建一个零件文件
let newPartDoc (swApp: ISldWorks) = 
    let dir = 
        swApp 
        |> getUserPreferenceStringValue swUserPreferenceStringValue_e.swDefaultTemplatePart
    swApp
    |> newDocument dir swDwgPaperSizes_e.swDwgPaperAsize 0.0 0.0
    :?> PartDoc

//用默认模板新建一个装配体文件
let newAssemblyDoc (swApp: ISldWorks) = 
    let dir = 
        swApp 
        |> getUserPreferenceStringValue swUserPreferenceStringValue_e.swDefaultTemplateAssembly
    swApp
    |> newDocument dir swDwgPaperSizes_e.swDwgPaperAsize 0.0 0.0
    :?> AssemblyDoc

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
    |> unbox<AttributeDef>

//iCmdMgr = iSwApp.GetCommandManager(cookie);

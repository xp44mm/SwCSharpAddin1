module FSharp.SolidWorks.ModelDoc2Utils

open System
open System.Collections
open System.Collections.Generic
open System.Diagnostics
open System.IO
open System.Reflection
open System.Runtime.InteropServices


open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File
open FSharp.SolidWorks
//open FSharp.Literals

//' Save to do: int to enum
let save3 (opts:swSaveAsOptions_e) (swModel: IModelDoc2) =
    let mutable swErrors = 0
    let mutable swWarnings = 0
    try
        swModel.Save3(int opts, &swErrors, &swWarnings)
        |> ignore
    with ex ->
        failwith $"{enum<swFileSaveError_e>swErrors},{enum<swFileSaveWarning_e>swWarnings}"

//https://help.solidworks.com/2023/english/api/sldworksapi/SolidWorks.Interop.sldworks~SolidWorks.Interop.sldworks.IModelDocExtension~SelectByID2.html
let selectByID2 name selecttype (x,y,z) append mark (selectOption:swSelectOption_e) (swModel: IModelDoc2) =
    let callout:Callout = null
    swModel.Extension.SelectByID2(name, selecttype, x, y, z, append, mark, callout, int selectOption)
    |> ignore

let selectByID
    (w:{|
    name        :string;
    stype       :string;
    location    :float*float*float;
    append      :bool;
    mark        :int;
    selectOption:swSelectOption_e;
    |}) 
    (swModel: IModelDoc2) =

    let callout:Callout = null
    let x,y,z = w.location
    swModel.Extension.SelectByID2(w.name, w.stype, x, y, z, w.append, w.mark, callout,int w.selectOption)
    |> ignore

let deSelectByID
    (selID: string)
    (selParams: string)
    (x: float,y: float,z: float)
    (swModel: IModelDoc2)
     =
    swModel.DeSelectByID(selID, selParams, x, y, z)

///第一层特征
let getFeatureSeq (swModel: IModelDoc2) =
    swModel.FirstFeature()
    |> FeatureUtils.getFeatureSeq

let getSelectionMgr (swModel: IModelDoc2) =
    swModel.SelectionManager
    :?> SelectionMgr

/// 获取文件名
let partfile (swModel: IModelDoc2) =
    Path.GetFileNameWithoutExtension(swModel.GetTitle())

//let setUserPreferenceToggle 
//    (userPref:swUserPreferenceToggle_e) 
//    (userPrefOption:swUserPreferenceOption_e) 
//    (value:bool) 
//    (swModel:IModelDoc2) =
//    swModel.Extension.SetUserPreferenceToggle(int userPref,int userPrefOption,value)

//let getUserPreferenceToggle 
//    (userPref:swUserPreferenceToggle_e) 
//    (userPrefOption:swUserPreferenceOption_e) 
//    (swModel:IModelDoc2) =
//    swModel.Extension.GetUserPreferenceToggle(int userPref, int userPrefOption)

//let setUserPreferenceInteger (userPref:swUserPreferenceIntegerValue_e) (userPrefOption:swUserPreferenceOption_e) (value:int) (swModel: IModelDoc2) =
//    swModel.Extension.SetUserPreferenceInteger(
//        int userPref,int userPrefOption,value)
//    |> ignore

//let getUserPreferenceInteger (userPref:swUserPreferenceIntegerValue_e) (userPrefOption:swUserPreferenceOption_e) (swModel: IModelDoc2) =
//    swModel.Extension.GetUserPreferenceInteger(
//        int userPref,int userPrefOption)

//let setUserPreferenceDouble (userPref:swUserPreferenceDoubleValue_e) (userPrefOption:swUserPreferenceOption_e) (value:float) (swModel: IModelDoc2) =
//    swModel.Extension.SetUserPreferenceDouble(
//        int userPref, int userPrefOption,value)
//    |> ignore

//let getUserPreferenceDouble (userPref:swUserPreferenceDoubleValue_e) (userPrefOption:swUserPreferenceOption_e) (swModel: IModelDoc2) =
//    swModel.Extension.GetUserPreferenceDouble(
//        int userPref, int userPrefOption)

let setToolbarVisibility (tb:swToolbar_e) (visible:bool) (swModel:IModelDoc2) =
    swModel.SetToolbarVisibility(int tb,visible)

let addDimension (x1,y1,z1) (direction:swSmartDimensionDirection_e) (swModel:IModelDoc2) =
    swModel.Extension.AddDimension(x1,y1,z1,int direction)
    :?> IDisplayDimension

let addVerticalDimension2 (x1,y1,z1) (swModel:IModelDoc2) =
    swModel.AddVerticalDimension2 (x1,y1,z1)
    :?> IDisplayDimension

let addHorizontalDimension2 (x1,y1,z1) (swModel:IModelDoc2) =
    swModel.AddHorizontalDimension2 (x1,y1,z1)
    :?> IDisplayDimension

let activeView (swModel:IModelDoc2) = swModel.ActiveView :?> ModelView

let getSummaryInfo (field:swSummInfoField_e)(swModel:IModelDoc2) =
    swModel.SummaryInfo(int field)

let setSummaryInfo (field:swSummInfoField_e) (text:string) (swModel:IModelDoc2) =
    swModel.SummaryInfo(int field) <- text

let getConfigurationNames (swModel:IModelDoc2) =
    swModel.GetConfigurationNames()
    :?> string[]

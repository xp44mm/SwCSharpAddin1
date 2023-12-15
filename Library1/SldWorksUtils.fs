module SldWorksUtils

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
open FSharp.Idioms

let testGetFeatures (swApp: ISldWorks) =
    let logfile = "d:/partmat.txt"
    let swModel = swApp.ActiveDoc :?> ModelDoc2
    if File.Exists(logfile) then File.Delete logfile

    swModel.FirstFeature()
    |> FeatureUtils.getFeatureSeq
    |> Seq.iter(fun swFeat ->
        let nm = swFeat.Name
        let tp = swFeat.GetTypeName2()
        File.AppendAllText(logfile,$"{nm}:{tp}\n")
    )


let testPipeBom (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> ModelDoc2

    let logfile = "d:/pipeBom.txt"

    if File.Exists(logfile) then File.Delete logfile

    swModel.FirstFeature()
    |> FeatureUtils.getFeatureSeq
    |> Seq.iter(fun swFeat ->
        let nm = swFeat.Name
        let tp = swFeat.GetTypeName2()
        File.AppendAllText(logfile,$"{nm}:{tp}\n")
    )

/// 打开一个线路零件
//从一个管道装配体打开线路零件的模型，并读取管道长度
let readSWPipeLength (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> ModelDoc2
    let config = swModel.ConfigurationManager.ActiveConfiguration
    let swCustPrpMgr = swModel.Extension.CustomPropertyManager(config.Name)
    CustomPropsConfig1.PrintProperties swCustPrpMgr false ""


///单个文件
let detectCutLists (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> ModelDoc2

    let logfile = "d:/detectCutLists.txt"

    if File.Exists(logfile) then File.Delete logfile

    let props =
        let hs = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        
        CutList.cutListItemFieldNames
        |> Seq.concat
        |> Seq.iter(fun e -> hs.Add e |> ignore)
        hs

    let txt = 
        swModel
        |> CutList.getCutListCustomPropertyManager
        |> Seq.map(fun cpm ->
            cpm.GetNames() :?> string[]
            |> Array.filter(props.Contains)
            |> Array.map(fun pnm ->
                match CustomPropertyManagerUtils.GetUpdatedProperty pnm cpm with
                | value, resval -> $"{pnm},{value},{resval}"
                )
            |> String.concat "\n"
        )
        |> String.concat "\n\n"
    File.AppendAllText(logfile,txt)

///多个文件
let testCutLists (swApp: ISldWorks) =
    let logfile = "d:/cutlists.tsv"
    if File.Exists(logfile) then File.Delete logfile

    //标题行，写入文件
    let head = 
        [
            "文件"
            yield! CutList.cutListItemFieldNames |> List.map List.head
        ]
        |> String.concat "\t"
    File.AppendAllText(logfile,$"{head}\n")

    let currentDir = "D:/崔胜利/凯帝隆/湖北武穴锂宝/solidworks/"
    let files =
        Directory.GetFiles(currentDir)
        |> Seq.filter(fun fl -> Path.GetExtension fl = ".SLDPRT")
        |> Seq.toList

    for fl in files do
        let swModel =
            swApp 
            |> SldWorksUtils.openDoc6 fl swDocumentTypes_e.swDocPART swOpenDocOptions_e.swOpenDocOptions_Silent ""
        let part = swModel :?> PartDoc
        if part.IsWeldment() then
            let mat,db = PartDocUtils.getMaterialPropertyName2 "" part
            if mat <> "" && db <> "" then
                ModelDocUtils.printCutLists logfile swModel
            else
                let partfile = Path.GetFileNameWithoutExtension(fl)
                File.AppendAllText(logfile, $"{partfile}\t{mat}\t{db}\t\t\n")

        //' Close Document
        swModel.GetPathName()
        |> swApp.CloseDoc

let setPartWeldment (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> ModelDoc2
    try
        CutList.setWeldmentUserPreference swModel
        swApp.SendMsgToUser "setPartWeldment OK!"
    with ex ->
        swApp.SendMsgToUser $"setPartWeldment ex: {ex.Message}"


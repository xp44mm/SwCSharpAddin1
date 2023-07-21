﻿module SldWorksUtils

open System
open System.Runtime.InteropServices
open System.Collections
open System.Collections.Generic
open System.Diagnostics
open System.Reflection
open System.Text.RegularExpressions
open System.IO

open FSharp.Literals


open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

let ActiveDoc (swApp: ISldWorks) = 
    swApp.ActiveDoc 
    |> unbox<ModelDoc2>

/// Open
let OpenDoc (filename:string) (tp:swDocumentTypes_e) (opts:swOpenDocOptions_e) (config:string) (swApp: ISldWorks) =
    let mutable longstatus = 0
    let mutable longwarnings = 0
    swApp.OpenDoc6(filename, int tp, int opts, config, &longstatus, &longwarnings)

let testGetFeatures (swApp: ISldWorks) =
    let logfile = "d:/partmat.txt"
    let swModel = swApp.ActiveDoc |> unbox<ModelDoc2>
    if File.Exists(logfile) then File.Delete logfile

    swModel
    |> ModelDocUtils.TraverseModelFeatures
    |> Seq.iter(fun swFeat ->
        let nm = swFeat.Name
        let tp = swFeat.GetTypeName2()
        File.AppendAllText(logfile,$"{nm}:{tp}\n")
    )


let testPipeBom (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc |> unbox<ModelDoc2>

    let logfile = "d:/pipeBom.txt"

    if File.Exists(logfile) then File.Delete logfile

    swModel
    |> ModelDocUtils.TraverseModelFeatures
    //|> Seq.filter(fun swFeat ->
    //    let nm = swFeat.Name
    //    let tp = swFeat.GetTypeName2()
    //    tp = "Reference" && Regex.IsMatch(nm,"^Pipe_")
    //)
    //|> Seq.collect(fun pc ->
    //    FeatureUtils.TraverseSubFeatures pc
    //)
    |> Seq.iter(fun swFeat ->
        let nm = swFeat.Name
        let tp = swFeat.GetTypeName2()
        File.AppendAllText(logfile,$"{nm}:{tp}\n")
    )

/// 打开一个线路零件
let readSWPipeLength (swApp: ISldWorks) =
    let swModel = 
        swApp.ActiveDoc
        |> unbox<ModelDoc2>

    let config = swModel.ConfigurationManager.ActiveConfiguration
    let swCustPrpMgr = swModel.Extension.CustomPropertyManager(config.Name)
    CustomPropsConfig1.PrintProperties swCustPrpMgr false ""

//从一个管道装配体打开线路零件的模型，并读取管道长度

///单个文件
let detectCutLists (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc |> unbox<ModelDoc2>

    let logfile = "d:/detectCutLists.txt"

    if File.Exists(logfile) then File.Delete logfile

    let props =
        let hs = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        
        CustomPropertyManagerUtils.cutListItemFieldNames
        |> Seq.concat
        |> Seq.iter(fun e -> hs.Add e |> ignore)
        hs

    let txt = 
        swModel
        |> ModelDocUtils.GetCutListCustomPropertyManager
        |> Seq.map(fun cpm ->
            cpm.GetNames() |> unbox<string[]>
            |> Array.filter(props.Contains)
            |> Array.map(fun pnm ->
                //if  pnm then
                match CustomPropertyManagerUtils.tryResolvedValOut pnm cpm with
                | Some resval -> $"{pnm},{resval}"
                | _ -> $"{pnm}: no resval"
                //else $"{pnm}: no matter"
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
            yield! CustomPropertyManagerUtils.cutListItemFieldNames |> List.map List.head
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
        |> OpenDoc fl swDocumentTypes_e.swDocPART swOpenDocOptions_e.swOpenDocOptions_Silent ""
    let part = swModel :?> PartDoc
    if part.IsWeldment() then
        let mat,db = PartDocUtils.GetMaterialPropertyName "" part
        if mat <> "" && db <> "" then
            ModelDocUtils.printCutLists logfile swModel
        else
            let partfile = Path.GetFileNameWithoutExtension(fl)
            File.AppendAllText(logfile, $"{partfile}\t{mat}\t{db}\t\t\n")

    //' Close Document
    swModel.GetPathName()
    |> swApp.CloseDoc

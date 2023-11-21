﻿module ModelDocUtils

open System
open System.Collections
open System.Collections.Generic
open System.Diagnostics
open System.IO
open System.Reflection
open System.Runtime.InteropServices

open FSharp.Literals

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File
open FSharp.SolidWorks

let printCutLists logfile (swModel:ModelDoc2) =    
    swModel 
    |> CutList.updateCutList

    let partfile = Path.GetFileNameWithoutExtension(swModel.GetTitle())

    swModel
    |> CutList.getCutList
    |> Seq.iter(fun feat ->
        let swCutListPrpMgr = feat.CustomPropertyManager
        let outp = 
            [
                partfile
                yield! CutList.GetCutListItemFields(swCutListPrpMgr)
            ]
            |> String.concat "\t"
        File.AppendAllText(logfile,$"{outp}\n")
    )



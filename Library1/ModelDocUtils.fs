module ModelDocUtils

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

let UpdateCutList (model: ModelDoc2) =
    let swBodyFolder =
        model.FirstFeature()
        |> FeatureUtils.getFeatureSeq
        |> Seq.pick(fun feat ->
            if feat.GetTypeName2() = "SolidBodyFolder" then
                let swBodyFolder = feat.GetSpecificFeature2():?> BodyFolder
                Some swBodyFolder
            else None
        )
    swBodyFolder.UpdateCutList()
    |> ignore

let GetCutListCustomPropertyManager (swModel:ModelDoc2) =
    swModel.FirstFeature()
    |> FeatureUtils.getFeatureSeq
    |> Seq.filter(fun feat -> 
        let tp = feat.GetTypeName2()
        tp = "CutListFolder")
    |> Seq.map(fun feat ->
        let swCutListPrpMgr = feat.CustomPropertyManager
        swCutListPrpMgr
    )

let GetCutLists(model: ModelDoc2) =
    let parentCutlists =
        model.FirstFeature()
        |> FeatureUtils.getFeatureSeq
        |> Seq.filter(fun feat -> feat.GetTypeName2() = "CutListFolder")

    parentCutlists
    |> Seq.collect(fun feat ->
        let sq = FeatureUtils.getSubFeatureSeq feat
        if Seq.isEmpty sq then 
            Seq.singleton feat
        else sq
    )

let printCutLists logfile (swModel:ModelDoc2) =    
    swModel 
    |> UpdateCutList

    let partfile = Path.GetFileNameWithoutExtension(swModel.GetTitle())

    swModel.FirstFeature()
    |> FeatureUtils.getFeatureSeq
    |> Seq.filter(fun feat -> 
        let tp = feat.GetTypeName2()
        tp = "CutListFolder")
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



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


let partfile (swModel: ModelDoc2) =
    Path.GetFileNameWithoutExtension(swModel.GetTitle())

//https://help.solidworks.com/2023/english/api/sldworksapi/SolidWorks.Interop.sldworks~SolidWorks.Interop.sldworks.IModelDocExtension~SelectByID2.html#
let SelectByID name selecttype append mark (swModel: ModelDoc2) =
    let selecttype = EnumUtils.selecttype selecttype
    let x,y,z = 0.0,0.0,0.0
    let callout:Callout = null
    let selectoption = int swSelectOption_e.swSelectOptionDefault
    swModel.Extension.SelectByID2(name, selecttype, x, y, z, append, mark, callout, selectoption)
 
//' Save
let Save (opts) (swModel: ModelDoc2) =
    let mutable swErrors = 0
    let mutable swWarnings = 0
    try
        swModel.Save3(opts, &swErrors, &swWarnings)
        |> ignore
    with ex ->
        failwith $"{swErrors}{swWarnings}"

///第一层特征
let TraverseModelFeatures (model: ModelDoc2) =
    let swFeat = model.FirstFeature() :?> Feature
    let rec loop (swFeat:Feature) =
        seq {
            if swFeat = null then
                ()
            else
                yield swFeat
                yield! loop (swFeat.GetNextFeature() :?> Feature)
        }
    loop swFeat

let UpdateCutList (model: ModelDoc2) =
    let swBodyFolder =
        model
        |> TraverseModelFeatures 
        |> Seq.pick(fun feat ->
            if feat.GetTypeName2() = "SolidBodyFolder" then
                let swBodyFolder = feat.GetSpecificFeature2() :?> BodyFolder
                Some swBodyFolder
            else None
        )
    swBodyFolder.UpdateCutList()
    |> ignore

let GetCutListCustomPropertyManager (swModel:ModelDoc2) =
    swModel
    |> TraverseModelFeatures
    |> Seq.filter(fun feat -> 
        let tp = feat.GetTypeName2()
        tp = "CutListFolder")
    |> Seq.map(fun feat ->
        let swCutListPrpMgr = feat.CustomPropertyManager
        swCutListPrpMgr
    )

let GetCutLists(model: ModelDoc2) =
    let parentCutlists =
        model
        |> TraverseModelFeatures
        |> Seq.filter(fun feat -> feat.GetTypeName2() = "CutListFolder")

    parentCutlists
    |> Seq.collect(fun feat ->
        let sq = FeatureUtils.TraverseSubFeatures feat
        if Seq.isEmpty sq then 
            Seq.singleton feat
        else sq
    )


let printCutLists logfile (swModel:ModelDoc2) =    
    swModel 
    |> UpdateCutList

    let partfile = Path.GetFileNameWithoutExtension(swModel.GetTitle())

    swModel
    |> TraverseModelFeatures
    |> Seq.filter(fun feat -> 
        let tp = feat.GetTypeName2()
        tp = "CutListFolder")
    |> Seq.iter(fun feat ->
        let swCutListPrpMgr = feat.CustomPropertyManager
        let outp = 
            [
                partfile
                yield! CustomPropertyManagerUtils.GetCutListItemFields(swCutListPrpMgr) 
                    //|> List.map (Option.defaultValue "")
            ]
            |> String.concat "\t"
        File.AppendAllText(logfile,$"{outp}\n")
    )



module CustomPropertyManagerUtils

open System
open System.Collections
open System.Collections.Generic
open System.Diagnostics
open System.Reflection
open System.Runtime.InteropServices
open System.IO

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst

open SolidWorksTools
open SolidWorksTools.File

///
let getCustomPropertyNames (custPrpMgr: CustomPropertyManager) =
        let hs = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        custPrpMgr.GetNames()
        |> unbox<string[]>
        |> Array.iter(fun e -> hs.Add e |> ignore)
        hs

let contains (prpName: string) (custPrpMgr:CustomPropertyManager) =
    let prpNames = getCustomPropertyNames custPrpMgr
    prpNames.Contains prpName

let Get (fieldName: string) (custPrpMgr: CustomPropertyManager) =
    let mutable valOut = ""
    let mutable resolvedValOut = ""
    let mutable wasResolved = true
    let mutable linkToProperty = true

    /// https://help.solidworks.com/2023/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swCustomInfoGetResult_e.html
    let reti = custPrpMgr.Get6(fieldName, false, 
        &valOut, &resolvedValOut, &wasResolved,&linkToProperty)

    {|
       valOut = valOut // Value/Text Expression
       resolvedValOut = resolvedValOut // Evaluated Value
       wasResolved = wasResolved //Was Resolved: True
       linkToProperty = linkToProperty
       customInfoGetResult = enum<swCustomInfoGetResult_e> reti // swCustomInfoGetResult_e.swCustomInfoGetResult_ResolvedValue
    |}

let detectCutListItemFields (custPrpMgr: CustomPropertyManager) =
    let prpNames = getCustomPropertyNames custPrpMgr
    prpNames
    |> Seq.map(fun name -> 
        name, Get name custPrpMgr
    )

let tryResolvedValOut (fieldName: string) (custPrpMgr: CustomPropertyManager) =
    let rcd = Get fieldName custPrpMgr
    match rcd.customInfoGetResult with
    | swCustomInfoGetResult_e.swCustomInfoGetResult_ResolvedValue
        -> Some rcd.resolvedValOut
    | swCustomInfoGetResult_e.swCustomInfoGetResult_NotPresent
    | swCustomInfoGetResult_e.swCustomInfoGetResult_CachedValue
    | _ -> None

let detectCutListItemFields2 (custPrpMgr: CustomPropertyManager) =
    let prpNames = getCustomPropertyNames custPrpMgr
    prpNames
    |> Seq.map(fun name -> 
        let x =
            tryResolvedValOut name custPrpMgr
        x
        |> Option.map(fun v -> name, v)
    )

let resolvedValOut (fieldName: string) (custPrpMgr: CustomPropertyManager) =
    let rcd = Get fieldName custPrpMgr
    match rcd.customInfoGetResult with
    | swCustomInfoGetResult_e.swCustomInfoGetResult_ResolvedValue
        -> rcd.resolvedValOut
    | swCustomInfoGetResult_e.swCustomInfoGetResult_NotPresent
    | swCustomInfoGetResult_e.swCustomInfoGetResult_CachedValue
    | _ -> failwith $"{rcd}"


//拾取第一个成功读取到非空值的属性，从fieldNames序列中。
let pickResolvedValOut (fieldNames: seq<string>) (custPrpMgr: CustomPropertyManager) =
    let ss =
        custPrpMgr
        |> getCustomPropertyNames

    ss.IntersectWith fieldNames

    match ss.Count with
    | 1 -> resolvedValOut (Seq.head ss) custPrpMgr
    | 0 -> failwith $"{fieldNames} not in {custPrpMgr.GetNames() |> unbox<string[]> |> Array.toList}"
    | _ -> failwith $"{ss |> Seq.toList}"

let cutListItemFieldNames =
    [
        ["材料";"MATERIAL"]
        ["说明";"Description"]
        ["长度";"LENGTH"]
        ["数量";"QUANTITY"]
    ]

/// 长度，说明，材料，数量等属性的值列表
let GetCutListItemFields (custPrpMgr: CustomPropertyManager) =
    cutListItemFieldNames
    |> List.map(fun ce ->        
        pickResolvedValOut ce custPrpMgr
    )

//let GetCutListItemString (custPrpMgr: CustomPropertyManager) =
//    custPrpMgr
//    |> GetCutListItemFields
//    |> List.map (Option.defaultValue "")
//    |> String.concat "\t"



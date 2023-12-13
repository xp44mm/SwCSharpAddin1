module FSharp.SolidWorks.CustomPropertyManagerUtils

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

/// 获取不区分大小写的自定义属性名称集合
let getCustomPropertyNames (custPrpMgr: ICustomPropertyManager) =
        let hs = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        custPrpMgr.GetNames()
        :?> string[]
        |> Array.iter(fun e -> hs.Add e |> ignore)
        hs
/// 
let contains (prpName: string) (custPrpMgr:ICustomPropertyManager) =
    let prpNames = getCustomPropertyNames custPrpMgr
    prpNames.Contains prpName

/// 
let get6 (fieldName:string) (useCached:bool) (custPrpMgr:ICustomPropertyManager) =
    let mutable valOut = ""
    let mutable resolvedValOut = ""
    let mutable wasResolved = true
    let mutable linkToProperty = true

    /// https://help.solidworks.com/2023/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swCustomInfoGetResult_e.html
    let reti = 
        custPrpMgr.Get6(fieldName, useCached, 
        &valOut, &resolvedValOut, &wasResolved,&linkToProperty)

    {|
       valOut = valOut // Value/Text Expression
       resolvedValOut = resolvedValOut // Evaluated Value
       wasResolved = wasResolved //Was Resolved: True
       linkToProperty = linkToProperty
       customInfoGetResult = enum<swCustomInfoGetResult_e> reti // swCustomInfoGetResult_e.swCustomInfoGetResult_ResolvedValue
    |}

let tryResolvedValOut (fieldName:string) (custPrpMgr:ICustomPropertyManager) =
    let rcd = get6 fieldName false custPrpMgr
    match rcd.customInfoGetResult with
    | swCustomInfoGetResult_e.swCustomInfoGetResult_ResolvedValue
        -> Some rcd.resolvedValOut
    | swCustomInfoGetResult_e.swCustomInfoGetResult_NotPresent
    | swCustomInfoGetResult_e.swCustomInfoGetResult_CachedValue
    | _ -> None

let resolvedValOut (fieldName: string) (custPrpMgr: ICustomPropertyManager) =
    let rcd = get6 fieldName false custPrpMgr
    match rcd.customInfoGetResult with
    | swCustomInfoGetResult_e.swCustomInfoGetResult_ResolvedValue
        -> rcd.resolvedValOut
    | swCustomInfoGetResult_e.swCustomInfoGetResult_NotPresent
    | swCustomInfoGetResult_e.swCustomInfoGetResult_CachedValue
    | _ -> failwith $"{rcd}"

//拾取第一个成功读取到非空值的属性，从fieldNames序列中。
let pickResolvedValOut (fieldNames: seq<string>) (custPrpMgr: ICustomPropertyManager) =
    let custPrpNames =
        custPrpMgr
        |> getCustomPropertyNames
    //注意ss本身被IntersectWith修改为交集,已经验证ss剩下的是ss中的元素
    custPrpNames.IntersectWith fieldNames

    match custPrpNames.Count with
    | 1 -> resolvedValOut (Seq.head custPrpNames) custPrpMgr
    | c -> 
        let AllNames = 
            custPrpMgr.GetNames()
            :?> string[]
            |> Array.toList
        failwith $"{c}!=1,\n{fieldNames |> Seq.toList}\n{AllNames}"

let add3
    fieldName
    (fieldType: swCustomInfoType_e)
    fieldValue
    (overwriteExisting: swCustomPropertyAddOption_e)
    (custPrpMgr: CustomPropertyManager)
    =
    custPrpMgr.Add3(fieldName, int fieldType, fieldValue, int overwriteExisting)

[<Obsolete("inline for demo")>]
let set2 fieldName fieldValue (custPrpMgr:ICustomPropertyManager) = 
    let SetStatus = custPrpMgr.Set2(fieldName, fieldValue)
    ()

let getNames (custPrpMgr: ICustomPropertyManager) =
    custPrpMgr.GetNames() 
    :?> string[]

let count (custPrpMgr: ICustomPropertyManager) =
    custPrpMgr.Count




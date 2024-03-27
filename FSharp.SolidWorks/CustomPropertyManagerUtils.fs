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
        
///https://help.solidworks.com/2023/english/api/swconst/SOLIDWORKS.Interop.swconst~SOLIDWORKS.Interop.swconst.swCustomInfoGetResult_e.html
let GetUpdatedProperty (fieldName:string) (cusPropMgr:ICustomPropertyManager) =
    let mutable value = ""
    let mutable resolvedValue = ""
    let mutable wasResolved = false
    let mutable linkToProperty = false
    let i =
        cusPropMgr.Get6(
            FieldName = fieldName,
            UseCached = false,
            ValOut = &value,
            ResolvedValOut = &resolvedValue,
            WasResolved = &wasResolved,
            LinkToProperty = &linkToProperty
        )
        |> enum<swCustomInfoGetResult_e>
    if not wasResolved || i <> swCustomInfoGetResult_e.swCustomInfoGetResult_ResolvedValue then
        failwithf "%A" i
    else
        value,resolvedValue

let getNames (custPrpMgr: ICustomPropertyManager) =
    match custPrpMgr.GetNames() with
    | null -> [||]
    | :? array<obj> as arr ->
        arr
        |> Array.map(fun o -> o :?> string)
    | x -> failwithf "%A,%A" x (x.GetType())

/// 获取不区分大小写的自定义属性名称集合
let getCustomPropertyNames (custPrpMgr: ICustomPropertyManager) =
    let hs = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    custPrpMgr
    |> getNames
    |> Array.iter(fun e -> hs.Add e |> ignore)
    hs

/// 
let contains (prpName: string) (custPrpMgr: ICustomPropertyManager) =
    let prpNames = getCustomPropertyNames custPrpMgr
    prpNames.Contains prpName

let getAllTypesValues (cusPropMgr:CustomPropertyManager) =
    cusPropMgr
    |> getNames 
    |> Array.map(fun name ->
        let typ =
            cusPropMgr.GetType2(name) 
            |> enum<swCustomInfoType_e>
            |> CustomInfoType.getCore

        let value =
            cusPropMgr 
            |> GetUpdatedProperty name 
            |> snd
        name,typ,value
    )

//拾取第一个成功读取到非空值的属性，从fieldNames序列中。
let pickResolvedValOut (fieldNames: seq<string>) (custPrpMgr: ICustomPropertyManager) =
    let custPrpNames =
        custPrpMgr
        |> getCustomPropertyNames
    //custPrpNames本身被IntersectWith修改为交集,已经验证custPrpNames剩下的是custPrpNames中的元素，而非fieldNames中的元素
    custPrpNames.IntersectWith fieldNames

    match custPrpNames.Count with
    | 1 -> GetUpdatedProperty (Seq.head custPrpNames) custPrpMgr
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

let count (custPrpMgr: ICustomPropertyManager) =
    custPrpMgr.Count





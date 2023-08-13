module FSharp.SolidWorks.CutList

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

let cutListItemFieldNames =
    [
        ["材料";"MATERIAL"]
        ["说明";"Description"]
        ["长度";"LENGTH"]
        ["数量";"QUANTITY"]
    ]

let detectCutListItemFields (custPrpMgr: ICustomPropertyManager) =
    let prpNames = CustomPropertyManagerUtils.getCustomPropertyNames custPrpMgr
    prpNames
    |> Seq.map(fun name -> 
        name, custPrpMgr |> CustomPropertyManagerUtils.Get6 name false
    )

let detectCutListItemFields2 (custPrpMgr: CustomPropertyManager) =
    let prpNames = CustomPropertyManagerUtils.getCustomPropertyNames custPrpMgr
    prpNames
    |> Seq.map(fun name -> 
        let x =
            CustomPropertyManagerUtils.tryResolvedValOut name custPrpMgr
        x
        |> Option.map(fun v -> name, v)
    )
    /// 长度，说明，材料，数量等属性的值列表
let GetCutListItemFields (custPrpMgr: CustomPropertyManager) =
    cutListItemFieldNames
    |> List.map(fun ce ->
        CustomPropertyManagerUtils.pickResolvedValOut ce custPrpMgr
    )




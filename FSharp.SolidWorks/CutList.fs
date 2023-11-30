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

/// 疑问：这个程序获取得是SolidBodyFolder文件夹，还是其中的body？
let updateCutList (swModel: IModelDoc2) =
    let swBodyFolder =
        swModel
        |> ModelDoc2Utils.getFeatureSeq
        |> Seq.pick(fun feat ->
            if feat.GetTypeName2() = "SolidBodyFolder" then
                let swBodyFolder = feat.GetSpecificFeature2():?> BodyFolder
                Some swBodyFolder
            else None
        )
    swBodyFolder.UpdateCutList()
    |> ignore

let getCutList(swModel: IModelDoc2) =
    swModel
    |> ModelDoc2Utils.getFeatureSeq
    |> Seq.filter(fun feat -> feat.GetTypeName2() = "CutListFolder")

let getSubCutLists(swModel: ModelDoc2) =
    swModel
    |> getCutList
    |> Seq.collect(fun feat ->
        FeatureUtils.getSubFeatureSeq feat
    )

let getCutListCustomPropertyManager (swModel:ModelDoc2) =
    swModel
    |> getCutList
    |> Seq.map(fun feat -> feat.CustomPropertyManager)

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
        name, custPrpMgr |> CustomPropertyManagerUtils.get6 name false
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

// 焊件偏爱值的自动设置
let setWeldmentUserPreference (swModel: ModelDoc2) =
    let docPref = DocUserPreference(swModel)
    let opt = swUserPreferenceOption_e.swDetailingNoOptionSpecified

    docPref.swWeldmentEnableAutomaticCutList opt <- true

    docPref.swWeldmentEnableAutomaticUpdate opt <- true

    docPref.swWeldmentRenameCutlistDescriptionPropertyValue opt <- true

    docPref.swWeldmentCollectIdenticalBodies opt <- true

    docPref.swDisableDerivedConfigurations opt <- false




    //let toggle (v:bool) (x:swUserPreferenceToggle_e) =
    //    swModel
    //    |> ModelDoc2Utils.setUserPreferenceToggle
    //        x swUserPreferenceOption_e.swDetailingNoOptionSpecified v
    //    |> ignore

    //swUserPreferenceToggle_e.swWeldmentEnableAutomaticCutList
    //|> toggle true

    //swUserPreferenceToggle_e.swWeldmentEnableAutomaticUpdate
    //|> toggle true

    //swUserPreferenceToggle_e.swWeldmentRenameCutlistDescriptionPropertyValue
    //|> toggle true

    //swUserPreferenceToggle_e.swWeldmentCollectIdenticalBodies
    //|> toggle true

    //swUserPreferenceToggle_e.swDisableDerivedConfigurations
    //|> toggle false


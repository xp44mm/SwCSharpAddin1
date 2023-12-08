module FeatMgrTraversal

open System
open System.Runtime.InteropServices
open System.Collections
open System.Collections.Generic
open System.Drawing
open System.Diagnostics
open System.Reflection
open System.Text.RegularExpressions
open System.IO

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

open FSharp.Idioms.Literal
open FSharp.SolidWorks

/// 7.4.1, 7.4.2
let msg (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2

    swModel
    |> ModelDoc2Utils.getFeatureSeq
    |> Seq.map(fun swFeature ->
        let FeatName = swFeature.Name
        let FeatType = swFeature.GetTypeName2()
        $"{FeatName} & {FeatType}"
    )
    |> String.concat "\n"
    |> swApp.SendMsgToUser

/// 7.4.3
let suppress (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2

    swModel
    |> ModelDoc2Utils.getFeatureSeq
    |> Seq.filter(fun swFeature -> 
        swFeature.GetTypeName2() = "Fillet"
        )
    |> Seq.iter(fun swFeature ->
        swFeature.SetSuppression2(
            SuppressionState = int swFeatureSuppressionAction_e.swSuppressFeature,
            Config_opt = int swInConfigurationOpts_e.swThisConfiguration, 
            Config_names = "")
        |> ignore
    )

/// 7.4.4
let setUIState (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2

    swModel
    |> ModelDoc2Utils.getFeatureSeq
    |> Seq.iter(fun swFeature ->
        swFeature.SetUIState(
        StateType = int swUIStates_e.swIsHiddenInFeatureMgr,
        Flag = true
        )
        //|> FeatureUtils.setUIState true
    )
    swModel.FeatureManager.UpdateFeatureTree()

/// 7.4.5
let featureByPositionReverse (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2

    let swFeature = 
        swModel.FeatureByPositionReverse(Num=2)
        :?> Feature
    let FeatName = swFeature.Name
    let FeatType = swFeature.GetTypeName2()
    swApp.SendMsgToUser($"Feature screen name = {FeatName};Feature type name = {FeatType}")

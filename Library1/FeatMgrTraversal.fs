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

open FSharp.Literals.Literal

let getFeatureSeq (swModel: ModelDoc2) =
    let rec loop (o:obj) =
        seq {
            match o with
            | null -> ()
            | :? Feature as f ->
                yield f
                yield! loop (f.GetNextFeature())
            | _ -> failwith $"{o.GetType()}"
        }
    swModel.FirstFeature() |> loop

/// 7.4.2
let msg
    (swApp: SldWorks)
    (swModel: ModelDoc2)
    =

    swModel
    |> getFeatureSeq
    |> Seq.iter(fun swFeature ->
        let FeatName = swFeature.Name
        let FeatType = swFeature.GetTypeName2()
        swFeature.Select2( false, 0)
        |> ignore
        swApp.SendMsgToUser("Feature screen name = " + FeatName + ";Feature type name = " + FeatType)
    )

/// 7.4.3
let suppr
    (swApp: SldWorks)
    (swModel: ModelDoc2)
    =

    swModel
    |> getFeatureSeq
    |> Seq.iter(fun swFeature ->
        let FeatName = swFeature.Name
        let FeatType = swFeature.GetTypeName2()

        //swFeature.Select2( false, 0)
        //|> ignore
        if FeatType = "Fillet" then
          let suppressSet =
            swFeature.SetSuppression2(
                int swFeatureSuppressionAction_e.swUnSuppressFeature,
                int swInConfigurationOpts_e.swThisConfiguration, "")
          ()
    )


/// 7.4.4
let hid
    (swApp: SldWorks)
    (swModel: ModelDoc2)
    =

    swModel
    |> getFeatureSeq
    |> Seq.iter(fun swFeature ->
        swFeature.SetUIState(int swUIStates_e.swIsHiddenInFeatureMgr, true)
    )

    swModel.FeatureManager.UpdateFeatureTree()


/// 7.4.5
let pos
    (swApp: SldWorks)
    (swModel: ModelDoc2)
    =
    let swFeature = 
        swModel.FeatureByPositionReverse(2)
        |> unbox<Feature>
    let FeatName = swFeature.Name
    let FeatType = swFeature.GetTypeName2()
    swApp.SendMsgToUser("Feature screen name = " + FeatName + ";Feature type name = " + FeatType)

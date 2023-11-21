module FSharp.SolidWorks.FeatureUtils

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

///第一层特征,从组件，或ModelDoc获得first feature
let getFeatureSeq (featObj: obj) =
    let rec loop (o:obj) =
        seq {
            match o with
            | null -> ()
            | :? Feature as f ->
                yield f
                yield! loop (f.GetNextFeature())
            | _ -> failwith $"{o.GetType()}"
        }
    loop featObj

let getSubFeatureSeq (parent:Feature) =
    let rec loop (featObj:obj) =
        seq {
            match featObj with
            | null -> ()
            | :? Feature as f ->
                yield f
                yield! loop (f.GetNextSubFeature())
            | _ -> failwith $"{featObj.GetType()}"
        }
    parent.GetFirstSubFeature()
    |> loop

let setSuppression2
    (suppressionState:swFeatureSuppressionAction_e)
    (config_opt:swInConfigurationOpts_e)
    (config_names:string[])
    (swFeat:IFeature)
    =
    swFeat.SetSuppression2(
        int suppressionState,
        int config_opt,
        config_names)
    |> ignore

let setUIState (states:swUIStates_e) (flag:bool) (swFeature:IFeature) =
    swFeature.SetUIState(int states, flag)

type FeatureNode = FeatureNode of Feature * FeatureNode []

let traverseFeatureNodes (swFeat:Feature) =
    let rec loop (swParentFeat:Feature) =
        swParentFeat
        |> getSubFeatureSeq
        |> Seq.map(fun swParentFeat -> 
            FeatureNode(swParentFeat,loop swParentFeat))
        |> Seq.toArray

    swFeat
    |> getFeatureSeq
    |> Seq.map(fun swFeat -> FeatureNode(swFeat,loop swFeat))
    |> Seq.toArray

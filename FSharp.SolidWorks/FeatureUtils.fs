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

///第一层特征
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

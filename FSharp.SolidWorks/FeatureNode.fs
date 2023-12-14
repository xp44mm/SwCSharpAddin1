namespace FSharp.SolidWorks

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

type FeatureNode = 
    | FeatureNode of Feature * FeatureNode []

    static member from (swFeat: Feature) =
        let rec loop (swParentFeat: Feature) =
            swParentFeat
            |> FeatureUtils.getSubFeatureSeq
            |> Seq.map(fun swParentFeat -> 
                FeatureNode(swParentFeat,loop swParentFeat)
                )
            |> Seq.toArray

        swFeat
        |> FeatureUtils.getFeatureSeq
        |> Seq.map(fun swFeat -> 
            FeatureNode(swFeat, loop swFeat)
            )
        |> Seq.toArray

module FSharp.SolidWorks.Component2Utils

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open SolidWorks.Interop.SWRoutingLib

open System
open System.Diagnostics
open System.IO

let GetChildren (swComp:Component2) =
    swComp.GetChildren()
    |> unbox<obj[]>
    |> Array.map(unbox<Component2>)

let renderComponent2 (swComp:Component2) =
    swComp.Name2 + " <" + swComp.ReferencedConfiguration + ">"

///第一层特征
let getFeatureSeq (swComp: Component2) =
    swComp.FirstFeature()
    |> FeatureUtils.getFeatureSeq


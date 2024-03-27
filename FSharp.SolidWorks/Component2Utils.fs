module FSharp.SolidWorks.Component2Utils

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO

let tryGetModelDoc2 (swComp:Component2) = 
    match swComp.GetModelDoc2() :?> ModelDoc2 with
    | null -> None
    | swModel -> Some swModel

///第一层特征
let getFeatureSeq (swComp: Component2) =
    swComp.FirstFeature()
    |> FeatureUtils.getFeatureSeq

let getChildren (swComp:Component2) =
    swComp.GetChildren()
    :?> obj[]
    |> Array.map(fun o -> o :?> Component2)

let renderComponent2 (swComp:Component2) =
    [
        swComp.DisplayTitle
        $"({swComp.ReferencedConfiguration})"
        "{" + swComp.ComponentReference + "}"
    ]
    |> String.concat ""
    |> (+) "+"


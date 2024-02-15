module FSharp.SolidWorks.Component2Utils

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO

let getModelDoc2 (swComp:Component2) = 
    swComp.GetModelDoc2() 
    :?> ModelDoc2

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


module FSharp.SolidWorks.Component2Utils

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO

let getModelDoc2 (swComp:Component2) = 
    swComp.GetModelDoc2() 
    :?> ModelDoc2

let activeConfiguration (swComp:Component2) = 
    let swModel = swComp |> getModelDoc2
    swModel.ConfigurationManager.ActiveConfiguration

///第一层特征
let getFeatureSeq (swComp: Component2) =
    swComp.FirstFeature()
    |> FeatureUtils.getFeatureSeq

let renderComponent2 (swComp:Component2) =
    $"{swComp.Name2}<{swComp.ReferencedConfiguration}>"

let getChildren (swComp:Component2) =
    swComp.GetChildren()
    :?> obj[]
    |> Array.map(fun o -> o :?> Component2)


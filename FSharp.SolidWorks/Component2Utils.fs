module FSharp.SolidWorks.Component2Utils

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open SolidWorks.Interop.SWRoutingLib

open System
open System.Diagnostics
open System.IO

let getModelDoc2 (swComp:Component2) = 
    swComp.GetModelDoc2() 
    |> unbox<ModelDoc2>

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
    |> unbox<obj[]>
    |> Array.map(unbox<Component2>)

type Component2Node = Component2Node of Component2 * Component2Node []

let rec traverseComponent2Node (swComp:Component2) =
    let children =
        swComp
        |> getChildren
        |> Array.map traverseComponent2Node
    Component2Node(swComp, children)
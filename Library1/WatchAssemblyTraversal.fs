module rec WatchAssemblyTraversal

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO
open System.Text

open FSharp.SolidWorks

// This code demonstrates how to traverse an assembly and create a list of
// All of its components. You could use this code to create a bill of materials.
// Also in this code we traverse all of the features in each component and
// print them underneath the component in the list.

// Macro Entry point
let main (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> ModelDoc2
    let swConfigMgr = swModel.ConfigurationManager
    // Get the active config
    let swConf = swConfigMgr.ActiveConfiguration
    // Get it's root component
    let swRootComp = swConf.GetRootComponent3(true)

    let outp =
        [
            swModel.GetPathName()

            //// traverse all of the assembly features
            //TraverseModelFeatures 1 swModel

            // Now traverse all of the components and sub assemblies
            TraverseComponent 0 swRootComp swModel
        ]
        |> String.concat "\n"
    //|> swApp.SendMsgToUser
    let path = Path.Combine(Dir.CommandData,"WatchAssemblyTraversal.txt")
    File.WriteAllText(path,outp)
    swApp.SendMsgToUser path

// this code recursively traverses all of the
// features in a model
let TraverseModelFeatures (nLevel:int) (swModel :ModelDoc2) =
    let swFeat = swModel.FirstFeature() :?> Feature
    TraverseFeatureFeatures nLevel swFeat

// this recursively traverses all of the components in an
// assembly and prints their name to the immediate window
let TraverseComponent (nLevel:int) (swRootComp:Component2) (swRootModel:ModelDoc2) =
    let rec loop (nLevel:int) (data:ComponentData) =
        let sPadStr = String.replicate (nLevel*2) " "
        [
            match data.SpecificModelDoc with
            | ModelSpecific.ModelPart part ->
                yield $"{sPadStr}+{Component2Utils.renderComponent2 data.Component2}"
            | ModelSpecific.ModelAssembly assy ->
                yield $"{sPadStr}+{Component2Utils.renderComponent2 data.Component2}"
                for child in data.getChildren() do
                    yield! loop (nLevel+1) child
            | _ -> failwith ""
        ]

    //根组件要手动展开
    //根组件的引用的模型文件为空，文件就是模型自己。
    let rootData = ComponentData.from(-1, swRootComp, swRootModel)

    loop nLevel rootData
    |> String.concat "\n"

// this recursively traverses all of the components features
let TraverseComponentFeatures (nLevel:int) (swComp:Component2) =
    let swFeat = swComp.FirstFeature()
    TraverseFeatureFeatures nLevel swFeat

// recursively traversing the feature's features
let TraverseFeatureFeatures (nLevel:int) (swFeat:Feature) =
    let rec loop (nLevel:int) (swFeatNode:FeatureNode) =
        let sPadStr = String.replicate (nLevel*2) " "
        [
            match swFeatNode with
            | FeatureNode(swFeat,children) ->
                $"{sPadStr}{swFeat.Name} [{swFeat.GetTypeName2()}]"
                if Array.isEmpty children then
                    ()
                else
                    for child in children do
                        yield! loop (nLevel + 1) child
        ]

    swFeat
    |> FeatureNode.from
    |> Seq.collect(loop nLevel)
    |> String.concat "\n"

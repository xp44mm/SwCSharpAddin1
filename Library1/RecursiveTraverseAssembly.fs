namespace Library1

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO
open FSharp.SolidWorks

type RecursiveTraverseAssembly(swApp: ISldWorks) = 
    let logfile = "d:/RecursiveTraverseAssembly.txt"

    let getPipeInfo (swComp:Component2) =
        let swModel = 
            swComp
            |> Component2Utils.getModelDoc2
        let config = swModel.ConfigurationManager.ActiveConfiguration
        let swCustPrpMgr = swModel.Extension.CustomPropertyManager(config.Name)
        let prpName = "SWPipeLength"

        if CustomPropertyManagerUtils.contains prpName swCustPrpMgr then
            //属性值带单位
            let pipeLength = CustomPropertyManagerUtils.resolvedValOut prpName swCustPrpMgr
            $"pipeLength = {pipeLength}\n"
        else "其他零件：弯头，三通，大小头"

    let traverseComponent (swComp:Component2) =
        let rec loop (nLevel:int) (swCompNode:Component2Node) =
            let pad = String.replicate nLevel "    "

            [
                match swCompNode with
                | Component2Node(swComp,[||]) ->
                    $"{pad}+{getPipeInfo swComp}\n"
                | Component2Node(swComp,children) ->
                    $"{pad}+{Component2Utils.renderComponent2 swComp}\n"
                    for child in children do
                        yield! loop (nLevel + 1) child
            ]

        swComp
        |> Component2Node.from
        |> loop 0
        |> String.concat "\n"

    let TraverseFeatureFeatures(swFeat:Feature) =
        let rec loop (nLevel:int) (swFeatNode:FeatureNode) =
            let pad = String.replicate nLevel "    "
            [
                match swFeatNode with
                | FeatureNode(x,[||]) ->
                    $"{pad}+{x}\n"
                | FeatureNode(x,children) ->
                    $"{pad}+{x}\n"
                    for child in children do
                        yield! loop (nLevel + 1) child
            ]

        swFeat
        |> FeatureNode.from
        |> Seq.collect(loop 0)
        |> String.concat "\n"

    let TraverseComponentFeatures (swComp:Component2) (nLevel:int) =
        let swFeat = swComp.FirstFeature()
        TraverseFeatureFeatures swFeat

    let TraverseModelFeatures (swModel:ModelDoc2) (nLevel:int) =
        let swFeat = swModel.FirstFeature() :?> Feature
        TraverseFeatureFeatures swFeat

    member _.Main() =
        if File.Exists(logfile) then File.Delete logfile

        let swModel = 
            swApp
            |> SldWorksUtils.activeDoc 

        let swConfMgr = swModel.ConfigurationManager
        let swConf = swConfMgr.ActiveConfiguration
        let swRootComp = 
            swConf
            |> ConfigurationUtils.getRootComponent

        File.AppendAllText(logfile,$"File = {swModel.GetPathName()}\n")
        File.AppendAllText(logfile,$"{Component2Utils.renderComponent2 swRootComp}\n")

        traverseComponent swRootComp


namespace Library1

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open SolidWorks.Interop.SWRoutingLib

open System
open System.Diagnostics
open System.IO

type RecursiveTraverseAssembly(swApp: ISldWorks) = 
    let logfile = "d:/RecursiveTraverseAssembly.txt"

    let rec TraverseFeatureFeatures(swFeat:Feature) (nLevel:int) =
        //Feature swSubFeat
        //Feature swSubSubFeat
        //Feature swSubSubSubFeat
        let mutable sPadStr = " "
        for i in [ 0 .. nLevel] do
            sPadStr <- sPadStr + " "
        //1
        while swFeat <> null do
            File.AppendAllText(logfile,sPadStr + swFeat.Name + " [" + swFeat.GetTypeName2() + "]")
            let swSubFeat = swFeat.GetFirstSubFeature() |> unbox<Feature>
            //2
            while swSubFeat <> null do
                File.AppendAllText(logfile,sPadStr + "  " + swSubFeat.Name + " [" + swSubFeat.GetTypeName() + "]")
                let swSubSubFeat = swSubFeat.GetFirstSubFeature() |> unbox<Feature>
                //3
                while swSubSubFeat <> null do
                    File.AppendAllText(logfile,sPadStr + "    " + swSubSubFeat.Name + " [" + swSubSubFeat.GetTypeName() + "]");
                    let swSubSubSubFeat = swSubSubFeat.GetFirstSubFeature() |> unbox<Feature>
                    //4
                    while swSubSubSubFeat <> null do
                        File.AppendAllText(logfile,sPadStr + "      " + swSubSubSubFeat.Name + " [" + swSubSubSubFeat.GetTypeName() + "]")
                        let swSubSubSubFeat = swSubSubSubFeat.GetNextSubFeature() |> unbox<Feature>
                        ()

                    let swSubSubFeat = swSubSubFeat.GetNextSubFeature() |> unbox<Feature>
                    ()

                let swSubFeat = swSubFeat.GetNextSubFeature() |> unbox<Feature> 
                ()

            let swFeat = swFeat.GetNextFeature() |> unbox<Feature>
            ()
    let TraverseComponentFeatures (swComp:Component2) (nLevel:int) =
        let swFeat = swComp.FirstFeature() |> unbox<Feature>
        TraverseFeatureFeatures swFeat nLevel

    let TraverseModelFeatures (swModel:ModelDoc2) (nLevel:int) =
        let swFeat = swModel.FirstFeature() |> unbox<Feature>
        TraverseFeatureFeatures swFeat nLevel

    let rec TraverseComponent (swComp:Component2) (nLevel:int) =
        let sPadStr = String.replicate nLevel "    "

        match Component2Utils.GetChildren swComp with
        | [||] ->
            let swCustPrpMgr = 
                let swModel = 
                    swComp.GetModelDoc2() 
                    |> unbox<ModelDoc2>
                let config = swModel.ConfigurationManager.ActiveConfiguration
                swModel.Extension.CustomPropertyManager(config.Name)
            let prpName = "SWPipeLength"

            if CustomPropertyManagerUtils.contains prpName swCustPrpMgr then
                //属性值带单位
                let pipeLength = CustomPropertyManagerUtils.resolvedValOut prpName swCustPrpMgr
                File.AppendAllText(logfile,$"pipeLength = {pipeLength}\n")

        | children ->
            for swChildComp in children do
                File.AppendAllText(logfile,$"{sPadStr}+{Component2Utils.renderComponent2 swChildComp}\n")
                TraverseComponent swChildComp (nLevel + 1)

    member _.Main() =
        let swModel = 
            swApp.ActiveDoc 
            |> unbox<ModelDoc2>

        let swConfMgr = swModel.ConfigurationManager
        let swConf = swConfMgr.ActiveConfiguration
        let swRootComp = 
            swConf.GetRootComponent() 
            |> unbox<Component2>

        if File.Exists(logfile) then File.Delete logfile

        File.AppendAllText(logfile,"File = " + swModel.GetPathName()+"\n")
        File.AppendAllText(logfile,$"{Component2Utils.renderComponent2 swRootComp}\n")

        TraverseComponent swRootComp 1


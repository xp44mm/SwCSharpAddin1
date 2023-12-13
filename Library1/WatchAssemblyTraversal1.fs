module rec WatchAssemblyTraversal1

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO
open FSharp.SolidWorks
open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO
open FSharp.SolidWorks

//'Macro Entry point
let main (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> ModelDoc2
    let swConfigMgr = swModel.ConfigurationManager
    //'Get the active config
    let swConf = swConfigMgr.ActiveConfiguration
    //'Get it's root component
    let swRootComp = swConf.GetRootComponent3(true)

    let File = swModel.GetPathName()
  
    //'traverse all of the assembly features
    TraverseModelFeatures 1 swModel

    //'Now traverse all of the components and sub assemblies
    TraverseComponent 1 swRootComp

let TraverseModelFeatures (nLevel:int) (swModel :ModelDoc2) =
    //'this code recursively traverses all of the
    //'features in a model
    let swFeat = swModel.FirstFeature() :?> Feature
    TraverseFeatureFeatures nLevel swFeat

//
let TraverseFeatureFeatures (nLevel:int) (swFeat:Feature) =
    //'recursively traversing the feature's features
    let sPadStr = String.replicate nLevel "  "
    let outl = $"{sPadStr}{swFeat.Name} [{swFeat.GetTypeName2()}]"
    let swSubFeat = swFeat.GetFirstSubFeature() :?> Feature
    let outl = $"{sPadStr}  {swSubFeat.Name} [{swSubFeat.GetTypeName2()}]"

    let swSubSubFeat = swSubFeat.GetFirstSubFeature() :?> Feature
    let outl = $"{sPadStr}    {swSubSubFeat.Name} [{swSubSubFeat.GetTypeName2()}]"

    let swSubSubSubFeat = swSubFeat.GetFirstSubFeature() :?> Feature
    let swSubSubSubFeat = swSubSubSubFeat.GetNextSubFeature() :?> Feature
    let swSubSubFeat = swSubSubFeat.GetNextSubFeature() :?> Feature
    let swSubFeat = swSubFeat.GetNextSubFeature() :?> Feature
    let swFeat = swFeat.GetNextFeature() :?> Feature
    ()

let TraverseComponent (nLevel:int) (swComp:Component2) =
    //'this recursively traverses all of the components in an
    //'assembly and prints their name to the immediate window
    let sPadStr = String.replicate nLevel "  "
  
    let vChildComp = 
        swComp.GetChildren() :?> obj[]
        |> Array.map(fun obj -> obj :?> Component2)

    let swChildComp = vChildComp.[0]
    let outl = $"{sPadStr}+{swChildComp.Name2} <{swChildComp.ReferencedConfiguration}>"

    TraverseComponentFeatures nLevel swChildComp
    TraverseComponent (nLevel+1) swChildComp

let TraverseComponentFeatures (nLevel:int) (swComp:Component2) =
    //'this recursively traverses all of the components features
    let swFeat = swComp.FirstFeature()
    TraverseFeatureFeatures nLevel swFeat

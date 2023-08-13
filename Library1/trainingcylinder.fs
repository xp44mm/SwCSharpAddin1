module trainingcylinder

open System
open System.Runtime.InteropServices
open System.Collections
open System.Collections.Generic
open System.Diagnostics
open System.Reflection
open System.Text.RegularExpressions
open System.IO

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

/// 画一个圆柱体
let main(swApp: ISldWorks) =
    let swModel = 
        swApp.ActiveDoc 
        |> unbox<ModelDoc2>

    let boolstatus = 
        swModel.Extension.SelectByID2("前视基准面", "PLANE", 0.0, 0.0, 0.0, false, 0, null, 0)
    swModel.SketchManager.InsertSketch true
    let skSegment = swModel.SketchManager.CreateCircleByRadius(0.0, 0.0, 0.0, 0.04)
    let myFeature = swModel.FeatureManager.FeatureExtrusion3(true, false, false, 0, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433e-02, 1.74532925199433e-02, false, false, false, false, true, true, true, 0, 0, false)
    ()
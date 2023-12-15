﻿module training1

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
open FSharp.SolidWorks
//open FSharp.SolidWorks.FeatureManagerUtils

/// 画一个圆柱体
let main(swApp: ISldWorks) =
    let swModel =
        swApp.ActiveDoc
        :?> ModelDoc2

    let boolstatus =
        swModel.Extension.SelectByID2("Front Plane", "PLANE", 0.0, 0.0, 0.0, false, 0, null, 0)
    swModel.SketchManager.InsertSketch true
    let skSegment = swModel.SketchManager.CreateCircleByRadius(0.0, 0.0, 0.0, 0.04)
    let myFeature = swModel.FeatureManager.FeatureExtrusion3(true, false, false, 0, 0, 0.01, 0.01, false, false, false, false, 1.74532925199433e-02, 1.74532925199433e-02, false, false, false, false, true, true, true, 0, 0, false)
    ()

let exec (swApp: ISldWorks) =
    let swModel =
        swApp.ActiveDoc :?> ModelDoc2

    swModel
    |> ModelDoc2Utils.selectByID {|
        name         = "Front Plane"
        stype        = "PLANE"
        location     = (0.0, 0.0, 0.0)
        append       = false
        mark         = 0
        selectOption = swSelectOption_e.swSelectOptionDefault
        |}

    swModel.SketchManager.InsertSketch true

    swModel.SketchManager
    |> SketchManagerUtils.createCircleByRadius (0.0, 0.0, 0.0) 0.04

    swModel.FeatureManager
    |> FeatureManagerUtils.featureExtrusion {
        sd = true
        flip = false
        dir = false
        direction1 = {
            EndCond = FeatureManagerUtils.EndCond.Blind 0.01
            Drafting = None }
        direction2 = {
            EndCond = FeatureManagerUtils.EndCond.Blind 0.0
            Drafting = None }
        merge = true
        useFeatScope = true
        useAutoSelect = true
        startCond = FeatureManagerUtils.StartCondition.SketchPlane
    }

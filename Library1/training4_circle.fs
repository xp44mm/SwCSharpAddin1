module training4_circle // PartAutomation1

open System
open System.Runtime.InteropServices
open System.Collections
open System.Collections.Generic
open System.Drawing
open System.Diagnostics
open System.Reflection
open System.Text.RegularExpressions
open System.IO

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

open FSharp.Idioms.Literal
open FSharp.SolidWorks
open FSharp.SolidWorks.FeatureManagerUtils

//else
let drawCircle (radius:float) offset (swModel: IModelDoc2) =
    swModel.SketchManager
    |> SketchManagerUtils.createCircleByRadius (0.05 + radius, 0.05 + radius, 0.0) radius
    |> ignore

    swModel.SketchManager
    |> SketchManagerUtils.sketchOffset {|
        offset = offset
        bothDirections = false
        chain = true
        capEnds = swSkOffsetCapEndType_e.swSkOffsetArcCaps
        makeConstruction = swSkOffsetMakeConstructionType_e.swSkOffsetDontMakeConstruction
        addDimensions = false
    |}
    |> ignore

let contourCircle (radius:float) offset (swModel: IModelDoc2) =
    let smgr = swModel.SelectionManager :?> SelectionMgr
    smgr.EnableContourSelection <- true

    let circleContour1 =
        swModel
        |> ModelDoc2Utils.selectByID2 "" "SKETCHCONTOUR" (0.05 + radius, 0.05, 0.) true 0 swSelectOption_e.swSelectOptionDefault

    let circleContour2 =
        swModel
        |> ModelDoc2Utils.selectByID2 "" "SKETCHCONTOUR" (0.05 - offset, 0.05 + radius, 0.) true 0 swSelectOption_e.swSelectOptionDefault

    smgr.EnableContourSelection <- false

let circleExtrusion (swApp: ISldWorks) =
    let swModel = training4.newPart swApp
    swModel.SketchManager.AddToDB <- true

    swModel
    |> training4.InsertSketchOnFront

    drawCircle 0.2 0.002 swModel
    swModel.SketchManager.AddToDB <- false

    contourCircle 0.2 0.002 swModel
    training4.drawFeatureExtrusion 0.3 swModel

    swModel.ViewZoomtofit2()

let circleRevolve (swApp: ISldWorks) =
    let swModel = training4.newPart swApp
    swModel.SketchManager.AddToDB <- true

    swModel
    |> training4.InsertSketchOnFront

    drawCircle 0.2 0.002 swModel
    training4.createRevolveAxis swModel
    swModel.SketchManager.AddToDB <- false

    contourCircle 0.2 0.002 swModel
    training4.drawFeatureRevolve 90.0 swModel

    swModel.ViewZoomtofit2()







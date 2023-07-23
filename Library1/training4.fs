module training4

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

open FSharp.Literals.Literal

let testPartMat (swApp: ISldWorks) =
    let swModel =
        swApp.ActiveDoc 
        |> unbox<ModelDoc2>
    //MATERIAL
    let swPart = swModel :?> PartDoc

    let setPartMat (mat:string) =
        /// 设置零件，当前配置，当前材料数据库
        swPart.SetMaterialPropertyName2("", "", mat)
        let mat1,db1 = swPart.GetMaterialPropertyName2 ""
        swApp.SendMsgToUser $"{mat1},{db1}"
    setPartMat "1060 Alloy"
    setPartMat "Brass"

let newPart (swApp: ISldWorks) =
    // Get the file path of the default part template
    let partTemplate = swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDefaultTemplatePart)
    let swModel = 
        swApp.NewDocument(partTemplate, 0, 0.0, 0.0)
        |> unbox<ModelDoc2>
    swModel.Extension.SetUserPreferenceInteger(
        int swUserPreferenceIntegerValue_e.swUnitsLinear, 
        int swUserPreferenceOption_e.swDetailingNoOptionSpecified,
        int swLengthUnit_e.swMM)
    |> ignore
    swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swInputDimValOnCreate, false)
    swModel

let drawSketch draw (swModel: ModelDoc2) (swApp: ISldWorks) =
    swModel.SketchManager.AddToDB <- true
  
    //PROFILE
    let boolstatus = swModel.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0)
    swModel.SketchManager.InsertSketch false
    //Turn off dimension dialogs

    draw swModel
    swModel.ViewZoomtofit2()
    swModel.SketchManager.AddToDB <- false

let drawRect height width (swModel: ModelDoc2) =
    //if optRectangular.value = true then
    //txtRadius.enabled <- false

    //let SketchSegmentObj:SldWorks.SketchSegment
    //Create the first line in the profile
    let SketchSegmentObj = swModel.SketchManager.CreateLine(0.05, 0.05, 0, 0.05, 0.05 + height, 0.0)

    //Add a dimension to the selected entity
    swModel.Extension.AddDimension(0.0, 0.05 + height / 2.0, 0.0, int swSmartDimensionDirection_e.swSmartDimensionDirection_Down)
    |> ignore
    swModel.SketchManager.CreateLine( 0.05, 0.05 + height, 0.0, 0.05 + width, 0.05 + height, 0.0)
    |> ignore
    swModel.SketchManager.CreateLine( 0.05 + width, 0.05 + height, 0, 0.05 + width, 0.05, 0.0)
    |> ignore
    swModel.SketchManager.CreateLine( 0.05 + width, 0.05, 0, 0.05, 0.05, 0.0)
    |> ignore
    swModel.Extension.AddDimension( 0.05 + width / 2.0, 0.0, 0.0, int swSmartDimensionDirection_e.swSmartDimensionDirection_Down)
    |> ignore

    swModel.ClearSelection2 true
    //Select the origin
    swModel.Extension.SelectByID2( "", "EXTSKETCHPOINT", 0, 0, 0, false, 0, null, 0)
    |> ignore

    //Select an end point on the profile
    swModel.Extension.SelectByID2( "", "SKETCHPOINT", 0.05, 0.05, 0, true, 0, null, 0)
    |> ignore

    //Add a vertical dimension
    swModel.AddVerticalDimension2( 0, 0.025, 0)
    |> ignore

    swModel.ClearSelection2 true

    //Select the origin
    swModel.Extension.SelectByID2( "", "EXTSKETCHPOINT", 0, 0, 0, false, 0, null, 0)
    |> ignore

    //Select an end point on the profile
    swModel.Extension.SelectByID2( "", "SKETCHPOINT", 0.05, 0.05, 0, true, 0, null, 0)
    |> ignore

    //Add a horizontal dimension
    //to fully constrain the sketch
    swModel.AddHorizontalDimension2( 0.025, 0, 0)
    |> ignore

    swModel.ClearSelection2 true

    //Select a profile edge
    SketchSegmentObj.Select4( false, null)
    |> ignore

    //Create the offset sketch profile from the selected edge
    //and its chain of sketch entities
    swModel.SketchManager.SketchOffset2(0.002, false, true, 
        int swSkOffsetCapEndType_e.swSkOffsetArcCaps, int swSkOffsetMakeConstructionType_e.swSkOffsetDontMakeConstruction, 
        false)
    |> ignore

//else
let drawCircle (radius:float) (swModel: ModelDoc2) =
    swModel.SketchManager.CreateCircleByRadius(0.05 + radius, 0.05 + radius, 0, radius)
    |> ignore

    swModel.SketchManager.SketchOffset2(0.002, false, true, 
        int swSkOffsetCapEndType_e.swSkOffsetArcCaps, int swSkOffsetMakeConstructionType_e.swSkOffsetDontMakeConstruction, 
        false)
    |> ignore


let testDrawRect (swApp: ISldWorks) =
    let swModel = newPart swApp
    drawSketch (drawRect 0.2 0.1) swModel swApp

let testDrawCirc (swApp: ISldWorks) =
    let swModel = newPart swApp
    drawSketch (drawCircle 0.2) swModel swApp

let mainFeatureExtrusion (depth:float) (swModel: ModelDoc2) =
    let swFeatMgr = swModel.FeatureManager
    swFeatMgr.FeatureExtrusion2( true, false, true, 0, 0, depth, 0, false, false, false, false, 0, 0, 
        false, false, false, false, false, false, false, 
        int swStartConditions_e.swStartSketchPlane, 0.0, false)
    |> ignore

let testRectExtrusionUsingSketch (swApp: ISldWorks) =
    let swModel = newPart swApp
    drawSketch (drawRect 0.2 0.1) swModel swApp
    mainFeatureExtrusion 0.3 swModel

let testCircleExtrusionUsingSketch (swApp: ISldWorks) =
    let swModel = newPart swApp
    drawSketch (drawCircle 0.2) swModel swApp
    mainFeatureExtrusion 0.3 swModel

let mainFeatureRevolve (angle) (swModel: ModelDoc2) (swApp: ISldWorks) =
    //else
    let pi:float=Math.PI
    //pi = 4 * Atn(1)
    //let Angle:float
    //Convert to radians
    let Angle = angle * pi / 180.0
    let swFeatMgr = swModel.FeatureManager
    swFeatMgr.FeatureRevolve2( true, true, false, false, false, false, 
        int swEndConditions_e.swEndCondBlind, int swEndConditions_e.swEndCondBlind, Angle, 0.0, false, false, 0.0, 0.0, 
        int swThinWallType_e.swThinWallOneDirection, 0.0, 0.0, true, false, true)
        |> ignore

let testRectRevolveUsingSketch (swApp: ISldWorks) =
    let swModel = newPart swApp
    let draw (swModel) =
        drawRect 0.2 0.1 swModel
        //if Revolve was chosen, an axis of revolution is needed
        swModel.SketchManager.CreateCenterLine (0, 0, 0, 0, 0.05, 0)
        |> ignore
    drawSketch draw swModel swApp
    mainFeatureRevolve 90 swModel swApp

let testCircleRevolveUsingSketch (swApp: ISldWorks) =
    let swModel = newPart swApp
    let draw (swModel) =
        drawCircle 0.2 swModel
        //if Revolve was chosen, an axis of revolution is needed
        swModel.SketchManager.CreateCenterLine (0, 0, 0, 0, 0.05, 0)
        |> ignore
    drawSketch draw swModel swApp
    mainFeatureRevolve 90 swModel swApp

let rectContour1 width (swModel: ModelDoc2) (swApp: ISldWorks) =
    swModel.Extension.SelectByID2("", "SKETCHCONTOUR", 0.05, 0.05 + width / 2.0, 0, true, 0, null, 0)
    |> ignore

let rectContour2 width (swModel: ModelDoc2) (swApp: ISldWorks) =
    swModel.Extension.SelectByID2("", "SKETCHCONTOUR", 0.05 - 0.002, 0.05 + width / 2.0, 0, true, 0, null, 0)
    |> ignore

let circleContour1 (radius:float) (swModel: ModelDoc2) (swApp: ISldWorks) =
    swModel.Extension.SelectByID2( "", "SKETCHCONTOUR", 0.05 + radius, 0.05, 0, true, 0, null, 0)
    |> ignore

let circleContour2 (radius:float) (swModel: ModelDoc2) (swApp: ISldWorks) =
    swModel.Extension.SelectByID2( "", "SKETCHCONTOUR", 0.05 - 0.002, 0.05 + radius, 0, true, 0, null, 0)
    |> ignore

let procContourSelection select (swModel: ModelDoc2) (swApp: ISldWorks) =
    let smgr = swModel.SelectionManager:?>SelectionMgr
    smgr.EnableContourSelection <- true
    select swModel swApp
    smgr.EnableContourSelection <- false

let testRectContourExtrusion (swApp: ISldWorks) =
    let swModel = newPart swApp
    drawSketch (drawRect 0.2 0.1) swModel swApp
    procContourSelection (rectContour1 0.1) swModel swApp
    procContourSelection (rectContour2 0.1) swModel swApp

    mainFeatureExtrusion 0.3 swModel

let testCircleContourExtrusion (swApp: ISldWorks) =
    let swModel = newPart swApp
    drawSketch (drawCircle 0.1) swModel swApp
    let contour swModel swApp =
        circleContour1 0.1 swModel swApp
        circleContour2 0.1 swModel swApp
    procContourSelection contour swModel swApp

    mainFeatureExtrusion 0.3 swModel

let testRectContourRevolve (swApp: ISldWorks) =
    let swModel = newPart swApp
    let draw (swModel) =
        drawRect 0.2 0.1 swModel
        //if Revolve was chosen, an axis of revolution is needed
        swModel.SketchManager.CreateCenterLine (0, 0, 0, 0, 0.05, 0)
        |> ignore
    drawSketch draw swModel swApp
    let contour swModel swApp =
        rectContour1 0.1 swModel swApp
        rectContour2 0.1 swModel swApp
    procContourSelection contour swModel swApp
    mainFeatureRevolve 90 swModel swApp

let testCircleContourRevolve (swApp: ISldWorks) =
    let swModel = newPart swApp
    let draw (swModel) =
        drawCircle 0.1 swModel
        //if Revolve was chosen, an axis of revolution is needed
        swModel.SketchManager.CreateCenterLine (0, 0, 0, 0, 0.05, 0)
        |> ignore
    drawSketch draw swModel swApp
    let contour swModel swApp =
        circleContour2 0.1 swModel swApp
        circleContour1 0.1 swModel swApp
    procContourSelection contour swModel swApp
    mainFeatureRevolve 90 swModel swApp





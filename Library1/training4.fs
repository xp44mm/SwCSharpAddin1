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

open FSharp.Idioms.Literal
open FSharp.SolidWorks

let testPartMat (swModel: IModelDoc2) (swApp: ISldWorks) =
    let setPartMat (mat:string) =
        let swPart = swModel :?> IPartDoc
        /// 设置零件，当前配置，当前材料数据库
        swPart.SetMaterialPropertyName2("", "", mat)
        let mat1,db1 = swPart.GetMaterialPropertyName2 ""
        swApp.SendMsgToUser $"{mat1},{db1}"

    setPartMat "1060 Alloy"
    setPartMat "Brass"

let newPart (swApp: ISldWorks) =
    let swModel = 
        swApp
        |> SldWorksUtils.newPartDoc

    swModel :?> IModelDoc2
    |> ModelDoc2Utils.setUserPreferenceInteger
        swUserPreferenceIntegerValue_e.swUnitsLinear
        swUserPreferenceOption_e.swDetailingNoOptionSpecified
        (int swLengthUnit_e.swMM)

    //Turn off dimension dialogs
    swApp
    |> SldWorksUtils.setUserPreferenceToggle 
        swUserPreferenceToggle_e.swInputDimValOnCreate false

    swModel

/// draw skech PROFILE
let drawSketch draw (swModel: IModelDoc2) (swApp: ISldWorks) =
    swModel.SketchManager.AddToDB <- true
    //PROFILE
    let boolstatus = 
        swModel
        |> ModelDoc2Utils.selectByID2 "Front Plane" "PLANE" (0.0, 0.0, 0.0) false 0 swSelectOption_e.swSelectOptionDefault
    swModel.SketchManager.InsertSketch false

    draw swModel
    swModel.SketchManager.AddToDB <- false
    //swModel.ViewZoomtofit2()

//画个矩形带标注
let drawRect height width (swModel: IModelDoc2) =
    let SketchSegmentObj = 
        swModel.SketchManager
        |> SketchManagerUtils.createLine (0.05, 0.05, 0.0) (0.05, 0.05 + height, 0.0)

    //Add a dimension to the selected entity
    swModel
    |> ModelDoc2Utils.addDimension (0.0, 0.05 + height / 2.0, 0.0) swSmartDimensionDirection_e.swSmartDimensionDirection_Down
    |> ignore

    swModel.SketchManager
    |> SketchManagerUtils.createLine(0.05, 0.05 + height, 0.0) ( 0.05 + width, 0.05 + height, 0.0)
    |> ignore

    swModel.SketchManager
    |> SketchManagerUtils.createLine(0.05 + width, 0.05 + height, 0.0) (0.05 + width, 0.05, 0.0)
    |> ignore

    swModel.SketchManager
    |> SketchManagerUtils.createLine(0.05 + width, 0.05, 0.0) (0.05, 0.05, 0.0)
    |> ignore

    swModel
    |> ModelDoc2Utils.addDimension(0.05 + width / 2.0, 0.0, 0.0) swSmartDimensionDirection_e.swSmartDimensionDirection_Down
    |> ignore

    swModel.ClearSelection2 true

    //Select the origin
    swModel
    |> ModelDoc2Utils.selectByID2 "" "EXTSKETCHPOINT" (0.0, 0.0, 0.0) false 0 swSelectOption_e.swSelectOptionDefault

    //Select an end point on the profile
    swModel
    |> ModelDoc2Utils.selectByID2 "" "SKETCHPOINT" (0.05, 0.05, 0.0) true 0 swSelectOption_e.swSelectOptionDefault

    //Add a vertical dimension
    swModel.AddVerticalDimension2(0, 0.025, 0.0)
    |> ignore

    swModel.ClearSelection2 true

    //Select the origin
    swModel
    |> ModelDoc2Utils.selectByID2 "" "EXTSKETCHPOINT" (0.0, 0.0, 0.0) false 0 swSelectOption_e.swSelectOptionDefault

    //Select an end point on the profile
    swModel
    |> ModelDoc2Utils.selectByID2 "" "SKETCHPOINT" (0.05, 0.05, 0.0) true 0 swSelectOption_e.swSelectOptionDefault
    //|> ignore

    //Add a horizontal dimension
    //to fully constrain the sketch
    swModel.AddHorizontalDimension2(0.025, 0.0, 0.0)
    |> ignore

    swModel.ClearSelection2 true

    //Select a profile edge
    SketchSegmentObj.Select4(false, null)
    |> ignore

    //Create the offset sketch profile from the selected edge
    //and its chain of sketch entities
    swModel.SketchManager
    |> SketchManagerUtils.sketchOffset2 0.002 false true
        swSkOffsetCapEndType_e.swSkOffsetArcCaps
        swSkOffsetMakeConstructionType_e.swSkOffsetDontMakeConstruction
        false

//else
let drawCircle (radius:float) (swModel: IModelDoc2) =
    swModel.SketchManager
    |> SketchManagerUtils.createCircleByRadius (0.05 + radius, 0.05 + radius, 0.0) radius
    |> ignore

    swModel.SketchManager
    |> SketchManagerUtils.sketchOffset2 0.002 false true
        swSkOffsetCapEndType_e.swSkOffsetArcCaps
        swSkOffsetMakeConstructionType_e.swSkOffsetDontMakeConstruction
        false
    |> ignore

//let testDrawRect (swApp: ISldWorks) =
//    let swModel = newPart swApp
//    drawSketch (drawRect 0.2 0.1) swModel swApp

//let testDrawCirc (swApp: ISldWorks) =
//    let swModel = newPart swApp
//    drawSketch (drawCircle 0.2) swModel swApp

let featureExtrusion (depth:float) (swModel: IModelDoc2) =
    swModel.FeatureManager
    |> FeatureManagerUtils.featureExtrusion3 true false true
        {
            t = swEndConditions_e.swEndCondBlind
            d = depth
            dchk = false
            ddir = false
            dang = 0.0   
            offsetReverse = false
            translateSurface = false
        }
        {
            t = swEndConditions_e.swEndCondBlind     
            d = 0
            dchk = false
            ddir = false
            dang = 0.0   
            offsetReverse = false
            translateSurface = false
        }
        false false false
        swStartConditions_e.swStartSketchPlane 0.0 false
    |> ignore

let testRectExtrusionUsingSketch (swApp: ISldWorks) =
    let swModel = newPart swApp :?> ModelDoc2
    drawSketch (drawRect 0.2 0.1) swModel swApp
    featureExtrusion 0.3 swModel

let testCircleExtrusionUsingSketch (swApp: ISldWorks) =
    let swModel = newPart swApp :?> ModelDoc2
    drawSketch (drawCircle 0.2) swModel swApp
    featureExtrusion 0.3 swModel

let featureRevolve (angle) (swModel: IModelDoc2) =
    let angle = angle * Math.PI / 180.0
    let swFeatMgr = swModel.FeatureManager
    swFeatMgr
    |> FeatureManagerUtils.featureRevolve2 true true false false false false
        swThinWallType_e.swThinWallOneDirection
        {
            dirType       = swEndConditions_e.swEndCondBlind
            dirAngle      = angle
            offsetReverse = false
            offsetDistance= 0.0
            thinThickness = 0.0
        }
        {
            dirType       = swEndConditions_e.swEndCondBlind
            dirAngle      = 0.0
            offsetReverse = false
            offsetDistance= 0.0
            thinThickness = 0.0
        }
        true false true
    |> ignore

let testRectRevolveUsingSketch (swApp: ISldWorks) =
    let swModel = newPart swApp :?> IModelDoc2
    let draw (swModel) =
        drawRect 0.2 0.1 swModel
        //if Revolve was chosen, an axis of revolution is needed
        swModel.SketchManager
        |> SketchManagerUtils.createCenterLine(0., 0., 0.)(0., 0.05, 0.)
        |> ignore
    drawSketch draw swModel swApp
    featureRevolve 90.0 swModel

let testCircleRevolveUsingSketch (swApp: ISldWorks) =
    let swModel = newPart swApp :?> IModelDoc2
    let draw (swModel) =
        drawCircle 0.2 swModel
        //if Revolve was chosen, an axis of revolution is needed
        swModel.SketchManager
        |> SketchManagerUtils.createCenterLine(0., 0., 0.)(0., 0.05, 0.)
        |> ignore
    drawSketch draw swModel swApp
    featureRevolve 90 swModel

let procContourSelection selectFn (swModel: IModelDoc2) =
    let smgr = swModel.SelectionManager:?>SelectionMgr
    smgr.EnableContourSelection <- true
    selectFn swModel
    smgr.EnableContourSelection <- false

let rectContour1 width (swModel: IModelDoc2) =
    swModel
    |> ModelDoc2Utils.selectByID2 "" "SKETCHCONTOUR" (0.05, 0.05 + width / 2.0, 0.) true 0 swSelectOption_e.swSelectOptionDefault
    |> ignore

let rectContour2 width (swModel: IModelDoc2) =
    swModel
    |> ModelDoc2Utils.selectByID2 "" "SKETCHCONTOUR" (0.05 - 0.002, 0.05 + width / 2.0, 0.) true 0 swSelectOption_e.swSelectOptionDefault
    |> ignore

let circleContour1 (radius:float) (swModel: IModelDoc2) =
    swModel
    |> ModelDoc2Utils.selectByID2 "" "SKETCHCONTOUR" (0.05 + radius, 0.05, 0.) true 0 swSelectOption_e.swSelectOptionDefault
    |> ignore

let circleContour2 (radius:float) (swModel: IModelDoc2) =
    swModel
    |> ModelDoc2Utils.selectByID2 "" "SKETCHCONTOUR" (0.05 - 0.002, 0.05 + radius, 0.) true 0 swSelectOption_e.swSelectOptionDefault
    |> ignore

let testRectContourExtrusion (swApp: ISldWorks) =
    let swModel = newPart swApp :?> IModelDoc2
    drawSketch (drawRect 0.2 0.1) swModel swApp
    procContourSelection (rectContour1 0.1) swModel
    procContourSelection (rectContour2 0.1) swModel

    featureExtrusion 0.3 swModel

let testCircleContourExtrusion (swApp: ISldWorks) =
    let swModel = newPart swApp :?> IModelDoc2
    drawSketch (drawCircle 0.1) swModel swApp
    let contour swModel =
        circleContour1 0.1 swModel
        circleContour2 0.1 swModel
    procContourSelection contour swModel

    featureExtrusion 0.3 swModel

let testRectContourRevolve (swApp: ISldWorks) =
    let swModel = newPart swApp :?> IModelDoc2
    let draw (swModel) =
        drawRect 0.2 0.1 swModel
        //if Revolve was chosen, an axis of revolution is needed
        swModel.SketchManager
        |> SketchManagerUtils.createCenterLine (0., 0., 0.) (0., 0.05, 0.)
        |> ignore
    drawSketch draw swModel swApp
    let contour swModel =
        rectContour1 0.1 swModel
        rectContour2 0.1 swModel
    procContourSelection contour swModel
    featureRevolve 90 swModel

let testCircleContourRevolve (swApp: ISldWorks) =
    let swModel = newPart swApp :?> IModelDoc2
    let draw (swModel) =
        drawCircle 0.1 swModel
        //if Revolve was chosen, an axis of revolution is needed
        swModel.SketchManager
        |> SketchManagerUtils.createCenterLine (0., 0., 0.) (0., 0.05, 0.)
        |> ignore

    drawSketch draw swModel swApp
    let contour swModel =
        circleContour2 0.1 swModel
        circleContour1 0.1 swModel
    procContourSelection contour swModel
    featureRevolve 90 swModel





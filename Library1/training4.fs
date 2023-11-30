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
open FSharp.SolidWorks.FeatureManagerUtils

let newPart (swApp: ISldWorks) =
    let swModel = 
        swApp
        |> SldWorksUtils.newPartDoc

    let docPref = DocUserPreference(swModel)

    //swModel :?> IModelDoc2
    //|> ModelDoc2Utils.setUserPreferenceInteger
    //    swUserPreferenceIntegerValue_e.swUnitsLinear
    //    swUserPreferenceOption_e.swDetailingNoOptionSpecified
    //    (int swLengthUnit_e.swMM)


    docPref.swUnitsLinear swUserPreferenceOption_e.swDetailingNoOptionSpecified <- (int swLengthUnit_e.swMM)
    //Turn off dimension dialogs
    let p = SysUserPreference(swApp)
    p.swInputDimValOnCreate <- false
    //swApp
    //|> SldWorksUtils.setUserPreferenceToggle 
    //    swUserPreferenceToggle_e.swInputDimValOnCreate false

    swModel

let PartMaterialProperty (swModel: IModelDoc2) (swApp: ISldWorks) =
    let setPartMat (mat:string) =
        let swPart = swModel :?> IPartDoc
        swPart.SetMaterialPropertyName2(
            ConfigName = "", // 当前配置
            Database   = "", // 当前材料数据库
            Name       = mat
            )
        let mat1,db1 = 
            swPart.GetMaterialPropertyName2 (
                ConfigName = ""
            )
        swApp.SendMsgToUser $"{mat1},{db1}"

    setPartMat "1060 Alloy"
    setPartMat "Brass"

//画个矩形带标注
let drawRect height width (swModel: IModelDoc2) =
    let SketchSegmentObj = 
        swModel.SketchManager
        |> SketchManagerUtils.createLine (0.05, 0.05, 0.0) (0.05, 0.05 + height, 0.0)
    swModel.SketchAddConstraints "sgVERTICAL2D"

    //Add a dimension to the selected entity
    swModel
    |> ModelDoc2Utils.addDimension (0.0, 0.05 + height / 2.0, 0.0) swSmartDimensionDirection_e.swSmartDimensionDirection_Down
    |> ignore

    swModel.SketchManager
    |> SketchManagerUtils.createLine (0.05, 0.05 + height, 0.0) ( 0.05 + width, 0.05 + height, 0.0)
    |> ignore
    swModel.SketchAddConstraints "sgHORIZONTAL2D"

    swModel.SketchManager
    |> SketchManagerUtils.createLine (0.05 + width, 0.05 + height, 0.0) (0.05 + width, 0.05, 0.0)
    |> ignore
    swModel.SketchAddConstraints "sgVERTICAL2D"

    swModel.SketchManager
    |> SketchManagerUtils.createLine (0.05 + width, 0.05, 0.0) (0.05, 0.05, 0.0)
    |> ignore
    swModel.SketchAddConstraints "sgHORIZONTAL2D"

    swModel
    |> ModelDoc2Utils.addDimension (0.05 + width / 2.0, 0.0, 0.0) swSmartDimensionDirection_e.swSmartDimensionDirection_Down
    |> ignore

    swModel.ClearSelection2 true

    //Select the origin
    swModel
    |> ModelDoc2Utils.selectByID {| 
        name         = "" 
        stype        = "EXTSKETCHPOINT" 
        location     = (0.0, 0.0, 0.0) 
        append       = false 
        mark         = 0 
        selectOption = swSelectOption_e.swSelectOptionDefault
    |} 

    //Select an end point on the profile
    swModel
    |> ModelDoc2Utils.selectByID {|
        name         = "" 
        stype        = "SKETCHPOINT" 
        location     = (0.05, 0.05, 0.0) 
        append       = true 
        mark         = 0 
        selectOption = swSelectOption_e.swSelectOptionDefault
    |} 

    //Add a vertical dimension
    swModel.AddVerticalDimension2(0, 0.025, 0.0)
    |> ignore

    swModel.ClearSelection2 true

    //Select the origin
    swModel
    |> ModelDoc2Utils.selectByID {| 
        name         = "" 
        stype        = "EXTSKETCHPOINT" 
        location     = (0.0, 0.0, 0.0) 
        append       = false 
        mark         = 0 
        selectOption = swSelectOption_e.swSelectOptionDefault
    |} 

    //Select an end point on the profile
    swModel
    |> ModelDoc2Utils.selectByID {|
        name         = "" 
        stype        = "SKETCHPOINT" 
        location     = (0.05, 0.05, 0.0) 
        append       = true 
        mark         = 0 
        selectOption = swSelectOption_e.swSelectOptionDefault
    |} 

    //Add a horizontal dimension
    //to fully constrain the sketch
    swModel.AddHorizontalDimension2(0.025, 0.0, 0.0)
    |> ignore

    swModel.ClearSelection2 true

    //Select a profile edge
    SketchSegmentObj.Select4(Append = false, Data = null)
    |> ignore

    //Create the offset sketch profile from the selected edge
    //and its chain of sketch entities
    swModel.SketchManager
    |> SketchManagerUtils.sketchOffset {|
        offset = 0.002 
        bothDirections = false 
        chain = true
        capEnds = swSkOffsetCapEndType_e.swSkOffsetArcCaps
        makeConstruction = swSkOffsetMakeConstructionType_e.swSkOffsetDontMakeConstruction
        addDimensions = false
    |}

//else
let drawCircle (radius:float) (swModel: IModelDoc2) =
    swModel.SketchManager
    |> SketchManagerUtils.createCircleByRadius (0.05 + radius, 0.05 + radius, 0.0) radius
    |> ignore

    swModel.SketchManager
    |> SketchManagerUtils.sketchOffset {|
        offset = 0.002 
        bothDirections = false 
        chain = true
        capEnds = swSkOffsetCapEndType_e.swSkOffsetArcCaps
        makeConstruction = swSkOffsetMakeConstructionType_e.swSkOffsetDontMakeConstruction
        addDimensions = false
    |}  
    |> ignore

let featureExtrusion (depth:float) (swModel: IModelDoc2) =
    swModel.FeatureManager
    |> FeatureManagerUtils.featureExtrusion {
        sd = true
        flip = false
        dir = true
        direction1 = { 
            EndCond = EndCond.Blind depth
            Drafting = None } 
        direction2 = { 
            EndCond = EndCond.Blind 0.0 
            Drafting = None } 
        merge = false 
        useFeatScope = false 
        useAutoSelect = false 
        startCond = StartCondition.SketchPlane
    }
    |> ignore

let testRectExtrusionUsingSketch (swApp: ISldWorks) =
    let swModel = newPart swApp
    //drawSketch (drawRect 0.2 0.1) swModel swApp
    featureExtrusion 0.3 swModel

let testCircleExtrusionUsingSketch (swApp: ISldWorks) =
    let swModel = newPart swApp
    //drawSketch (drawCircle 0.2) swModel swApp
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
    let swModel = newPart swApp
    let draw (swModel) =
        drawRect 0.2 0.1 swModel
        //if Revolve was chosen, an axis of revolution is needed
        swModel.SketchManager
        |> SketchManagerUtils.createCenterLine(0., 0., 0.)(0., 0.05, 0.)
        |> ignore
    //drawSketch draw swModel swApp
    featureRevolve 90.0 swModel

let testCircleRevolveUsingSketch (swApp: ISldWorks) =
    let swModel = newPart swApp
    let draw (swModel) =
        drawCircle 0.2 swModel
        //if Revolve was chosen, an axis of revolution is needed
        swModel.SketchManager
        |> SketchManagerUtils.createCenterLine(0., 0., 0.)(0., 0.05, 0.)
        |> ignore
    //drawSketch draw swModel swApp
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
    let swModel = newPart swApp
    //drawSketch (drawRect 0.2 0.1) swModel swApp
    procContourSelection (rectContour1 0.1) swModel
    procContourSelection (rectContour2 0.1) swModel

    featureExtrusion 0.3 swModel

let testCircleContourExtrusion (swApp: ISldWorks) =
    let swModel = newPart swApp
    //drawSketch (drawCircle 0.1) swModel swApp
    let contour swModel =
        circleContour1 0.1 swModel
        circleContour2 0.1 swModel
    procContourSelection contour swModel

    featureExtrusion 0.3 swModel

let testRectContourRevolve (swApp: ISldWorks) =
    let swModel = newPart swApp
    let draw (swModel) =
        drawRect 0.2 0.1 swModel
        //if Revolve was chosen, an axis of revolution is needed
        swModel.SketchManager
        |> SketchManagerUtils.createCenterLine (0., 0., 0.) (0., 0.05, 0.)
        |> ignore
    //drawSketch draw swModel swApp
    let contour swModel =
        rectContour1 0.1 swModel
        rectContour2 0.1 swModel
    procContourSelection contour swModel
    featureRevolve 90 swModel

let testCircleContourRevolve (swApp: ISldWorks) =
    let swModel = newPart swApp
    let draw (swModel) =
        drawCircle 0.1 swModel
        //if Revolve was chosen, an axis of revolution is needed
        swModel.SketchManager
        |> SketchManagerUtils.createCenterLine (0., 0., 0.) (0., 0.05, 0.)
        |> ignore

    //drawSketch draw swModel swApp
    let contour swModel =
        circleContour2 0.1 swModel
        circleContour1 0.1 swModel
    procContourSelection contour swModel
    featureRevolve 90 swModel

let PartMaterial (swApp: ISldWorks) =
    newPart swApp
    |> PartMaterialProperty <| swApp

let InsertSketchOnFront (swModel : ModelDoc2) =
    swModel
    |> ModelDoc2Utils.selectByID {|
        name         = "Front Plane"
        stype        = "PLANE"
        location     = (0.0, 0.0, 0.0)
        append       = false
        mark         = 0
        selectOption = swSelectOption_e.swSelectOptionDefault
    |}

    swModel.SketchManager.InsertSketch false


let profileRect (swApp: ISldWorks) =
    let swModel = newPart swApp
    swModel.SketchManager.AddToDB <- true
    
    swModel
    |> InsertSketchOnFront

    swModel.SketchManager.InsertSketch false

    drawRect 0.2 0.1 swModel
    swModel.SketchManager.AddToDB <- false
    swModel.ViewZoomtofit2()

let profileCircle (swApp: ISldWorks) =
    let swModel = newPart swApp
    swModel.SketchManager.AddToDB <- true

    swModel
    |> InsertSketchOnFront

    drawCircle 0.2 swModel

    swModel.SketchManager.AddToDB <- false
    swModel.ViewZoomtofit2()

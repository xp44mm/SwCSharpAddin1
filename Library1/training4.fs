module training4 // Part Automation

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
        :?> ModelDoc2
    let docPref = DocUserPreference(swModel)

    docPref.swUnitsLinear swUserPreferenceOption_e.swDetailingNoOptionSpecified <- (int swLengthUnit_e.swMM)
    //Turn off dimension dialogs
    let p = SysUserPreference(swApp)
    p.swInputDimValOnCreate <- false

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

let PartMaterial (swApp: ISldWorks) =
    newPart swApp
    |> PartMaterialProperty <| swApp

let dx = 0.05
let dy = 0.05
let height = 0.2
let width = 0.1
let offset = 0.002

//画个矩形带标注
let drawRect (swModel: IModelDoc2) =
    let SketchSegmentObj =
        swModel.SketchManager
        |> SketchManagerUtils.createLine (dx, dy, 0.0) (dx, dy + height, 0.0)
    swModel.SketchAddConstraints "sgVERTICAL2D"

    //Add a dimension to the selected entity
    swModel
    |> ModelDoc2Utils.addDimension (0.0, dy + height / 2.0, 0.0) swSmartDimensionDirection_e.swSmartDimensionDirection_Down
    |> ignore

    swModel.SketchManager
    |> SketchManagerUtils.createLine (dx, dy + height, 0.0) ( dx + width, dy + height, 0.0)
    |> ignore
    swModel.SketchAddConstraints "sgHORIZONTAL2D"

    swModel.SketchManager
    |> SketchManagerUtils.createLine (dx + width, dy + height, 0.0) (dx + width, dy, 0.0)
    |> ignore
    swModel.SketchAddConstraints "sgVERTICAL2D"

    swModel.SketchManager
    |> SketchManagerUtils.createLine (dx + width, dy, 0.0) (dx, dy, 0.0)
    |> ignore
    swModel.SketchAddConstraints "sgHORIZONTAL2D"

    swModel
    |> ModelDoc2Utils.addDimension (dx + width / 2.0, 0.0, 0.0) swSmartDimensionDirection_e.swSmartDimensionDirection_Down
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
        location     = (dx, dy, 0.0)
        append       = true
        mark         = 0
        selectOption = swSelectOption_e.swSelectOptionDefault
    |}

    //Add a vertical dimension
    swModel.AddVerticalDimension2 (0, dy / 2.0, 0.0)
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
        location     = (dx, dy, 0.0)
        append       = true
        mark         = 0
        selectOption = swSelectOption_e.swSelectOptionDefault
    |}

    //Add a horizontal dimension
    //to fully constrain the sketch
    swModel.AddHorizontalDimension2(dx/2.0, 0.0, 0.0)
    |> ignore

    swModel.ClearSelection2 true

    //Select a profile edge
    SketchSegmentObj.Select4(Append = false, Data = null)
    |> ignore

    //Create the offset sketch profile from the selected edge
    //and its chain of sketch entities
    swModel.SketchManager
    |> SketchManagerUtils.sketchOffset {|
        offset = offset
        bothDirections = false
        chain = true
        capEnds = swSkOffsetCapEndType_e.swSkOffsetArcCaps
        makeConstruction = swSkOffsetMakeConstructionType_e.swSkOffsetDontMakeConstruction
        addDimensions = false
    |}

//if Revolve was chosen, an axis of revolution is needed
let createRevolveAxis (swModel: IModelDoc2) =
    swModel.SketchManager
    |> SketchManagerUtils.createCenterLine (0., 0., 0.) (0., dy, 0.)
    |> ignore

let drawFeatureExtrusion (depth:float) (swModel: IModelDoc2) =
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

let drawFeatureRevolve (angle) (swModel: IModelDoc2) =
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

let contourRect (swModel: IModelDoc2) =
    let smgr = swModel.SelectionManager :?> SelectionMgr
    smgr.EnableContourSelection <- true
    //按创建顺序，选择先创建的第一根线
    swModel
    |> ModelDoc2Utils.selectByID2 "" "SKETCHCONTOUR" (dx + width / 2.0, dy, 0.) true 0 swSelectOption_e.swSelectOptionDefault
    |> ignore

    swModel
    |> ModelDoc2Utils.selectByID2 "" "SKETCHCONTOUR" (dx + width / 2.0, dy - offset, 0.) true 0 swSelectOption_e.swSelectOptionDefault
    |> ignore

    smgr.EnableContourSelection <- false

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

let rectExtrusion (swApp: ISldWorks) =
    let swModel = newPart swApp
    swModel.SketchManager.AddToDB <- true

    InsertSketchOnFront swModel

    drawRect swModel

    swModel.SketchManager.AddToDB <- false

    contourRect swModel

    drawFeatureExtrusion 0.3 swModel

    swModel.ViewZoomtofit2()

let rectRevolve (swApp: ISldWorks) =
    let swModel = newPart swApp
    swModel.SketchManager.AddToDB <- true

    swModel |> InsertSketchOnFront

    drawRect swModel
    createRevolveAxis swModel

    swModel.SketchManager.AddToDB <- false
    contourRect swModel

    drawFeatureRevolve 90.0 swModel

    swModel.ViewZoomtofit2()


        //public void Training4_PartMaterial()
        //{
        //    training4.PartMaterial(this.iSwApp);
        //}

        //public void Training4_rectExtrusion ()
        //{
        //    training4.rectExtrusion(this.iSwApp);
        //}

        //public void Training4_rectRevolve()
        //{
        //    training4.rectRevolve(this.iSwApp);
        //}

        //public void Training4_circleExtrusion()
        //{
        //    training4_circle.circleExtrusion(this.iSwApp);
        //}

        //public void Training4_circleRevolve()
        //{
        //    training4_circle.circleRevolve(this.iSwApp);
        //}


            ////命令
            //cmds.add(
            //    hintString: "第4章之零件材料",
            //    toolTip: "",
            //    callbackFunction: nameof(this.Training4_PartMaterial),
            //    enableMethod: nameof(this.Always),
            //    menuTBOption: swCommandItemType_e.swMenuItem
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第4章之矩形拉伸",
            //    callbackFunction: nameof(this.Training4_rectExtrusion)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第4章之矩形旋转",
            //    callbackFunction: nameof(this.Training4_rectRevolve)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第4章之圆形拉伸",
            //    callbackFunction: nameof(this.Training4_circleExtrusion)
            //    );

            ////命令
            //cmds.add(
            //    hintOrTip: "第4章之圆形旋转",
            //    callbackFunction: nameof(this.Training4_circleRevolve)
            //    );





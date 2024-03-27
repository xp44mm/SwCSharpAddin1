module training1

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

////命令
//cmds.add(
//    hintString: "training1",
//    toolTip: "第1章示例",
//    callbackFunction: nameof(this.Training1),
//    enableMethod: nameof(this.Always),
//    menuTBOption: swCommandItemType_e.swMenuItem
//    );

//public void Training1()
//{
//    training1.exec(this.iSwApp);
//    //iSwApp.SendMsgToUser("这是占位的命令");

//    //trainingcylinder.main(iSwApp);

//    //training2.cmdConnect(iSwApp);
//    //training2.cmdNewModel_Part(iSwApp);

//    //training4.testPartMat(iSwApp);
//    //training4.rectangularExtrude(iSwApp);
//    //training4.circularExtrude(iSwApp);
//    //training4.testDrawCirc(iSwApp);
//    //training4.testCircleContourRevolve(iSwApp);
//    //training5.testSelectFace(this.iSwApp);

//    //SldWorksUtils.testCutLists(iSwApp);
//    //SldWorksUtils.detectCutLists(iSwApp);
//    //SldWorksUtils.setPartWeldment(iSwApp);

//}

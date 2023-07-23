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

let cmdBuild_Click(swApp: ISldWorks) =
    // Get the file path of the default part template
    let partTemplate = swApp.GetUserPreferenceStringValue(int swUserPreferenceStringValue_e.swDefaultTemplatePart)
    let swModel = 
        swApp.NewDocument(partTemplate, 0, 0.0, 0.0)
        |> unbox<ModelDoc2>

    swModel.SketchManager.AddToDB <- true
    swModel.Extension.SetUserPreferenceInteger(
        int swUserPreferenceIntegerValue_e.swUnitsLinear, 
        int swUserPreferenceOption_e.swDetailingNoOptionSpecified,
        int swLengthUnit_e.swMM)
    |> ignore

    //swApp.SendMsgToUser partTemplate


  
    //PROFILE
    let boolstatus = swModel.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0)
    swModel.SketchManager.InsertSketch false

    let Height = 0.2
    let Width = 0.1
    let drawRect() =
        //if optRectangular.value = true then
        //txtRadius.enabled <- false
        //Turn off dimension dialogs
        swApp.SetUserPreferenceToggle(int swUserPreferenceToggle_e.swInputDimValOnCreate, false)

        //let SketchSegmentObj:SldWorks.SketchSegment
        //Create the first line in the profile
        let SketchSegmentObj = swModel.SketchManager.CreateLine(0.05, 0.05, 0, 0.05, 0.05 + Height, 0.0)

        //Add a dimension to the selected entity
        swModel.Extension.AddDimension(0.0, 0.05 + Height / 2.0, 0.0, int swSmartDimensionDirection_e.swSmartDimensionDirection_Down)
        |> ignore
        swModel.SketchManager.CreateLine( 0.05, 0.05 + Height, 0.0, 0.05 + Width, 0.05 + Height, 0.0)
        |> ignore
        swModel.SketchManager.CreateLine( 0.05 + Width, 0.05 + Height, 0, 0.05 + Width, 0.05, 0.0)
        |> ignore
        swModel.SketchManager.CreateLine( 0.05 + Width, 0.05, 0, 0.05, 0.05, 0.0)
        |> ignore
        swModel.Extension.AddDimension( 0.05 + Width / 2.0, 0.0, 0.0, int swSmartDimensionDirection_e.swSmartDimensionDirection_Down)
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
        swModel.SketchManager.SketchOffset2( 0.002, false, true, 1, 1, false)
        |> ignore
        swModel.ViewZoomtofit2()

    //else
    let Radius:float = 0.05
    let drawCircle() =
        swModel.SketchManager.CreateCircleByRadius( 0.05 + Radius, 0.05 + Radius, 0, Radius)
        |> ignore
        swModel.SketchManager.SketchOffset2( 0.002, false, true, 1, 1, false)
        |> ignore
        swModel.ViewZoomtofit2()

    //drawRect()
    drawCircle()

    //if Revolve was chosen, an axis of revolution is needed
    //if optRevolve.value = true then
    swModel.SketchManager.CreateCenterLine (0, 0, 0, 0, 0.05, 0)
    |> ignore

    swModel.ViewZoomtofit2()

    swModel.SketchManager.AddToDB <- false


    let extru () =  
        //MACHINE OPERATION
        //let swFeatMgr:SldWorks.FeatureManager
        //if optExtrude.value = true then
        let Depth:float = 0.01
        //Depth = CDbl(txtDepth.text) / 1000
        //if optRectangular.value = true then
        //if chkContour1.value = true then
        (swModel.SelectionManager:?>SelectionMgr).EnableContourSelection <- true
        swModel.Extension.SelectByID2( "", "SKETCHCONTOUR", 0.05 + Width /2.0, 0.05, 0, true, 0, null, 0)
            |> ignore

        //if chkContour2.value = true then
        (swModel.SelectionManager:?>SelectionMgr).EnableContourSelection <- true
        swModel.Extension.SelectByID2( "", "SKETCHCONTOUR", 0.05 + Width /2.0, 0.05 - 0.002, 0, true, 0, null, 0)
            |> ignore

        //else
        //if chkContour1.value = true then
        (swModel.SelectionManager:?>SelectionMgr).EnableContourSelection <- true
        swModel.Extension.SelectByID2( "", "SKETCHCONTOUR", 0.05 + Radius, 0.05, 0, true, 0, null, 0)
            |> ignore

        //if chkContour2.value = true then
        (swModel.SelectionManager:?>SelectionMgr).EnableContourSelection <- true
        swModel.Extension.SelectByID2( "", "SKETCHCONTOUR", 0.05 - 0.002, 0.05 + Radius, 0, true, 0, null, 0)
            |> ignore

        let swFeatMgr = swModel.FeatureManager
        swFeatMgr.FeatureExtrusion2( true, false, true, 0, 0, Depth, 0, false, false, false, false, 0, 0, 
            false, false, false, false, false, false, false, 
            int swStartConditions_e.swStartSketchPlane, 0.0, false)
            |> ignore

        (swModel.SelectionManager:?>SelectionMgr).EnableContourSelection <- false
        swModel.ViewZoomtofit2()

    let revol () =
        //else
        let pi:float=Math.PI
        //pi = 4 * Atn(1)
        //let Angle:float
        //Convert to radians
        let Angle = 30.0 * pi / 180.0
        let swFeatMgr = swModel.FeatureManager
        swFeatMgr.FeatureRevolve2( true, true, false, false, false, false, 
            int swEndConditions_e.swEndCondBlind, int swEndConditions_e.swEndCondBlind, Angle, 0.0, false, false, 0.0, 0.0, 
            int swThinWallType_e.swThinWallOneDirection, 0.0, 0.0, true, false, true)
            |> ignore

    ()


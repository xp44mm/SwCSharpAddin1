module Salon

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
open FSharp.SolidWorks.FeatureExtrusion3

let WorkPath = @"D:\崔胜利\凯帝隆\湖北武穴锂宝\solidworks2\"
let pipeLength = 120.0

let tankinfo (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> IModelDoc2
    let CusPropMgr = swModel.Extension.CustomPropertyManager("")
    let filename = Path.GetFileNameWithoutExtension(swModel.GetTitle())
    let names = 
        CusPropMgr.GetNames()
        :?> obj[]
        |> Array.map (fun x -> x :?> string)

    let props =
        [
            for name in names do
                let value, _ =
                    CusPropMgr
                    |> CustomPropertyManagerUtils.GetUpdatedProperty name
                name,value
        ]
        |> List.map(fun (name,value) -> $"{name},{value}")
        |> String.concat "\n"

    swApp.SendMsgToUser $"{filename}\n{props}"

let tank (swApp: ISldWorks) =
    let filename = "V0101A"
    let dia = 4200.0
    let len = 7300.0
    let lineLength = pipeLength + dia / 2.0
    let getX angle = cos angle * lineLength / 1e3
    let getY angle = sin angle * lineLength / 1e3
    let radian angle = angle * Math.PI / 180.0

    let swModel = SldWorksUtils.newPartDoc swApp :?> IModelDoc2

    let CusPropMgr = swModel.Extension.CustomPropertyManager("")
    let swEqMgr = swModel.GetEquationMgr()

    CusPropMgr.Add3(
        FieldName = "直径",
        FieldType = int swCustomInfoType_e.swCustomInfoDouble,
        FieldValue = string dia,
        OverwriteExisting = int swCustomPropertyAddOption_e.swCustomPropertyReplaceValue
    )
    |> ignore

    CusPropMgr.Add3(
        FieldName = "高度",
        FieldType = int swCustomInfoType_e.swCustomInfoDouble,
        FieldValue = string len,
        OverwriteExisting = int swCustomPropertyAddOption_e.swCustomPropertyReplaceValue
    )
    |> ignore

    swModel.Extension.SelectByID2(
        Name = "Top Plane",
        Type = "PLANE",
        X = 0.0,
        Y = 0.0,
        Z = 0.0,
        Append = false,
        Mark = 0,
        Callout = null,
        SelectOption = int swSelectOption_e.swSelectOptionDefault)
    |> ignore

    swModel.SketchManager.InsertSketch true
    swModel.SketchManager.CreateCircleByRadius(0.0, 0.0, 0.0, dia/2000.0)
    |> ignore

    let swDispDim =
        swModel.AddDimension2(0.0, 0.0, 0.0)
        :?> DisplayDimension

    let diaformula = $"\"{swDispDim.GetNameForSelection()}\"=\"直径\""

    {
        sd = true
        flip = false
        dir = false
        direction1 = {
            EndCond = EndCond.Blind (len/1000.0)
            Drafting = None }
        direction2 = {
            EndCond = EndCond.Blind 0.0
            Drafting = None }
        merge = false
        useFeatScope = false
        useAutoSelect = false
        startCond = StartCondition.SketchPlane
    }.create swModel.FeatureManager
    |> ignore

    swEqMgr.Add2(-1, diaformula, true)
    |> ignore

    swEqMgr.Add2(-1, "\"D1@Boss-Extrude1\"=\"高度\"", true)
    |> ignore

    swModel.ClearSelection2 true
    swModel.Extension.SelectByID2("Point1@Origin", "EXTSKETCHPOINT", 0, 0, 0, false, 1, null, 0)
    |> ignore

    swModel.InsertCoordinateSystem(false, false, false)
    |> ignore

    swModel.ClearSelection2 true
    swModel.Extension.SelectByID2("Coordinate System1", "COORDSYS", 0, 0, 0, true, 1, null, 0)
    |> ignore

    swModel.FeatureManager.InsertMateReference2("Default", null, 2, 0, true, null, 0, 0, false, null, 0, 0)
    |> ignore

    let filex = filename + ".SLDPRT"

    //https://help.solidworks.com/2023/english/api/sldworksapi/SolidWorks.Interop.sldworks~SolidWorks.Interop.sldworks.IModelDocExtension~SaveAs3.html
    swModel.SaveAs3(Path.Combine(WorkPath,filex), 0, 0)
    |> ignore

    swModel.Extension.SelectByID2(
        Name = "Top Plane",
        Type = "PLANE",
        X = 0.0,
        Y = 0.0,
        Z = 0.0,
        Append = false,
        Mark = 0,
        Callout = null,
        SelectOption = int swSelectOption_e.swSelectOptionDefault)
    |> ignore

    //https://help.solidworks.com/2023/english/api/sldworksapi/solidworks.interop.sldworks~solidworks.interop.sldworks.ifeaturemanager~insertrefplane.html
    let myRefPlane = 
        swModel.FeatureManager.InsertRefPlane(
            FirstConstraint = int swRefPlaneReferenceConstraints_e.swRefPlaneReferenceConstraint_Distance, 
            FirstConstraintAngleOrDistance = 0.3, 
            SecondConstraint = 0, 
            SecondConstraintAngleOrDistance = 0, 
            ThirdConstraint = 0, 
            ThirdConstraintAngleOrDistance = 0)
        :?> RefPlane

    let swFeat =
        swModel.FeatureByPositionReverse(Num=0)
        :?> Feature

    let name,typ = swFeat.GetNameForSelection()

    swModel.Extension.SelectByID2(
        Name = name,
        Type = typ,
        X = 0.0,
        Y = 0.0,
        Z = 0.0,
        Append = false,
        Mark = 0,
        Callout = null,
        SelectOption = int swSelectOption_e.swSelectOptionDefault)
    |> ignore
    
    swModel.BlankRefGeom()

    swModel.Extension.SelectByID2(
        Name = name,
        Type = typ,
        X = 0.0,
        Y = 0.0,
        Z = 0.0,
        Append = false,
        Mark = 0,
        Callout = null,
        SelectOption = int swSelectOption_e.swSelectOptionDefault)
    |> ignore

    swModel.SketchManager.InsertSketch true
    let angle = radian 120.0
    let lineSeg =
        swModel.SketchManager.CreateLine(0.0, 0.0, 0.0, getX angle, getY angle, 0.0)

    let sketchLine = lineSeg :?> ISketchLine
    let lineName = lineSeg.GetName()
    let sketchPoint = sketchLine.GetEndPoint2() :?> ISketchPoint
    let pid =(sketchPoint.GetID() :?> int []).[1]
    //swApp.SendMsgToUser $"{lineName},{pid}"
    swModel.EditRebuild3()
    |> ignore
    // todo: 获取草图名字
    swModel.Extension.SelectByID2($"{lineName}@Sketch2", "EXTSKETCHSEGMENT", 0.0, 0.0, 0.0, true, 0, null, 0)
    |> ignore

    //todo:solidworks get sketch point' s name use for SelectByID2
    swModel.Extension.SelectByID2($"Point{pid}@Sketch2", "EXTSKETCHPOINT", 0.0, 0.0, 0.0, true, 1, null, 0)
    |> ignore

    let myRefPlane = swModel.FeatureManager.InsertRefPlane(514, 0, 4, 0, 0, 0)

    let dn = 100.0
    let dw = 108.0
    let l = pipeLength + dw / 2.0
    let fd = 220.0 // flange
    let hd = 156.0 // hub
    let ft = 22.0
    let ht = 2.0

    swModel.ClearSelection2 true
    let swFeat =
        swModel.FeatureByPositionReverse(Num=0)
        :?> Feature

    let name,typ = swFeat.GetNameForSelection()

    swModel.Extension.SelectByID2(
        Name = name,
        Type = typ,
        X = 0.0,
        Y = 0.0,
        Z = 0.0,
        Append = false,
        Mark = 0,
        Callout = null,
        SelectOption = int swSelectOption_e.swSelectOptionDefault)
    |> ignore
    
    //swModel.BlankRefGeom()

    try

    swModel.SketchManager.InsertSketch true
    swModel.ClearSelection2 true
    //swApp.SendMsgToUser $"{dw/2000.0}"
    
    swModel.SketchManager.CreateCenterLine (0.0, 0.0, 0.0, 0.054,0.0,0.0)
    |> ignore

    swModel.SketchManager.CreateCircle(0.0, 0.0, 0.0, 0.054, 0.0, 0.0)
    |> ignore


    //{
    //    sd = true
    //    flip = false
    //    dir = false
    //    direction1 = {
    //        EndCond = EndCond.Blind (l/1000.0)
    //        Drafting = None }
    //    direction2 = {
    //        EndCond = EndCond.Blind 0.0
    //        Drafting = None }
    //    merge = false
    //    useFeatScope = false
    //    useAutoSelect = false
    //    startCond = StartCondition.SketchPlane
    //}.create swModel.FeatureManager
    //|> ignore

    with ex -> swApp.SendMsgToUser ex.Message

    //swApp.CloseDoc filex

    ()


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


let tank (swApp: ISldWorks) =
    let swModel = SldWorksUtils.newPartDoc swApp :?> IModelDoc2

    let CusPropMgr = swModel.Extension.CustomPropertyManager("")
    let swEqMgr = swModel.GetEquationMgr()
    //let swSelMgr = swModel.SelectionManager

    CusPropMgr.Add3(
        FieldName = "直径",
        FieldType = int swCustomInfoType_e.swCustomInfoDouble,
        FieldValue = "1000",
        OverwriteExisting = int swCustomPropertyAddOption_e.swCustomPropertyReplaceValue
    )
    |> ignore

    CusPropMgr.Add3(
        FieldName = "高度",
        FieldType = int swCustomInfoType_e.swCustomInfoDouble,
        FieldValue = "1500",
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
    swModel.SketchManager.CreateCircleByRadius(0.0, 0.0, 0.0, 0.04)
    |> ignore

    let swDispDim = 
        swModel.AddDimension2(-2.7E-3, 0, -7.5E-2)
        //|> ignore
        //(swModel.SelectionManager :?> SelectionMgr).GetSelectedObject6(1, -1)
        :?> DisplayDimension
                      
    let formula = $"\"{swDispDim.GetNameForSelection()}\"=\"直径\""

    swEqMgr.Add2(-1, formula, true)
    |> ignore
    ()

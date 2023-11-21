module Preselection

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
open FSharp.SolidWorks

let cmdGenerate_Click
    (swApp: SldWorks)
    (swModel: ModelDoc2)
    (factor: float)
    =
    let swSelMgr =
        swModel.SelectionManager
        |> unbox<SelectionMgr>

    let count =
        swSelMgr
        |> SelectionMgrUtils.getSelectedObjectCount2 SelectionMgrUtils.Mark.All

    if count <> 1 then
        swApp
        |> SldWorksUtils.sendMsgToUser2
            "Please select only Extrude1."
            swMessageBoxIcon_e.swMbWarning
            swMessageBoxBtn_e.swMbOk
        |> ignore
    else
        let feat =
            swSelMgr
            |> SelectionMgrUtils.getSelectedObject6 1 SelectionMgrUtils.Mark.All
            |> unbox<Feature>

        if feat.GetTypeName2() <> "Extrusion" then
            swApp
            |> SldWorksUtils.sendMsgToUser2
                "Please select only Extrude1."
                swMessageBoxIcon_e.swMbWarning
                swMessageBoxBtn_e.swMbOk
            |> ignore

        else
            //修改特征的代码
            let extrudeFeatureData =
                feat.GetDefinition()
                |> unbox<ExtrudeFeatureData2>

            let depth = extrudeFeatureData.GetDepth(true)
            extrudeFeatureData.SetDepth(true, depth * factor)

            feat.ModifyDefinition(extrudeFeatureData, swModel, null)
            |> ignore

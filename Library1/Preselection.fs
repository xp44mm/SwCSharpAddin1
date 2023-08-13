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


let cmdGenerate_Click
  (swApp: SldWorks   )
  (swModel: ModelDoc2)
  (factor: float     )
  () = 
  
    //Factor = CInt(txtDepth.Text)
    //Set swApp = Application.SldWorks
    //Set swModel = swApp.ActiveDoc
    let swSelMgr = 
        swModel.SelectionManager
            |> unbox<SelectionMgr>

    let count = swSelMgr.GetSelectedObjectCount2(-1)
    if count <> 1 then
        swApp.SendMsgToUser2("Please select only Extrude1.",int swMessageBoxIcon_e.swMbWarning, int swMessageBoxBtn_e.swMbOk)
        //Exit Sub
    else
        let Feature = 
            swSelMgr.GetSelectedObject6(count, -1)
            |> unbox<Feature>
        if Feature.GetTypeName2() <> "Extrusion" then
            swApp.SendMsgToUser2("Please select only Extrude1.", int swMessageBoxIcon_e.swMbWarning, int swMessageBoxBtn_e.swMbOk)
            //Exit Sub
        else
            let extrudeFeatureData = 
                Feature.GetDefinition()
                |> unbox<ExtrudeFeatureData2>

            let depth = extrudeFeatureData.GetDepth(true)
            extrudeFeatureData.SetDepth(true, depth * factor)
            Feature.ModifyDefinition(extrudeFeatureData, swModel, null)
            |> ignore
            0

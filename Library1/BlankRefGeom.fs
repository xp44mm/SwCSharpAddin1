module BlankRefGeom

open FSharp.Idioms
open FSharp.Idioms.Jsons
open FSharp.Idioms.Literal
open FSharp.Idioms.Literal
open FSharp.SolidWorks
open FSharp.SolidWorks.FeatureExtrusion3
open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open SolidWorks.Interop.swpublished
open SolidWorksTools
open SolidWorksTools.File
open System
open System.Collections
open System.Collections.Generic
open System.Diagnostics
open System.Drawing
open System.IO
open System.Reflection
open System.Runtime.InteropServices
open System.Text
open System.Text.RegularExpressions
open System.Windows.Forms
open UnquotedJson
open Tanks
open Nozzles
// todo: 一键隐藏所有草图，一键隐藏所有平面
let switchBlank (action) (swModel:IModelDoc2) (swApp: ISldWorks) =
    let swSelMgr =
        swModel.SelectionManager
        :?> SelectionMgr
    let num = swSelMgr.GetSelectedObjectCount2(-1)

    let names = 
        [
            for i in [1..num] do
                let swSelectedObject = swSelMgr.GetSelectedObject6(i, -1)
                let swFeat = swSelectedObject :?> Feature
                swFeat.Name, swFeat.GetTypeName2().ToUpper()
        ]

    swModel.GetConfigurationNames()
    :?> obj[]
    |> Array.map(fun x -> x :?> string)
    |> Array.iter(fun configname ->
        // Shows the named configuration by switching to that configuration and making it the active configuration.
        swModel.ShowConfiguration2 configname
        |> ignore
        
        for (nm,tp) in names do
            swModel.ClearSelection2 true
            swModel.Extension.SelectByID2(
                Name = nm,
                Type = tp,
                X = 0.0,
                Y = 0.0,
                Z = 0.0,
                Append = false,
                Mark = 0,
                Callout = null,
                SelectOption = int swSelectOption_e.swSelectOptionDefault)
            |> ignore
            action()
    )

    swModel.ClearSelection2 true
    swModel.EditRebuild3() |> ignore

let blankSelectedFeatures (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> ModelDoc2
    switchBlank swModel.BlankRefGeom swModel swApp

let unblankSelectedFeatures (swApp: ISldWorks) =
    let swModel = swApp.ActiveDoc :?> ModelDoc2
    switchBlank swModel.UnBlankRefGeom swModel swApp

module FacesWithFeature

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
open Tanks
open UnquotedJson
//-----------------------------------------------
// Preconditions:
// 1. Open a part document.
// 2. Select a feature in the FeatureManager design
//    tree.
// 3. Open the Immediate window.
//
// Postconditions:
// 1. Gets the name of the feature and number
//    of faces.
// 2. Colors the faces of the feature blue.
//    NOTE: The faces are the same faces as if
//    you selected the feature in the user interface.
// 3. Examine the Immediate window and graphics area.
//-----------------------------------------------
let main (swApp: ISldWorks) =
    //let swApp: SldWorks.SldWorks
    //let swModel: SldWorks.ModelDoc2
    //let swSelMgr: SldWorks.SelectionMgr
    //let swSelData: SldWorks.SelectData
    //let swFeat: SldWorks.Feature
    //let swFaceFeat: SldWorks.Feature
    //let faceArr: Variant
    //let oneFace: Variant
    //let featColors: Variant
    //let swFace: SldWorks.Face2
    //let swEnt: SldWorks.Entity
    //let status: Boolean
    let swModel = swApp.ActiveDoc :?> IModelDoc2
    let swSelMgr =
        swModel.SelectionManager
        :?> SelectionMgr
    let swFeat =  
        swSelMgr.GetSelectedObject6(1, -1)
        :?> Feature

    //let swSelMgr = swModel.SelectionManager
    //let swFeat = swSelMgr.GetSelectedObject6(1, -1)

    let swSelData = swSelMgr.CreateSelectData()
    let sb = StringBuilder()

    //sb.Append($"\n") |> ignore

    sb.Append($"Feature = {swFeat.Name}[{swFeat.GetTypeName()}]\n") |> ignore
    sb.Append($"  Face count = {swFeat.GetFaceCount()}\n") |> ignore

    sb.ToString()
    |> swApp.SendMsgToUser

    //swModel.ClearSelection2 true

    //featColors = swModel.MaterialPropertyValues
    //featColors(0) = 0  //R
    //featColors(1) = 0  //G
    //featColors(2) = 1  //B
    //faceArr = swFeat.GetFaces
    //if IsEmpty(faceArr) then Exit Sub
    //For Each oneFace In faceArr
    //    let swFace = oneFace
    //    let swEnt = swFace
    //    let swFaceFeat = swFace.GetFeature
    //    // Check to see if face is owned by multiple features
    //    if swFaceFeat = swFeat then
    //        status = swEnt.Select4(true, swSelData): Debug.Assert status
    //        swFace.MaterialPropertyValues = featColors
    //    else
    //        Debug.Print "  Other feature = " + swFaceFeat.Name + " [" + swFaceFeat.GetTypeName + "]"


    

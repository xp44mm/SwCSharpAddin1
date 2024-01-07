module FileName

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
open FSharp.Idioms
open FSharp.Idioms.Jsons
open FSharp.Idioms.Literal
open Tanks
open UnquotedJson
open System.Text

// Get reference plane feature by name as feature
//let swFeature = swPart.FeatureByName(refPlane)
// Get the name
//let strRefPlaneName = swFeature.Name
// Cast down
//let swRefPlane = swFeature.GetSpecificFeature2

let xx (strRefPlaneName:string)(swRefPlane:RefPlane) (swModel : IModelDoc2) (swApp: ISldWorks) =
    //' Get the math utility
    let swMathUtility = swApp.GetMathUtility() :?> MathUtility

    // Get the reference plane transform:
    // * This transform takes a reference plane from
    //   its canonical position/orientation to its
    //   actual Position / Orientation
    // * The canonical position/orientation is aligned
    //   with the system defined "Front Plane"
    let swRefPlaneTransform = swRefPlane.Transform
    // Create a math point that represents the reference plane's origin
    // in the canonical position in world coordinates; this is
    // (0.0, 0.0, 0.0)
    // Create array data
    //aPointData(0) = 0.0
    //aPointData(1) = 0.0
    //aPointData(2) = 0.0
    let vPointData = [|0.0;0.0;0.0|]

    // Turn into a Variant
    //vPointData = aPointData
    // Create a math point
    let swOriginPoint = swMathUtility.CreatePoint(vPointData) :?> MathPoint
    // Transform the reference plane origin from its canonical
    // position to its actual position
    let swOriginPointOnRefPlane = swOriginPoint.MultiplyTransform(swRefPlaneTransform) :?> MathPoint
    // Get point data
    let vPointData = swOriginPointOnRefPlane.ArrayData :?> float[]
    // Create a math vector that represents the reference plane's normal in
    // the canonical orientation in world coordinates; this is [0.0, 0.0, 1.0]
    // Create array data
    //aVectorData(0) = 0.0
    //aVectorData(1) = 0.0
    //aVectorData(2) = 1.0
    // Turn into a Variant
    let vVectorData = [|0.0;0.0;1.0|]
    // Create a math vector
    let swNormalVector = swMathUtility.CreateVector(vVectorData) :?> MathVector
            
    // Now transform the reference plane normal from its canonical
    // orientation to its actual orientation
    let swNormalVectorRefPlane = swNormalVector.MultiplyTransform(swRefPlaneTransform) :?> MathVector
    // Get vector data
    let vVectorData = swNormalVectorRefPlane.ArrayData :?> float[]

    // Visualize
    // As the reference plane normal is normalized, it may be bit out of
    // proportion; this factor is arbitrary
    let dScaleFactor = 0.1

    // Insert a 3D sketch
    swModel.Insert3DSketch2 true

    // Create a line from the reference plane origin in the direction
    // of the reference plan normal
    swModel.CreateLine2(
        vPointData.[(0)], vPointData.[(1)], vPointData.[(2)], 
        vPointData.[(0)] + dScaleFactor * vVectorData.[(0)], 
        vPointData.[(1)] + dScaleFactor * vVectorData.[(1)], 
        vPointData.[(2)] + dScaleFactor * vVectorData.[(2)]
        )
        |> ignore
    // Close the sketch
    swModel.Insert3DSketch2 true

    // The sketch is still selected
    let swFeature = 
        (swModel.SelectionManager:?>SelectionMgr).GetSelectedObject6(1, 0) 
        :?> Feature
        
    // Rename it
    swFeature.Name <- $"{strRefPlaneName}-Normal"

    // Clear selection for the next pass
    swModel.ClearSelection2 true

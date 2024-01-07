module FSharp.SolidWorks.MathUtilityExtend

open System
open System.Collections
open System.Collections.Generic
open System.Diagnostics
open System.Reflection
open System.Runtime.InteropServices
open System.IO

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

let getNormal (placementPlane:RefPlane) (swMathUtility:MathUtility) =
    let swRefPlaneTransform = placementPlane.Transform

    // Create a math vector
    let swNormalVector = 
        swMathUtility.CreateVector [|0.0;0.0;1.0|]
        :?> MathVector
            
    // Now transform the reference plane normal from its canonical
    // orientation to its actual orientation
    let swNormalVectorRefPlane = 
        swNormalVector.MultiplyTransform(swRefPlaneTransform) 
        :?> MathVector

    // Get vector data
    swNormalVectorRefPlane.ArrayData :?> float[]

// Retrieving the global coordinates from sketch point
let getGlobalCoordinates (swSkPt:SketchPoint) (swMathUtility:MathUtility) =
    let swSketch = swSkPt.GetSketch()

    //'get the sketch to model transform (by inversing the model to sketch transform)
    let swTransform = swSketch.ModelToSketchTransform.Inverse() :?> MathTransform

    //'create math point from the coordinate
    let swMathPt = 
        swMathUtility.CreatePoint [| swSkPt.X; swSkPt.Y; swSkPt.Z |]
        :?> MathPoint

    //'multiple transform to move the point
    let swMathPt = 
        swMathPt.MultiplyTransform(swTransform) 
        :?> MathPoint

    //'read new coordinate values
    swMathPt.ArrayData :?> float[]



module FSharp.SolidWorks.MathUtilityUtils

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

//use the arrayData locations to create a Solidworks MathPoint object
let createPoint (arrayData:float[]) (swMathUtility:MathUtility) =
    //use the math point class to store these points
    swMathUtility.CreatePoint(arrayData)         //Create the mathpoint using the location data
    |> unbox<MathPoint>


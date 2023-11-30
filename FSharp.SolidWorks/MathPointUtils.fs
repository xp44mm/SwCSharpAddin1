module FSharp.SolidWorks.MathPointUtils

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

//不符合交换率
let multiplyTransform (swCompTransform:MathTransform) (swMathPoint:MathPoint) = 
    swMathPoint.MultiplyTransform(swCompTransform) 
    :?> MathPoint

module FSharp.SolidWorks.CurveUtils

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

let getEndParams  (curve:Curve) =
    let mutable dStart: float = 0.0
    let mutable dEnd: float = 0.0
    let mutable bIsClosed = false
    let mutable bIsPeriodic = false
    curve.GetEndParams(&dStart, &dEnd, &bIsClosed, &bIsPeriodic)
    |> ignore
    dStart, dEnd, bIsClosed, bIsPeriodic
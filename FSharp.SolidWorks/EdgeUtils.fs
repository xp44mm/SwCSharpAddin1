module FSharp.SolidWorks.EdgeUtils

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


let getCurve (swEdge:IEdge) = 
    swEdge.GetCurve()              //Set the current curve object
    |> unbox<Curve>

let getTwoAdjacentFaces2 (swEdge:IEdge) =
    swEdge.GetTwoAdjacentFaces2() //use this to get the 2 faces sharing the Circular edge
    |> unbox<Face2[]>



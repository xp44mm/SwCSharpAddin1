module FSharp.SolidWorks.Loop2Module

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

let getEdges (swLoop:Loop2) = 
    swLoop.GetEdges()      //if it's an inner loop, get the array of edges belonging to the loop
    :?> obj[]
    |> Array.map(fun obj -> obj :?> Edge)

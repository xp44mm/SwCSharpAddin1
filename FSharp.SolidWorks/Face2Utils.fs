module FSharp.SolidWorks.Face2Utils

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

//open FSharp.Literals.Literal
open FSharp.SolidWorks

let getLoopSeq (swSelFace:Face2) =
    let rec loop (swLoop:obj) =
        seq {
            match swLoop with
            | null -> ()
            | :? Loop2 as swLoop -> 
                yield swLoop
                yield! loop <| swLoop.GetNext()
            | _ -> failwith $"{swLoop.GetType()}"
        }

    let swLoop = 
        swSelFace.GetFirstLoop()

    loop swLoop

let getSurface (swFace:Face2) =
    swFace.GetSurface()
    :?> Surface

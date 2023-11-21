module FSharp.SolidWorks.Body2Utils

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

let getFaceSeq (body:Body2) =
    let rec loop (face:obj) =
        seq {
            match face with
            | null -> ()
            | :? Face2 as face ->
                yield face
                yield! loop (face.GetNextFace())
            | _ -> failwith $"{face.GetType()}"
        }
    body.GetFirstFace() |> loop

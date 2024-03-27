module FSharp.SolidWorks.AssemblyDocUtils

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO

let editPart2
    (silent: bool)
    (allowReadOnly: bool)
    (swAssy: IAssemblyDoc) =
    let mutable information = 0
    try
    swAssy.EditPart2(silent, allowReadOnly, &information)
    |> enum<swEditPartCommandStatus_e>
    with _ -> failwith $"{enum<swEditPartCommandStatus_e>information}"

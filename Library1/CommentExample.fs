module CommentExample
open FSharp.SolidWorks
open FSharp.Idioms.Literal

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
open SolidWorks.Interop.SWRoutingLib

let main (swApp: ISldWorks) =
    let swModelDoc = swApp.ActiveDoc :?> ModelDoc2

    let data = ComponentData.fromModel swModelDoc

    //let outp =
    //    match 
    //        swModelDoc
    //        |> ModelDoc2Utils.getFeatureSeq
    //        |> CommentUtils.tryGetCommentFolder
    //    with
    //    | None -> "no CommentFolder"
    //    | Some swCommentFolder -> 
    //        match CommentUtils.tryGetComments swCommentFolder with
    //        | None -> "no comments"
    //        | Some vComments ->
    //            vComments
    //            |> Array.map(fun (owner,text) ->
    //                $"owner:{owner.GetID()}({owner.ReferencedConfiguration}),text:{text}"
    //            )
    //            |> String.concat "\n"
    let outp = data.toLine()
    swApp.SendMsgToUser $"{outp}"

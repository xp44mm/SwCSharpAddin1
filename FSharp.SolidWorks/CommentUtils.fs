module FSharp.SolidWorks.CommentUtils

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO

let tryGetCommentFolder (features:seq<Feature>) =
    features
    |> Seq.tryPick(fun swFeat ->
        if swFeat.GetTypeName() = "CommentsFolder" then
            Some(swFeat.GetSpecificFeature2() :?> CommentFolder)
        else None
    )

let tryGetComments (commentFolder: CommentFolder) =
    match commentFolder.GetComments() :?> obj[] with
    | null -> None
    | arr ->
        arr
        |> Array.map(fun obj -> obj :?> Comment)
        |> Array.choose(fun comment ->
            let owner = comment.FeatureOwner
            if owner.GetTypeName2() = "Reference" then
                let comp = owner.GetSpecificFeature2() :?> Component2
                Some(comp, comment.Text)
            else None   
        )
        |> Some

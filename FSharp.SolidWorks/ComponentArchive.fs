namespace rec FSharp.SolidWorks

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO
open System.Text.RegularExpressions

open FSharp.Idioms.Jsons

open FSharp.Idioms.Literal
open FSharp.Reflection

type ComponentArchiveSpecific =
    | ComponentArchivePart
    | ComponentArchiveAssembly of children: ComponentArchive list
    | ComponentArchiveRouteAssembly of children: ComponentArchive list

    static member from (getChildren: unit -> ComponentArchive list) (swModel: ModelDoc2) =
        match ComponentModelSpecific.from swModel with
        | ComponentModelPart _ -> ComponentArchivePart
        | ComponentModelAssembly assy ->
            let children = getChildren()
            if assy.IsRouteAssembly() then
                ComponentArchiveRouteAssembly children
            else
                ComponentArchiveAssembly children

type ComponentArchive =
    {
        id: int
        title: string
        refconfig: string
        refid: string
        isVirtual: bool
        props: Map<string,string*string>
        comment: string
        specific: ComponentArchiveSpecific
    }

    static member from (root: ModelDoc2) =
        let getProps (cm:ComponentModel) =
            cm.ModelDoc2
            |> ModelDoc2Utils.readPropsAll cm.Component2.ReferencedConfiguration
            |> List.map(fun(a,b,c)->a,(b,c))
            |> Map.ofList

        let getComments (cm:ComponentModel) =
            cm.ModelDoc2.FirstFeature() // 使用component2无法获取CommentFolder
            |> FeatureUtils.getFeatureSeq
            |> CommentUtils.tryGetCommentFolder
            |> Option.map (fun folder ->
                folder
                |> CommentUtils.tryGetComments
                |> Option.map List.ofArray
                |> Option.defaultValue []
                )
            |> Option.defaultValue []
            |> Seq.map(fun (comp,text) -> comp.GetID(),text)
            |> Map.ofSeq

        let getChildren (loop:string->ComponentModel->ComponentArchive) (comments:Map<int,string>) (cm:ComponentModel) =
            cm.getChildren()
            |> Array.map(fun child ->
                let id = child.Component2.GetID()
                let comment = 
                    if comments.ContainsKey id then
                        comments.[id]
                    else ""
                loop comment child)
            |> Array.toList

        let rec loop comment (cmodel: ComponentModel) =
            let comments = getComments cmodel
            let getChildren () = getChildren loop comments cmodel
            let specific = ComponentArchiveSpecific.from getChildren cmodel.ModelDoc2

            {
                id = cmodel.Component2.GetID()
                title     = cmodel.ModelDoc2.GetTitle() // Path.GetFileNameWithoutExtension()
                refconfig = cmodel.Component2.ReferencedConfiguration
                refid     = cmodel.Component2.ComponentReference
                isVirtual = cmodel.Component2.IsVirtual
                props     = getProps cmodel
                comment  = comment
                specific  = specific
            }

        root
        |> ComponentModel.fromModel
        |> loop ""
                


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

type ComponentEasySpecific =
    | ComponentEasyPart
    | ComponentEasyAssembly of children: ComponentEasy list
    | ComponentEasyRouteAssembly of children: ComponentEasy list

    static member from (getChildren : unit -> ComponentEasy list) (swModel:ModelDoc2) =
        match ComponentDataSpecific.from swModel with
        | ComponentDataPart _ -> ComponentEasyPart
        | ComponentDataAssembly _ -> 
            getChildren()
            |> ComponentEasyAssembly
        | ComponentDataRouteAssembly _ -> 
            getChildren()
            |> ComponentEasyRouteAssembly

    member this.toLine() =
        match this with
        | ComponentEasyPart -> "part"
        | ComponentEasyAssembly _ -> "assembly"
        | ComponentEasyRouteAssembly _ -> "route assembly"

type ComponentEasy =
    {
        id:int
        title: string
        refconfig: string
        refid: string
        isVirtual: bool
        props: Map<string,string>
        comment: string
        specific: ComponentEasySpecific
    }

    static member from (comp: ComponentData) =
        let rec loop (swcomp: ComponentData) comment =
            let comments = 
                swcomp.Comments
                |> Seq.map(fun (comp,text) -> comp.GetID(),text)
                |> Map.ofSeq

            let getChildren () =
                swcomp.getChildren()
                |> Array.map(fun child ->
                    let id = child.Component2.GetID()
                    let comment = 
                        if comments.ContainsKey id then
                            comments.[id]
                        else ""
                    loop child comment)
                |> Array.toList

            let specific = ComponentEasySpecific.from getChildren swcomp.ModelDoc2

            {
                id = swcomp.Component2.GetID()
                title     = Path.GetFileNameWithoutExtension(swcomp.ModelDoc2.GetTitle())
                refconfig = swcomp.Component2.ReferencedConfiguration
                refid     = swcomp.Component2.ComponentReference
                isVirtual = swcomp.Component2.IsVirtual
                props     = swcomp.Props |> Map.map(fun _ (_,v) -> v)
                comment  = comment
                specific  = specific
            }
        loop comp ""

    static member fromModel(root: ModelDoc2) =
        root
        |> ComponentData.fromModel
        |> ComponentEasy.from

    member this.toLine() =
        let s0 = $"{this.title}({this.refconfig}){{{this.refid}}}"
        let props =
            this.props
            |> Map.toList

        [
            s0
            stringify props
            this.specific.toLine()
        ]
        |> List.filter((<>) "")
        |> String.concat " "

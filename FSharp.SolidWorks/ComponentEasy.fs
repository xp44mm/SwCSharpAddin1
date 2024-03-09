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
    | ComponentEasyAssembly of isRoute: bool * children: ComponentEasy list
    | ComponentEasyPart

    member this.toLine() =
        match this with
        | ComponentEasyAssembly(isRoute,_) -> if isRoute then "route assembly" else "assembly"
        | ComponentEasyPart -> "part"

type ComponentEasy =
    {
        title: string
        refconfig: string
        refid: string
        isVirtual: bool
        props: Map<string,string*string>
        specific: ComponentEasySpecific
    }

    static member from (comp: ComponentData) =
        let rec loop (swcomp: ComponentData) =
            let specific =
                match swcomp.SpecificModelDoc with
                | ModelDrawing _ -> failwith ""
                | ModelPart _ -> ComponentEasyPart
                | ModelAssembly _ ->
                    let isRoute = swcomp.RouteAssemblyDistance = 0
                    let children =
                        swcomp.getChildren()
                        |> Array.map(fun child -> loop child)
                        |> Array.toList
                    ComponentEasyAssembly(isRoute,children)

            {
                title     = Path.GetFileNameWithoutExtension(swcomp.ModelDoc2.GetTitle())
                refconfig = swcomp.Component2.ReferencedConfiguration
                refid     = swcomp.Component2.ComponentReference
                isVirtual = swcomp.Component2.IsVirtual
                props     = swcomp.Props
                specific  = specific
            }
        loop comp

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

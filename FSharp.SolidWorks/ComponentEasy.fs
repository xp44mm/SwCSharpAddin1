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
    | ComponentEasyAssembly of isRoute:bool * children:ComponentEasy list
    | ComponentEasyPart

    member this.toLine() =
        match this with
        | ComponentEasyAssembly(isRoute,_) -> if isRoute then "route assembly" else "assembly"
        | ComponentEasyPart -> "part"

type ComponentEasy =
    {
        title:string
        refconfig:string
        refid:string
        props:Map<string,Json>
        specific: ComponentEasySpecific
    }

    static member from (comp: ComponentData) =
        let types = set [""]
        let rec loop (parentProps:Map<string,Json>) (swcomp: ComponentData) =
            let props = 
                if parentProps.IsEmpty then
                    swcomp.Props
                else
                    parentProps
                    |> Map.toList
                    |> Json.Object
                    |> Map.add ".." <| swcomp.Props
                
            let specific =
                match swcomp.SpecificModelDoc with
                | ModelDrawing _ -> failwith ""
                | ModelPart _ -> ComponentEasyPart
                | ModelAssembly assy ->
                    let isRoute = swcomp.RouteAssemblyDistance = 0
                    let children =
                        swcomp.getChildren()
                        |> Array.map(fun child ->
                            loop props child
                        )
                        |> Array.toList
                    ComponentEasyAssembly(isRoute,children)

            {
                title     = swcomp.ModelDoc2.GetTitle()
                refconfig = swcomp.Component2.ReferencedConfiguration
                refid     = swcomp.Component2.ComponentReference
                props     = props
                specific  = specific
            }
        loop Map.empty comp

    static member fromModel(root: ModelDoc2) =
        root
        |> ComponentData.fromModel
        |> ComponentEasy.from

    member this.toLine() =
        let s0 = $"{this.title}({this.refconfig}){{{this.refid}}}"
        let props =
            this.props
            |> Map.toList
            |> List.map(fun(name,j) -> $"{stringify name},{FSharp.Idioms.Json.print j}")
            |> String.concat ";"
            |> sprintf "[%s]"

        [
            s0
            props
            this.specific.toLine()
        ]
        |> List.filter((<>) "")
        |> String.concat " "

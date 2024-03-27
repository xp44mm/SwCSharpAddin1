namespace rec FSharp.SolidWorks

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open System
open System.IO

open FSharp.Idioms
open FSharp.Idioms.Literal

type ComponentDataSpecific =
    | ComponentDataRouteAssembly of AssemblyDoc
    | ComponentDataAssembly of AssemblyDoc
    | ComponentDataPart of PartDoc

    static member from (swModel:ModelDoc2) =
        match ModelSpecific.from swModel with
        | ModelAssembly assy ->
            if assy.IsRouteAssembly() then
                ComponentDataRouteAssembly assy
            else 
                ComponentDataAssembly assy
        | ModelPart part -> ComponentDataPart part
        | ModelDrawing _ -> failwith "never"

    member this.toLine() =
        match this with
        | ComponentDataPart _ -> "Part"
        | ComponentDataAssembly _ -> "Assembly"
        | ComponentDataRouteAssembly _ -> "Route"

type ComponentData =
    {
        Component2: Component2
        ModelDoc2: ModelDoc2
        Props: Map<string,string*string> // <name,type*value>
        Comments: list<Component2*string>
        Specific: ComponentDataSpecific
    }

    static member from(comp: Component2, model: ModelDoc2) =
        let props =
            ModelDoc2Utils.readPropsAll comp.ReferencedConfiguration model
            |> List.map(fun (name,tp,v) -> name, (tp,v) )
            |> Map.ofList
        let comments =
            model.FirstFeature()
            |> FeatureUtils.getFeatureSeq
            |> CommentUtils.tryGetCommentFolder
            |> Option.map (fun folder ->
                folder
                |> CommentUtils.tryGetComments
                |> Option.map List.ofArray
                |> Option.defaultValue []
                )
            |> Option.defaultValue []

        let spc = ComponentDataSpecific.from model

        {
            Component2 = comp
            ModelDoc2 = model
            Props = props
            Comments = comments
            Specific = spc
        }

    static member fromModel(root: ModelDoc2) =
        // Get it's root component
        let config = root.ConfigurationManager.ActiveConfiguration
        let swRootComp = config.GetRootComponent3(true)
        ComponentData.from(swRootComp, root)

    member this.getChildren() =
        this.Component2.GetChildren()
        :?> obj[]
        |> Array.map(fun o ->  o :?> Component2)
        |> Array.choose(fun child ->
            child
            |> Component2Utils.tryGetModelDoc2
            |> Option.map(fun childModel -> child,childModel)
            )
        |> Array.map(fun (comp,model) ->
            ComponentData.from(comp, model)
        )

    member this.toLine() =
        let s0 =
            [
            Path.GetFileNameWithoutExtension(this.ModelDoc2.GetTitle())
            "("
            this.Component2.ReferencedConfiguration
            ")"
            "{"
            this.Component2.ComponentReference
            "}"
            ]
            |> String.concat ""

        let comments = 
            this.Comments
            |> List.map(fun (comp,text)  ->
                $"{comp.Name2},{text}"
            )
            |> stringify
            
        [
            s0
            this.Specific.toLine()
            stringify (Map.toList this.Props)
            comments
        ]
        |> List.filter((<>) "")
        |> String.concat " "


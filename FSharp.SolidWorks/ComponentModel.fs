namespace rec FSharp.SolidWorks

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open System
open System.IO

open FSharp.Idioms
open FSharp.Idioms.Literal

type ComponentModelSpecific =
    | ComponentModelAssembly of AssemblyDoc
    | ComponentModelPart of PartDoc

    static member from (swModel:ModelDoc2) =
        match ModelSpecific.from swModel with
        | ModelAssembly assy -> ComponentModelAssembly assy
        | ModelPart part -> ComponentModelPart part
        | ModelDrawing _ -> failwith "never"

type ComponentModel =
    {
        Component2: Component2
        ModelDoc2: ModelDoc2
        Specific: ComponentModelSpecific
    }

    static member from(comp: Component2, model: ModelDoc2) =
        {
            Component2 = comp
            ModelDoc2 = model
            Specific = ComponentModelSpecific.from model
        }

    static member fromModel(root: ModelDoc2) =
        let config = root.ConfigurationManager.ActiveConfiguration
        let swRootComp = config.GetRootComponent3(true)
        ComponentModel.from(swRootComp, root)

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
            ComponentModel.from(comp, model)
        )


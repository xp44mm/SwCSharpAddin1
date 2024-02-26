namespace rec FSharp.SolidWorks

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open System
open System.IO

open FSharp.Idioms.Literal
open FSharp.Idioms.Jsons

type ComponentData =
    {
        Component2: Component2
        ModelDoc2: ModelDoc2
        Props:Map<string,Json> // <name,type*value>
        SpecificModelDoc: ModelSpecific
        RouteAssemblyDistance: int // 管道装配体不能嵌套，-1代表没有route，0代表本组件,1代表父组件是route，2代表祖父组件。

    }

    static member from(parentRouteDistance:int, comp: Component2, model: ModelDoc2) =
        let props =
            ModelDoc2Utils.readPropsAll comp.ReferencedConfiguration model
            |> List.map(fun (name,tp,v) -> 
                let j =
                    match tp with
                    | "Text" -> Json.String v
                    | "Number" -> Json.Number (Double.Parse v)
                    | "YesOrNo" -> if v = "Yes" then Json.True else Json.False
                    | _ -> failwith $"{name},{tp},{v}"
                name, j
                )
            |> Map.ofList
        let spc = ModelSpecific.from model
        let routeDist =
            match spc with
            | ModelDrawing _ -> failwith ""
            | ModelPart prt ->
                if parentRouteDistance < 0 then
                    -1 
                else 
                    parentRouteDistance + 1
            | ModelAssembly assy ->
                if assy.IsRouteAssembly() then 
                    0 
                elif parentRouteDistance < 0 then 
                    -1 
                else parentRouteDistance + 1
        {
            Component2 = comp
            ModelDoc2 = model
            Props = props
            SpecificModelDoc = spc
            RouteAssemblyDistance = routeDist
        }

    static member fromModel(root: ModelDoc2) =
        // Get it's root component
        let swRootComp = root.ConfigurationManager.ActiveConfiguration.GetRootComponent3(true)
        ComponentData.from(-1, swRootComp, root)
    member this.getChildren() =
        this.Component2.GetChildren()
        :?> obj[]
        |> Array.map(fun o -> 
            let child = o :?> Component2
            let childModel = child.GetModelDoc2() :?> ModelDoc2
            child,childModel
            )
        |> Array.map(fun (comp,model) ->
            ComponentData.from(this.RouteAssemblyDistance, comp, model) 
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

        let typ =
            match this.SpecificModelDoc with
            | ModelDrawing _ -> failwith ""
            | ModelPart prt ->
                "Part"
            | ModelAssembly assy ->
                if this.RouteAssemblyDistance = 0 then
                    "Route"
                else
                    "Assembly"

        [
            s0
            typ
            this.RouteAssemblyDistance.ToString()
            stringify (Map.toList this.Props)
        ]
        |> List.filter((<>) "")
        |> String.concat " "


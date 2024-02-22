namespace rec FSharp.SolidWorks

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open System.IO
open FSharp.Idioms.Literal

type ComponentData =
    {
        Component2: Component2
        ModelDoc2: ModelDoc2
        Props:Map<string,string*string> // <name,type*value>
        SpecificModelDoc: ModelSpecific
        RouteAssemblyDistance: int // 管道装配体不能嵌套，-1代表没有route，0代表本组件,1代表父组件是route，2代表祖父组件。

    }

    static member from (component2: Component2) (modelDoc2: ModelDoc2) parentRouteDistance =
        let props =
            ModelDoc2Utils.readPropsAll component2.ReferencedConfiguration modelDoc2
            |> List.map(fun (name,tp,v) -> name,(tp,v))
            |> Map.ofList
        let spc = ModelSpecific.from modelDoc2
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
            Component2 = component2
            ModelDoc2 = modelDoc2
            Props = props
            SpecificModelDoc = spc
            RouteAssemblyDistance = routeDist
        }

    member this.getChildren() =
        this.Component2.GetChildren()
        :?> obj[]
        |> Array.map(fun o -> 
            let child = o :?> Component2
            let childModel = child.GetModelDoc2() :?> ModelDoc2
            child,childModel
            )
        |> Array.map(fun (comp,model) ->
            ComponentData.from comp model this.RouteAssemblyDistance
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


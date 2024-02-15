namespace rec FSharp.SolidWorks

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open System.IO
open FSharp.Idioms.Literal

type ComponentClosureSpecific =
    | SpecificComponentAssembly of AssemblyDoc * GeneralComponentClosure[]
    | SpecificComponentPart of PartDoc

// traverse traveller
type GeneralComponentClosure =
    {
        Component2: Component2
        ModelDoc2: ModelDoc2
        Props:Map<string,string*string>
        RouteAssemblyPosition: int // 管道装配体不能嵌套，-1代表没有route，0代表本组件,1代表父组件是route，2代表祖父组件。
        SpecificModelDoc: ComponentClosureSpecific
    }

    static member from (component2: Component2) (modelDoc2: ModelDoc2) (parentRoutePos:int) =
        let props =
            ModelDoc2Utils.readPropsAll component2.ReferencedConfiguration modelDoc2
            |> List.map(fun (name,tp,v) -> name,(tp,v))
            |> Map.ofList

        match ModelSpecific.from modelDoc2 with
        | ModelDrawing _ -> failwith ""
        | ModelPart prt ->
            {
                Component2 = component2
                ModelDoc2 = modelDoc2
                Props = props
                RouteAssemblyPosition = if parentRoutePos < 0 then -1 else parentRoutePos + 1
                SpecificModelDoc = SpecificComponentPart prt
            }
        | ModelAssembly assy ->
            let routePos =
                if parentRoutePos >= 0 then
                    parentRoutePos + 1
                elif assy.IsRouteAssembly() then 0 else -1
            let children =
                component2.GetChildren()
                :?> obj[]
                |> Array.map(fun o -> o :?> Component2)
                |> Array.map(fun swComp ->
                    let modelDoc = swComp.GetModelDoc2() :?> ModelDoc2
                    GeneralComponentClosure.from swComp modelDoc routePos
                )

            {
                Component2 = component2
                ModelDoc2 = modelDoc2
                Props = props
                RouteAssemblyPosition = routePos
                SpecificModelDoc = SpecificComponentAssembly(assy,children)
            }

    member this.getTitleLine() =
        let s0 =
            [
            Path.GetFileNameWithoutExtension(this.ModelDoc2.GetTitle())
            "("
            this.Component2.ReferencedConfiguration //for root it is empty
            ")"
            "{"
            this.Component2.ComponentReference
            "}"
            ]
            |> String.concat ""

        let stp =
            match this.SpecificModelDoc with
            | SpecificComponentAssembly _ ->
                if this.RouteAssemblyPosition = 0 then
                    "Route"
                else
                    "Assembly"
            | SpecificComponentPart _ ->
                "Part"

        [
            s0
            stp
            this.RouteAssemblyPosition.ToString()
            stringify (Map.toList this.Props)
        ]
        |> List.filter((<>) "")
        |> String.concat " "

    member this.getlines() =
        [|
            this.getTitleLine()

            match this.SpecificModelDoc with
            | SpecificComponentAssembly (assy,ccomps) ->
                yield! ccomps |> Array.collect(fun ccl ->
                    ccl.getlines()
                    |> Array.map((+)"   ")
                )
            | SpecificComponentPart _ -> ()
        |]

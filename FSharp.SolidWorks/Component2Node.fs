namespace FSharp.SolidWorks

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO

type Component2Node = 
    | Component2Node of Component2 * Component2Node []

    static member from (swComp:Component2) =
        let children =
            swComp.GetChildren()
            :?> obj[]
            |> Array.map(fun o -> 
                o :?> Component2 
                |> Component2Node.from)
        Component2Node(swComp, children)


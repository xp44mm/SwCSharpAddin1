namespace FSharp.SolidWorks.RouteCompFields

open FSharp.Idioms
open FSharp.Idioms.Jsons

type ComponentEasyData =
    {
        title:string
        refconfig:string
        refid:string
        props:Map<string,Json>
    }

type RouteAssemblyFields =
    {
        PN: float
        Material: string
    }

type PipeFields =
    {
        PN:float
        DN:float
        Material:string
        Length:float
    }

type ElbowFields =
    {
        DN:float
        PN:float
        Material:string
        Angle:float
    }

type ReducerFields =
    {
        DN1:float
        DN2:float
        PN:float
        Material:string
    }

type TeeFields =
    {
        DN:float
        PN:float
        Material:string
    }

type ReducingTeeFields =
    {
        DN1:float
        DN2:float
        PN:float
        Material:string
    }

type FlangeFields =
    {
        PN:float
        DN:float
        Material:string
    }

type FittingFields =
    {
        DN: float
        PN:float
        refid:string
    }

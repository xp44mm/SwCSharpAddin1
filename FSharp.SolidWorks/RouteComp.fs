namespace rec FSharp.SolidWorks

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO
open System.Text.RegularExpressions

open FSharp.Idioms.Literal

type RouteComp =
    | Pipe of PipeRow
    | Elbow of ElbowRow
    | Reducer of ReducerRow
    | EccentricReducer of ReducerRow
    | Tee of TeeRow
    | ReducingTee of ReducingTeeRow
    | Flange of FlangeRow
    | Valve of ValveRow
    | FittingOther
    | AssemblyFittings
    | GeneralComponent of ComponentData
    | Flanges of ComponentData * FlangeRow

    | Gasket of dn:float * count:int
    | Nut of m: float * count:int
    | Washer of m: float * count:int
    | Bolt of m:float * l:float * count:int
    | DoubleScrewBolt of m:float * l:float * count:int
    
    //| Cross
    //| ReducingCross

    //| Clip
    //| Hanger
    //| Support

    //| Adapter
    //| CableTray
    //| Conduit
    //| ConduitAdapter
    //| ConduitElbow
    //| DuctingTrunking
    //| EndConnector
    //| Equipment
    //| FlexCableConnector
    //| HybridComponents
    //| Nipple
    //| OLet
    //| RibbonCable
    //| Splice
    //| TeeAdapter
    //| Tube
    //| Union
    //| Unknown

    member this.toLine() =
        match this with
        | Pipe _ 
        | Elbow _ 
        | Reducer _ 
        | EccentricReducer _
        | Tee _ 
        | ReducingTee _ 
        | Flange _ 
        | Valve _ 
        | Bolt _
        | Nut _
        | Gasket _
            -> stringify this
        | Flanges(data,row) -> 
            "Flanges" + stringify row
        | GeneralComponent data -> data.toLine()
        | _ -> failwith ""

type PipeRow =
    {
        DN:float
        Length:float
    }

type ElbowRow =
    {
        DN:float
        Angle:float
    }

type ReducerRow =
    {
        DN1:float
        DN2:float
    }

type TeeRow =
    {
        DN:float
    }

type ReducingTeeRow =
    {
        DN1:float
        DN2:float
    }

type FlangeRow =
    {
        DN: float
    }

type ValveRow =
    {
        Name:string
        DN: float
    }


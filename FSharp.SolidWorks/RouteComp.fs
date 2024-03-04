namespace rec FSharp.SolidWorks

open FSharp.SolidWorks.RouteCompFields

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO
open System.Text.RegularExpressions

open FSharp.Idioms.Literal
open FSharp.Reflection
open FSharp.Idioms
open FSharp.Idioms.Jsons

type RouteComp =
    | RouteAssembly
    | RawComponent
    //一般管件
    | Pipe  of dn:float * length:float
    | Elbow of dn:float * angle:float

    | Tee    of dn:float
    | Flange of dn:float

    | Reducer          of dn1:float * dn2:float
    | EccentricReducer of dn1:float * dn2:float
    | ReducingTee      of dn1:float * dn2:float

    // 配件fittings
    | BallValve of dn:float
    //| AutomaticBallValve of dn:float
    | WaferButterflyValve of dn:float
    //| AutomaticWaferButterflyValve of dn:float
    | WaferCheckValve     of dn:float
    | Expansion           of dn:float
    | Flowmeter           of dn:float
    | MagneticFilter      of dn:float

    // 装配体配件AssemblyFittings
    | SingleFlange               of children:RouteWrapper list
    | Flanges                    of children:RouteWrapper list
    | BallValveFlanges           of children:RouteWrapper list
    | BallValveSolo              of children:RouteWrapper list
    | WaferButterflyValveFlanges of children:RouteWrapper list
    | WaferButterflyValveSolo    of children:RouteWrapper list

    //| AutomaticBallValveFlanges           of children:RouteWrapper list
    //| AutomaticBallValveSolo              of children:RouteWrapper list
    //| AutomaticWaferButterflyValveFlanges of children:RouteWrapper list
    //| AutomaticWaferButterflyValveSolo    of children:RouteWrapper list

    | WaferCheckValveFlanges     of children:RouteWrapper list
    | ExpansionFlanges           of children:RouteWrapper list
    | ExpansionSolo              of children:RouteWrapper list
    | FlowmeterFlanges           of children:RouteWrapper list
    | MagneticFilterFlanges      of children:RouteWrapper list

    //// 附件accessories
    //| Gasket of dn:float * count:int
    //| Nut of m: float * count:int
    //| Washer of m: float * count:int
    //| Bolt of m:float * l:float * count:int
    //| StudBolt of m:float * l:float * count:int

type RouteWrapper =
    {
        comp: ComponentEasy
        route: RouteComp
    }


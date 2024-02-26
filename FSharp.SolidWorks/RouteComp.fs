namespace FSharp.SolidWorks

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
    // 装配体
    | ComponentEasyAssembly of ComponentEasy * children: RouteComp list
    | ComponentEasyPart of ComponentEasy

    //一般管件
    | Pipe  of dn:float * pn:float * material:string * length:float
    | Elbow of dn:float * pn:float * material:string * angle:float

    | Reducer          of dn1:float * dn2:float * pn:float * material:string
    | EccentricReducer of dn1:float * dn2:float * pn:float * material:string
    | ReducingTee      of dn1:float * dn2:float * pn:float * material:string

    | Tee    of dn:float * pn:float * material:string
    | Flange of dn:float * pn:float * material:string

    // 配件fittings
    | BallValve           of dn:float * pn:float * material:string
    | Expansion           of dn:float * pn:float * material:string
    | Flowmeter           of dn:float * pn:float * material:string
    | MagneticFilter      of dn:float * pn:float * material:string
    | WaferButterflyValve of dn:float * pn:float * material:string
    | WaferCheckValve     of dn:float * pn:float * material:string

    // 装配体配件AssemblyFittings
    | BallValveFlanges           of dn:float * pn:float * children:RouteComp list
    | BallValveSolo              of dn:float * pn:float * children:RouteComp list
    | ExpansionFlanges           of dn:float * pn:float * children:RouteComp list
    | ExpansionSolo              of dn:float * pn:float * children:RouteComp list
    | Flanges                    of dn:float * pn:float * children:RouteComp list
    | FlowmeterFlanges           of dn:float * pn:float * children:RouteComp list
    | MagneticFilterFlanges      of dn:float * pn:float * children:RouteComp list
    | WaferButterflyValveFlanges of dn:float * pn:float * children:RouteComp list
    | WaferButterflyValveSolo    of dn:float * pn:float * children:RouteComp list
    | WaferCheckValveFlanges     of dn:float * pn:float * children:RouteComp list

    // 附件accessories
    | Gasket of dn:float * pn:float * material:string * count:int
    | Nut of m: float * material:string * count:int
    | Washer of m: float * material:string * count:int
    | Bolt of m:float * l:float * material:string * count:int
    | DoubleScrewBolt of m:float * l:float * material:string * count:int

    //member this.toLine() =
    //    match this with
    //    | Pipe _ 
    //    | Elbow _ 
    //    | Reducer _ 
    //    | EccentricReducer _
    //    | Tee _ 
    //    | ReducingTee _ 
    //    | Flange _ 
    //    | Bolt _
    //    | Nut _
    //    | Gasket _
    //    | Washer _
    //    | DoubleScrewBolt _
    //    | BallValve            _
    //    | Expansion            _
    //    | Flowmeter            _
    //    | MagneticFilter       _
    //    | WaferButterflyValve  _
    //    | WaferCheckValve      _
    //        -> stringify this
    //    | BallValveFlanges (data,row)
    //    | BallValveSolo (data,row)
    //    | ExpansionFlanges (data,row)
    //    | ExpansionSolo (data,row)
    //    | Flanges (data,row)
    //    | FlowmeterFlanges (data,row)
    //    | MagneticFilterFlanges (data,row)
    //    | WaferButterflyValveFlanges (data,row)
    //    | WaferButterflyValveSolo (data,row)
    //    | WaferCheckValveFlanges (data,row)
    //        -> 
    //        let typ = this.GetType()
    //        let unionCases = FSharpType.GetUnionCases(typ)
    //        let tagReader = FSharpValue.PreComputeUnionTagReader typ
    //        let tag = tagReader this
    //        let name = unionCases.[tag].Name
    //        name + stringify row

    //    | GeneralComponent data -> data.toLine()

        //| _ -> failwith ""

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

//| Valve
//| FittingOther
//| AssemblyFittings


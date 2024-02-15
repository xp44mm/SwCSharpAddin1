namespace rec PipeComponents

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO
open System.Text.RegularExpressions

open FSharp.SolidWorks
open FSharp.Idioms.Literal

type ComponentRow =
    {
        name: string
        ReferencedConfiguration: string
        ComponentReference: string
        SpecificData: ComponentSpecificData
    }
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

type ComponentSpecificData =
    | DataGenericPart
    | DataGenericAssembly of children:ComponentRow []
    | DataBallValue
    | DataBallValueFlanges
    | DataBallValueSolo
    | DataEccentricReducer
    | DataElbow of angle:float
    | DataExpansion
    | DataExpansionFlanges
    | DataExpansionSolo
    | DataFlange
    | DataFlanges
    | DataFlowmeter
    | DataFlowmeterFlanges
    | DataMagneticFilter
    | DataMagneticFilterFlanges
    | DataPipe of length:float
    | DataReducer
    | DataReducingOutletTee
    | DataRouteAssembly of children:ComponentRow []
    | DataStraightTee
    | DataWaferButterflyValve
    | DataWaferButterflyValveFlanges
    | DataWaferButterflyValveSolo
    | DataWaferCheckValve
    | DataWaferCheckValveFlanges


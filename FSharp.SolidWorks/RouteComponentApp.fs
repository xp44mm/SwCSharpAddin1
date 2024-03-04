module rec FSharp.SolidWorks.RouteComponentApp

open FSharp.Idioms
open FSharp.Idioms.Literal

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open System
open System.Diagnostics
open System.IO
open System.Text.RegularExpressions
open FSharp.SolidWorks.RouteComponentSpecies

let modelTitles = [
    "flanges.SLDASM"
    "ball valve flanges.SLDASM"
    "ball valve solo.SLDASM"

    "wafer butterfly valve flanges.SLDASM"
    "wafer butterfly valve solo.SLDASM"
    "wafer check valve flanges.SLDASM"

    "expansion joint flanges.SLDASM"
    "expansion joint solo.SLDASM"

    "magnetic filter flanges.SLDASM"
    "flowmeter flanges.SLDASM"

    "automatic ball valve flanges.SLDASM"
    "automatic ball valve solo.SLDASM"
    "automatic wafer butterfly valve flanges.SLDASM"
    "automatic wafer butterfly valve solo.SLDASM"
    "single flanged joint.SLDASM"


    "pipe.SLDPRT"

    "automatic ball valve.SLDPRT"
    "automatic wafer butterfly valve.SLDPRT"
    "elbow LR.SLDPRT"
    "straight tee.SLDPRT"
    "flange.SLDPRT"
    "reducer.SLDPRT"
    "eccentric reducer.SLDPRT"
    "reducing outlet tee.SLDPRT"
    "ball valve.SLDPRT"
    "wafer butterfly valve.SLDPRT"
    "wafer check valve.SLDPRT"
    "expansion joint.SLDPRT"
    "flowmeter.SLDPRT"
    "magnetic filter.SLDPRT"


]

let map (data:ComponentData) =
    [
        //tryPipe
        //tryElbow
        //tryReducer
        //tryEccentricReducer
        //tryTee
        //tryReducingTee
        //tryFlange
        //tryBallValve
        //tryExpansion
        //tryFlowmeter
        //tryMagneticFilter
        //tryWaferButterflyValve
        //tryWaferCheckValve
        //tryBallValveFlanges
        //tryBallValveSolo
        //tryExpansionFlanges
        //tryExpansionSolo
        //tryFlanges
        //tryFlowmeterFlanges
        //tryMagneticFilterFlanges
        //tryWaferButterflyValveFlanges
        //tryWaferButterflyValveSolo
        //tryWaferCheckValveFlanges
        //tryRouteAssembly
        //fallback
    ]
    |> List.pick(fun fn ->
        fn data
    )

//let getChildren(this: RouteComp) =
//    match this with
//    | Flanges(data,{ DN = dn }) ->
//        let flange, screw = FlangePair.getTbl 10.0 dn
//        let m = flange.M
//        let l = FlangePair.boltLength 10.0 dn
//        let c = flange.N
//        [|
//            yield!
//                data.getChildren()
//                |> Array.map(fun child ->
//                    map child
//                )
//            Bolt(m,l,c)
//            Nut(m,c)
//            Gasket(dn,1)
//        |]

//    | BallValveFlanges (data,{ DN = dn })
//    | BallValveSolo (data,{ DN = dn })
//    | ExpansionFlanges (data,{ DN = dn })
//    | ExpansionSolo (data,{ DN = dn })
//    | FlowmeterFlanges (data,{ DN = dn })
//    | MagneticFilterFlanges (data,{ DN = dn })
//        ->
//        let flange, screw = FlangePair.getTbl 10.0 dn
//        let m = flange.M
//        let l = FlangePair.boltLength 10.0 dn
//        let c = flange.N
//        [|
//            yield!
//                data.getChildren()
//                |> Array.map(fun child ->
//                    map child
//                )
//            Bolt(m,l,c*2)
//            Nut(m,c*2)
//            Gasket(dn,2)
//        |]
//    | WaferButterflyValveFlanges (data,{ DN = dn })
//    | WaferButterflyValveSolo (data,{ DN = dn }) 
//        ->
//        let flange, screw = FlangePair.getTbl 10.0 dn
//        let valve = WaferButterflyValve.toMap().[dn]
//        let m = flange.M
//        let l = Wafer.studLength 10.0 dn valve.Length

//        let c = flange.N
//        [|
//            yield!
//                data.getChildren()
//                |> Array.map(fun child ->
//                    map child
//                )
//            DoubleScrewBolt(m,l,c*2)
//            Nut(m,c*2)
//            Gasket(dn,2)
//        |]

//    | WaferCheckValveFlanges (data,{ DN = dn })
//        ->
//        let flange, screw = FlangePair.getTbl 10.0 dn
//        let checkValve = WaferCheckValve.toMap().[dn]
//        let m = flange.M
//        let l = Wafer.studLength 10.0 dn checkValve.Length

//        let c = flange.N
//        [|
//            yield!
//                data.getChildren()
//                |> Array.map(fun child ->
//                    map child
//                )
//            DoubleScrewBolt(m,l,c*2)
//            Nut(m,c*2)
//            Gasket(dn,2)
//        |]

//    | GeneralComponent data ->
//        data.getChildren()
//        |> Array.map(fun child ->
//            map child
//        )

//    | _ -> failwith ""

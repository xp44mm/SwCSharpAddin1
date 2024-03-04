module FSharp.SolidWorks.RouteWrapperConstructor

open FSharp.Idioms
open FSharp.Idioms.Literal

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open System
open System.Diagnostics
open System.IO
open System.Text.RegularExpressions
//open FSharp.SolidWorks.RouteComponentSpecies

open ValueParser

let (|IgnoreCase|_|) t s =
    if StringComparer.OrdinalIgnoreCase.Equals(t,s) then
        Some ()
    else None

let easytoroute (easy: ComponentEasy) =
    let rec loop (data: ComponentEasy) =
        match data.specific with
        | ComponentEasyPart ->
            match data.title with
            | IgnoreCase "elbow LR.SLDPRT" ->
                let angle,dn =
                    parseElbow data.refconfig
                {
                    comp = data
                    route = Elbow(dn,angle)
                }

            | IgnoreCase "straight tee.SLDPRT" ->
                let dn = 0.0
                {
                    comp = data
                    route = Tee(dn)
                }

            | IgnoreCase "flange.SLDPRT" -> // 父组件是管道的法兰，需要带紧固件
                let dn = 0.0
                {
                    comp = data
                    route = Flange(dn)
                }
                            
            | IgnoreCase "reducer.SLDPRT" ->
                let dn1 = 0.0
                let dn2 = 0.0
                {
                    comp = data
                    route = Reducer(dn1,dn2)
                }

            | IgnoreCase "eccentric reducer.SLDPRT" ->
                let dn1 = 0.0
                let dn2 = 0.0
                {
                    comp = data
                    route = EccentricReducer(dn1,dn2)
                }

            | IgnoreCase "reducing outlet tee.SLDPRT" ->
                let dn1 = 0.0
                let dn2 = 0.0
                {
                    comp = data
                    route = ReducingTee(dn1,dn2)
                }

            | IgnoreCase "ball valve.SLDPRT" ->
                let dn = 0.0
                {
                    comp = data
                    route = BallValve(dn)
                }

            | IgnoreCase "wafer butterfly valve.SLDPRT" ->
                let dn = 0.0

                {
                    comp = data
                    route = WaferButterflyValve(dn)
                }

            | IgnoreCase "wafer check valve.SLDPRT" ->
                let dn = 0.0

                {
                    comp = data
                    route = WaferCheckValve(dn)
                }

            | IgnoreCase "expansion joint.SLDPRT" ->
                let dn = 0.0

                {
                    comp = data
                    route = Expansion(dn)
                }

            | IgnoreCase "flowmeter.SLDPRT" ->
                let dn = 0.0

                {
                    comp = data
                    route = Flowmeter(dn)
                }

            | IgnoreCase "magnetic filter.SLDPRT" ->
                let dn = 0.0
                {
                    comp = data
                    route = MagneticFilter(dn)
                }

            //| IgnoreCase "automatic ball valve.SLDPRT" ->
            //    let dn = 0.0
            //    {
            //        comp = data
            //        route = AutomaticBallValve(dn)
            //    }

            //| IgnoreCase "automatic wafer butterfly valve.SLDPRT" ->
            //    let dn = 0.0
            //    {
            //        comp = data
            //        route = AutomaticWaferButterflyValve(dn)
            //    }

            | x -> 
                if isCompTypeOf "Pipe" data.props then
                    let dn =
                        data.props.["Pipe Identifier"].stringText
                        |> parseDN
                    let length =
                        data.props.["Length"].stringText
                        |> parseLength

                    {
                        comp = data
                        route = Pipe(dn,length)
                    }
                elif isCompTypeOf "Elbow" data.props then
                    let angle,dn =
                        parseElbow data.refconfig
                    {
                        comp = data
                        route = Elbow(dn,angle)
                    }

                else
                    {
                        comp = data
                        route = RawComponent
                    }

        | ComponentEasyAssembly (false, children) ->
            match data.title with
            | IgnoreCase "single flanged joint.SLDASM" ->
                let children = []
                {
                    comp = data
                    route = SingleFlange(children)
                }

            | IgnoreCase "flanges.SLDASM" ->
                let children = []
                {
                    comp = data
                    route = Flanges(children)
                }

            | IgnoreCase "ball valve flanges.SLDASM" ->
                let children = []
                {
                    comp = data
                    route = BallValveFlanges(children)
                }

            | IgnoreCase "ball valve solo.SLDASM" ->
                let children = []
                {
                    comp = data
                    route = BallValveSolo(children)
                }

            | IgnoreCase "wafer butterfly valve flanges.SLDASM" ->
                let children = []
                {
                    comp = data
                    route = WaferButterflyValveFlanges(children)
                }

            | IgnoreCase "wafer butterfly valve solo.SLDASM" ->
                let children = []
                {
                    comp = data
                    route = WaferButterflyValveSolo(children)
                }

            | IgnoreCase "wafer check valve flanges.SLDASM" ->
                let children = []
                {
                    comp = data
                    route = WaferCheckValveFlanges(children)
                }

            | IgnoreCase "expansion joint flanges.SLDASM" ->
                let children = []
                {
                    comp = data
                    route = ExpansionFlanges(children)
                }

            | IgnoreCase "expansion joint solo.SLDASM" ->
                let children = []
                {
                    comp = data
                    route = ExpansionSolo(children)
                }

            | IgnoreCase "flowmeter flanges.SLDASM" ->
                let children = []
                {
                    comp = data
                    route = FlowmeterFlanges(children)
                }

            | IgnoreCase "magnetic filter flanges.SLDASM" ->
                let children = []
                {
                    comp = data
                    route = MagneticFilterFlanges(children)
                }

            //| IgnoreCase "automatic ball valve flanges.SLDASM" ->
            //    let children = []
            //    {
            //        comp = data
            //        route = AutomaticBallValveFlanges(children)
            //    }

            //| IgnoreCase "automatic ball valve solo.SLDASM" ->
            //    let children = []
            //    {
            //        comp = data
            //        route = AutomaticBallValveSolo(children)
            //    }

            //| IgnoreCase "automatic wafer butterfly valve flanges.SLDASM" ->
            //    let children = []
            //    {
            //        comp = data
            //        route = AutomaticWaferButterflyValveFlanges(children)
            //    }

            //| IgnoreCase "automatic wafer butterfly valve solo.SLDASM" ->
            //    let children = []
            //    {
            //        comp = data
            //        route = AutomaticWaferButterflyValveSolo(children)
            //    }

            | _ ->
                
                {
                    comp = data
                    route = RawComponent
                }
        | ComponentEasyAssembly (true, children) ->
            {
                comp = data
                route = RouteAssembly
            }
    loop easy

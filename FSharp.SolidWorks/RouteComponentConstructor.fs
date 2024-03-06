module FSharp.SolidWorks.RouteComponentConstructor

open FSharp.Idioms
open FSharp.Idioms.Literal

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open System
open System.Diagnostics
open System.IO
open System.Text.RegularExpressions

open ValueParser

let (|IgnoreCase|_|) a b =
    if StringComparer.OrdinalIgnoreCase.Equals(a,b) then
        Some()
    else None

let toroute (easy: ComponentEasy) =
    let rec loop (data: ComponentEasy) =
        let title     = data.title    
        let refconfig = data.refconfig
        let refid     = data.refid    

        match data.specific with
        | ComponentEasyPart ->
            match data.title with
            | IgnoreCase "elbow LR" ->
                let angle,dn =
                    parseElbow data.refconfig
                {
                    refid     = data.refid
                    specific = Elbow(dn,angle)
                }

            | IgnoreCase "straight tee" ->
                let dn = parseDN data.refconfig
                {
                    refid    = data.refid
                    specific = Tee(dn)
                }

            | IgnoreCase "flange" -> // 父组件是管道的法兰，需要带紧固件
                let dn = parseDN data.refconfig
                {
                    refid     = data.refid
                    specific = Flange(dn)
                }
                            
            | IgnoreCase "reducer" ->
                let dn1,dn2 =
                    parseDNxDN data.refconfig
                {
                    refid     = data.refid
                    specific = Reducer(dn1,dn2)
                }

            | IgnoreCase "eccentric reducer" ->
                let dn1,dn2 =
                    parseDNxDN data.refconfig
                {
                    refid     = data.refid
                    specific = EccentricReducer(dn1,dn2)
                }

            | IgnoreCase "reducing outlet tee" ->
                let dn1,dn2 =
                    parseDNxDN data.refconfig
                {
                    refid     = data.refid
                    specific = ReducingTee(dn1,dn2)
                }

            | IgnoreCase "ball valve" ->
                let dn = parseDN data.refconfig
                {
                    refid     = data.refid
                    specific = BallValve(dn)
                }

            | IgnoreCase "wafer butterfly valve" ->
                let dn = parseDN data.refconfig

                {
                    refid     = data.refid
                    specific = WaferButterflyValve(dn)
                }

            | IgnoreCase "wafer check valve" ->
                let dn = parseDN data.refconfig

                {
                    refid     = data.refid
                    specific = WaferCheckValve(dn)
                }

            | IgnoreCase "expansion joint" ->
                let dn = parseDN data.refconfig
                {
                    refid     = data.refid
                    specific = Expansion(dn)
                }

            | IgnoreCase "flowmeter" ->
                let dn = parseDN data.refconfig
                {
                    refid     = data.refid
                    specific = Flowmeter(dn)
                }

            | IgnoreCase "magnetic filter" ->
                let dn = parseDN data.refconfig
                {
                    refid     = data.refid
                    specific = MagneticFilter(dn)
                }

            | x -> 
                if isCompTypeOf "Pipe" data.props then
                    let dn =
                        data.props.["Pipe Identifier"]
                        |> snd
                        |> parseDN
                    let length =
                        data.props.["Length"]
                        |> snd
                        |> parseLength

                    {
                        refid     = data.refid
                        specific = Pipe(dn,length)
                    }
                elif isCompTypeOf "Elbow" data.props then
                    let angle,dn =
                        parseElbow data.refconfig
                    {
                        refid     = data.refid
                        specific = Elbow(dn,angle)
                    }

                else
                    {
                        refid    = data.refid
                        specific = ComponentPart(data.title,data.refconfig)
                    }

        | ComponentEasyAssembly (false, children) ->
            let children = 
                children
                |> List.map(fun child -> loop child)

            match data.title with
            | IgnoreCase "single flanged joint" ->
                let dn = parseDN data.refconfig

                {
                    refid    = data.refid
                    specific = SingleFlange(dn,children)
                }

            | IgnoreCase "flanges" ->
                let dn = parseDN data.refconfig
                {
                    refid    = data.refid
                    specific = Flanges(dn,children)
                }
            | IgnoreCase "ball valve flanges" ->
                let dn = parseDN data.refconfig
                {
                    refid    = data.refid
                    specific = BallValveFlanges(dn,children)
                }
            | IgnoreCase "ball valve solo" ->
                let dn = parseDN data.refconfig
                {
                    refid    = data.refid
                    specific = BallValveSolo(dn,children)
                }
            | IgnoreCase "wafer butterfly valve flanges" ->
                let dn = parseDN data.refconfig
                {
                    refid    = data.refid
                    specific = WaferButterflyValveFlanges(dn,children)
                }

            | IgnoreCase "wafer butterfly valve solo" ->
                let dn = parseDN data.refconfig
                {
                    refid    = data.refid
                    specific = WaferButterflyValveSolo(dn,children)
                }

            | IgnoreCase "wafer check valve flanges" ->
                let dn = parseDN data.refconfig
                {
                    refid    = data.refid
                    specific = WaferCheckValveFlanges(dn,children)
                }

            | IgnoreCase "expansion joint flanges" ->
                let dn = parseDN data.refconfig
                {
                    refid    = data.refid
                    specific = ExpansionFlanges(dn,children)
                }

            | IgnoreCase "expansion joint solo" ->
                let dn = parseDN data.refconfig
                {
                    refid    = data.refid
                    specific = ExpansionSolo(dn,children)
                }

            | IgnoreCase "flowmeter flanges" ->
                let dn = parseDN data.refconfig
                {
                    refid    = data.refid
                    specific = FlowmeterFlanges(dn,children)
                }

            | IgnoreCase "magnetic filter flanges" ->
                let dn = parseDN data.refconfig
                {
                    refid    = data.refid
                    specific = MagneticFilterFlanges(dn,children)
                }
            | _ ->
                {
                    refid    = data.refid
                    specific = ComponentAssembly(data.title,data.refconfig, children)
                }
        | ComponentEasyAssembly (true, children) ->
            let children = 
                children
                |> List.map(fun child -> loop child)

            {
                refid    = data.refid
                specific = RouteAssembly(data.title, children)
            }
    loop easy

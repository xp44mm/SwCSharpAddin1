module rec FSharp.SolidWorks.RouteComponentSpecies

open FSharp.Idioms
open FSharp.Idioms.Literal

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open System
open System.Diagnostics
open System.IO
open System.Text.RegularExpressions
open FlangeAssemblyBOM

let isCompTypeOf (compName:string) (data:ComponentData) =
    data.Props.ContainsKey "Component Type" && 
    snd data.Props.["Component Type"] = compName

let parseDN x =
    Double.Parse(Regex.Match(x,"^DN (\d+)$").Groups.[1].Value)

let parseDNxDN config =
    let gs = Regex.Match(config,"^DN (\d+) x (\d+)$").Groups
    Double.Parse(gs.[1].Value),Double.Parse(gs.[2].Value)

let parseLength x =
    Double.Parse(Regex.Match(x,"^(\d+(\.\d+)?)mm$").Groups.[1].Value)

let parseElbow x =
    let gs = Regex.Match(x,"^(\d+(?:\.\d+)?)° DN (\d+)$").Groups
    Double.Parse(gs.[1].Value),Double.Parse(gs.[2].Value)

let tryPipe (data:ComponentData) =
    match data.SpecificModelDoc with
    | ModelSpecific.ModelPart prt ->
        if isCompTypeOf "Pipe" data then
            let dn = 
                data.Props.["Pipe Identifier"]
                |> snd
                |> parseDN
            let len = 
                snd data.Props.["Length"]
                |> parseLength

            Some(Pipe { DN = dn; Length = len })
        else
            None
    | ModelAssembly assy -> None
    | _ -> failwith ""

let tryElbow (data:ComponentData) =
    match data.SpecificModelDoc with
    | ModelSpecific.ModelPart prt ->
        if isCompTypeOf "Elbow" data then
            let angle,dn = 
                RouteComponentSpecies.parseElbow data.Component2.ReferencedConfiguration
            Some(Elbow { DN = dn; Angle = angle })
        else
            None
    | ModelAssembly assy -> None
    | _ -> failwith ""

let tryReducer (data:ComponentData) =
    match data.SpecificModelDoc with
    | ModelSpecific.ModelPart prt ->
        if isCompTypeOf "Reducer" data then
            let dn1,dn2 = 
                RouteComponentSpecies.parseDNxDN data.Component2.ReferencedConfiguration
            Some(Reducer { DN1= dn1; DN2 = dn2 })
        else
            None
    | ModelAssembly assy -> None
    | _ -> failwith ""

let tryEccentricReducer (data:ComponentData) =
    match data.SpecificModelDoc with
    | ModelSpecific.ModelPart prt ->
        if isCompTypeOf "EccentricReducer" data then
            let dn1,dn2 = 
                RouteComponentSpecies.parseDNxDN data.Component2.ReferencedConfiguration
            Some(EccentricReducer { DN1= dn1; DN2 = dn2 })
        else
            None
    | ModelAssembly assy -> None
    | _ -> failwith ""

let tryTee (data:ComponentData) =
    match data.SpecificModelDoc with
    | ModelSpecific.ModelPart prt ->
        if isCompTypeOf "Tee" data then
            let dn = 
                data.Component2.ReferencedConfiguration
                |> parseDN
            Some(Tee { DN = dn })
        else
            None
    | ModelAssembly assy -> None
    | _ -> failwith ""

let tryReducingTee (data:ComponentData) =
    match data.SpecificModelDoc with
    | ModelSpecific.ModelPart prt ->
        if isCompTypeOf "ReducingTee" data then
            let dn1,dn2 = 
                RouteComponentSpecies.parseDNxDN data.Component2.ReferencedConfiguration
            Some(EccentricReducer { DN1= dn1; DN2 = dn2 })
        else
            None
    | ModelAssembly assy -> None
    | _ -> failwith ""

let tryFlange (data:ComponentData) =
    match data.SpecificModelDoc with
    | ModelSpecific.ModelPart prt ->
        if isCompTypeOf "Flange" data then
            let dn = 
                data.Component2.ReferencedConfiguration
                |> parseDN
            Some(Flange { DN = dn })
        else
            None
    | ModelAssembly assy -> None
    | _ -> failwith ""

let tryValve (data:ComponentData) =
    match data.SpecificModelDoc with
    | ModelSpecific.ModelPart prt ->
        if isCompTypeOf "Valve" data then
            let name = Path.GetFileNameWithoutExtension(data.ModelDoc2.GetTitle())
            let dn = 
                data.Component2.ReferencedConfiguration
                |> parseDN
            Some(Valve { Name = name; DN = dn })
        else
            None
    | ModelAssembly assy -> None
    | _ -> failwith ""

let tryFlanges (data:ComponentData) =
    match data.SpecificModelDoc with
    | ModelAssembly assy ->
        if StringComparer.OrdinalIgnoreCase.Equals("Flanges A.SLDASM",data.ModelDoc2.GetTitle()) 
            && isCompTypeOf "AssemblyFittings" data 
        then
            let dn = 
                data.Component2.ReferencedConfiguration
                |> parseDN
            Some(Flanges(data,{ DN = dn }))
        else
            None
    | ModelSpecific.ModelPart prt -> None
    | _ -> failwith ""


//let tryCross
//let tryReducingCross
//let tryAssemblyFittings
//let tryFittingOther
//let tryGeneralComponent

let fallback(data:ComponentData) = 
    GeneralComponent data 
    |> Some

let map (data:ComponentData) = 
    [
        tryPipe
        tryElbow
        tryReducer
        tryEccentricReducer
        tryTee
        tryReducingTee
        tryFlange
        tryValve
        tryFlanges
        fallback
    ]
    |> List.pick(fun fn ->
        fn data 
    )

let getChildren(this: RouteComp) =
    match this with
    | Flanges(data,{ DN = dn }) ->
        let flange, screw = FlangePair.getTbl 10.0 dn
        let m = flange.M
        let l = FlangePair.boltLength 10.0 dn
        let c = flange.N
        [|
            yield!
                data.getChildren()
                |> Array.map(fun child ->
                    map child
                )
            Bolt(m,l,c)
            Nut(m,c)
            Gasket(dn,1)
        |]
    | GeneralComponent data ->
        data.getChildren()
        |> Array.map(fun child ->
            map child
        )
    | _ -> failwith ""

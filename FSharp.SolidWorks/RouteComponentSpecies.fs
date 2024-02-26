module rec FSharp.SolidWorks.RouteComponentSpecies
open FSharp.SolidWorks.RouteCompFields

open FSharp.Idioms
open FSharp.Idioms.Literal

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open System
open System.Diagnostics
open System.IO
open System.Text.RegularExpressions
open FlangeAssemblyBOM
open FSharp.SolidWorks.ValueParser
open FSharp.Idioms.OrdinalIgnoreCase

//let tryRouteAssembly (data:ComponentData) =
//    if data.RouteAssemblyDistance = 0 then
//        let pn = data.Props.["PN"].floatValue
//        let material = data.Props.["Material"].stringText
//        Some(RouteAssembly (data,{ PN = pn; Material = material }))
//    else None

//let tryPipe (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelSpecific.ModelPart prt ->
//        if isCompTypeOf "Pipe" data then
//            let dn =
//                data.Props.["Pipe Identifier"].stringText
//                |> parseDN
//            let len =
//                data.Props.["Length"].stringText
//                |> parseLength

//            Some(Pipe { PN = 0.0; DN = dn; Material = ""; Length = len })
//        else
//            None

//    | ModelAssembly assy -> None
//    | _ -> failwith ""

//let tryElbow (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelSpecific.ModelPart prt ->
//        if isCompTypeOf "Elbow" data then
//            let angle,dn =
//                parseElbow data.Component2.ReferencedConfiguration
//            Some(Elbow { PN = 0.0;DN = dn; Angle = angle; Material = ""; })
//        else
//            None
//    | ModelAssembly assy -> None
//    | _ -> failwith ""

//let tryFlange (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelSpecific.ModelPart prt ->
//        if isCompTypeOf "Flange" data then
//            let dn =
//                data.Component2.ReferencedConfiguration
//                |> parseDN
//            Some(Flange { PN = 0.0; DN = dn; Material = ""; })
//        else
//            None
//    | ModelAssembly assy -> None
//    | _ -> failwith ""

//let tryReducer (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelSpecific.ModelPart prt ->
//        if isCompTypeOf "Reducer" data then
//            let dn1,dn2 =
//                parseDNxDN data.Component2.ReferencedConfiguration
//            Some(Reducer { DN1= dn1; DN2 = dn2; PN = 0.0; Material = ""; })
//        else
//            None
//    | ModelAssembly assy -> None
//    | _ -> failwith ""

//let tryEccentricReducer (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelSpecific.ModelPart prt ->
//        if isCompTypeOf "EccentricReducer" data then
//            let dn1,dn2 =
//                parseDNxDN data.Component2.ReferencedConfiguration
//            Some(EccentricReducer { DN1= dn1; DN2 = dn2; PN = 0.0; Material = ""; })
//        else
//            None
//    | ModelAssembly assy -> None
//    | _ -> failwith ""

//let tryTee (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelSpecific.ModelPart prt ->
//        if isCompTypeOf "Tee" data then
//            let dn =
//                data.Component2.ReferencedConfiguration
//                |> parseDN
//            Some(Tee { DN = dn; PN = 0.0; Material = ""; })
//        else
//            None
//    | ModelAssembly assy -> None
//    | _ -> failwith ""

//let tryReducingTee (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelSpecific.ModelPart prt ->
//        if isCompTypeOf "ReducingTee" data then
//            let dn1,dn2 =
//                parseDNxDN data.Component2.ReferencedConfiguration
//            Some(EccentricReducer { DN1= dn1; DN2 = dn2; PN = 0.0; Material = ""; })
//        else
//            None
//    | ModelAssembly assy -> None
//    | _ -> failwith ""

//let tryBallValve (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelSpecific.ModelPart prt ->
//        let name = Path.GetFileNameWithoutExtension(data.ModelDoc2.GetTitle())

//        if StringComparer.OrdinalIgnoreCase.Equals("ball valve",name) then
//            let dn =
//                data.Component2.ReferencedConfiguration
//                |> parseDN
//            Some(BallValve dn)
//        else
//            None
//    | ModelAssembly assy -> None
//    | _ -> failwith ""

//let tryExpansion (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelSpecific.ModelPart prt ->
//        let name = Path.GetFileNameWithoutExtension(data.ModelDoc2.GetTitle())
//        if StringComparer.OrdinalIgnoreCase.Equals("expansion",name) then
//            let dn =
//                data.Component2.ReferencedConfiguration
//                |> parseDN
//            Some(Expansion dn)
//        else
//            None
//    | ModelAssembly assy -> None
//    | _ -> failwith ""

//let tryFlowmeter (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelSpecific.ModelPart prt ->
//        let name = Path.GetFileNameWithoutExtension(data.ModelDoc2.GetTitle())
//        if StringComparer.OrdinalIgnoreCase.Equals("flowmeter",name) then
//            let dn =
//                data.Component2.ReferencedConfiguration
//                |> parseDN
//            Some(Flowmeter dn)
//        else
//            None
//    | ModelAssembly assy -> None
//    | _ -> failwith ""

//let tryMagneticFilter (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelSpecific.ModelPart prt ->
//        let name = Path.GetFileNameWithoutExtension(data.ModelDoc2.GetTitle())
//        if StringComparer.OrdinalIgnoreCase.Equals("magnetic filter",name) then
//            let dn =
//                data.Component2.ReferencedConfiguration
//                |> parseDN
//            Some(MagneticFilter dn)
//        else
//            None
//    | ModelAssembly assy -> None
//    | _ -> failwith ""

//let tryWaferButterflyValve (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelSpecific.ModelPart prt ->
//        let name = Path.GetFileNameWithoutExtension(data.ModelDoc2.GetTitle())

//        if StringComparer.OrdinalIgnoreCase.Equals("wafer butterfly valve",name) then
//            let dn =
//                data.Component2.ReferencedConfiguration
//                |> parseDN
//            Some(WaferButterflyValve dn)
//        else
//            None
//    | ModelAssembly assy -> None
//    | _ -> failwith ""

//let tryWaferCheckValve (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelSpecific.ModelPart prt ->
//        let name = Path.GetFileNameWithoutExtension(data.ModelDoc2.GetTitle())

//        if StringComparer.OrdinalIgnoreCase.Equals("wafer check valve",name) then
//            let dn =
//                data.Component2.ReferencedConfiguration
//                |> parseDN
//            Some(WaferCheckValve dn)
//        else
//            None
//    | ModelAssembly assy -> None
//    | _ -> failwith ""

//let tryBallValveFlanges (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelAssembly assy ->
//        if StringComparer.OrdinalIgnoreCase.Equals("ball valve flanges A.SLDASM",data.ModelDoc2.GetTitle())
//            && isCompTypeOf "AssemblyFittings" data
//        then
//            let dn =
//                data.Component2.ReferencedConfiguration
//                |> parseDN
//            Some(BallValveFlanges(data,{ DN = dn }))
//        else
//            None
//    | ModelSpecific.ModelPart prt -> None
//    | _ -> failwith ""

//let tryBallValveSolo (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelAssembly assy ->
//        let name = Path.GetFileNameWithoutExtension(data.ModelDoc2.GetTitle())
//        if StringComparer.OrdinalIgnoreCase.Equals("ball valve solo A",name)
//            && isCompTypeOf "AssemblyFittings" data
//        then
//            let dn =
//                data.Component2.ReferencedConfiguration
//                |> parseDN
//            Some(BallValveSolo(data,{ DN = dn }))
//        else
//            None
//    | ModelSpecific.ModelPart prt -> None
//    | _ -> failwith ""

//let tryExpansionFlanges (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelAssembly assy ->
//        let name = Path.GetFileNameWithoutExtension(data.ModelDoc2.GetTitle())
//        if StringComparer.OrdinalIgnoreCase.Equals("expansion flanges A",name)
//            && isCompTypeOf "AssemblyFittings" data
//        then
//            let dn =
//                data.Component2.ReferencedConfiguration
//                |> parseDN
//            Some(BallValveSolo(data,{ DN = dn }))
//        else
//            None
//    | ModelSpecific.ModelPart prt -> None
//    | _ -> failwith ""

//let tryExpansionSolo (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelAssembly assy ->
//        let name = Path.GetFileNameWithoutExtension(data.ModelDoc2.GetTitle())
//        if StringComparer.OrdinalIgnoreCase.Equals("expansion solo A",name)
//            && isCompTypeOf "AssemblyFittings" data
//        then
//            let dn =
//                data.Component2.ReferencedConfiguration
//                |> parseDN
//            Some(ExpansionSolo(data,{ DN = dn }))
//        else
//            None
//    | ModelSpecific.ModelPart prt -> None
//    | _ -> failwith ""

//let tryFlanges (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelAssembly assy ->
//        if StringComparer.OrdinalIgnoreCase.Equals("flanges A.SLDASM",data.ModelDoc2.GetTitle())
//            && isCompTypeOf "AssemblyFittings" data
//        then
//            let dn =
//                data.Component2.ReferencedConfiguration
//                |> parseDN
//            Some(Flanges(data,{ DN = dn }))
//        else
//            None
//    | ModelSpecific.ModelPart prt -> None
//    | _ -> failwith ""

//let tryFlowmeterFlanges (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelAssembly assy ->
//        if StringComparer.OrdinalIgnoreCase.Equals("flowmeter flanges A.SLDASM",data.ModelDoc2.GetTitle())
//            && isCompTypeOf "AssemblyFittings" data
//        then
//            let dn =
//                data.Component2.ReferencedConfiguration
//                |> parseDN
//            Some(FlowmeterFlanges(data,{ DN = dn }))
//        else
//            None
//    | ModelSpecific.ModelPart prt -> None
//    | _ -> failwith ""

//let tryMagneticFilterFlanges (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelAssembly assy ->
//        let name = Path.GetFileNameWithoutExtension(data.ModelDoc2.GetTitle())
//        if "magnetic filter flanges A" == name
//            && isCompTypeOf "AssemblyFittings" data
//        then
//            let dn =
//                data.Component2.ReferencedConfiguration
//                |> parseDN
//            Some(MagneticFilterFlanges(data,{ DN = dn }))
//        else
//            None
//    | ModelSpecific.ModelPart prt -> None
//    | _ -> failwith ""

//let tryWaferButterflyValveFlanges (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelAssembly assy ->
//        let name = Path.GetFileNameWithoutExtension(data.ModelDoc2.GetTitle())
//        if "wafer butterfly valve flanges A" == name
//            && isCompTypeOf "AssemblyFittings" data
//        then
//            let dn =
//                data.Component2.ReferencedConfiguration
//                |> parseDN
//            Some(WaferButterflyValveFlanges(data,{ DN = dn }))
//        else
//            None
//    | ModelSpecific.ModelPart prt -> None
//    | _ -> failwith ""

//let tryWaferButterflyValveSolo (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelAssembly assy ->
//        let name = Path.GetFileNameWithoutExtension(data.ModelDoc2.GetTitle())
//        if "wafer butterfly valve solo A" == name
//            && isCompTypeOf "AssemblyFittings" data
//        then
//            let dn =
//                data.Component2.ReferencedConfiguration
//                |> parseDN
//            Some(WaferButterflyValveSolo(data,{ DN = dn }))
//        else
//            None
//    | ModelSpecific.ModelPart prt -> None
//    | _ -> failwith ""

//let tryWaferCheckValveFlanges (data:ComponentData) =
//    match data.SpecificModelDoc with
//    | ModelAssembly assy ->
//        let name = Path.GetFileNameWithoutExtension(data.ModelDoc2.GetTitle())
//        if "wafer check valve flanges A" == name
//            && isCompTypeOf "AssemblyFittings" data
//        then
//            let dn =
//                data.Component2.ReferencedConfiguration
//                |> parseDN
//            Some(WaferCheckValveFlanges(data,{ DN = dn }))
//        else
//            None
//    | ModelSpecific.ModelPart prt -> None
//    | _ -> failwith ""

//let fallback(data:ComponentData) =
//    GeneralComponent data
//    |> Some

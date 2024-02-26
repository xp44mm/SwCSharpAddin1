﻿module rec FSharp.SolidWorks.ValueParser

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
    data.Props.["Component Type"].stringText = compName

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
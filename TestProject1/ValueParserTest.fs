﻿namespace TestProject1

open Xunit
open Xunit.Abstractions
open FSharp.xUnit

open System.IO
open System.Text

open FSharp.Idioms
open FSharp.Idioms.Jsons
open FSharp.Idioms.Literal
open Tanks
open UnquotedJson

open System
open System.Collections
open System.Collections.Generic
open System.Diagnostics
open System.Drawing
open System.IO
open System.Reflection
open System.Runtime.InteropServices
open System.Text
open System.Text.RegularExpressions

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

open FSharp.Idioms
open FSharp.Idioms.Literal
open FSharp.SolidWorks

type ValueParserTest(output: ITestOutputHelper) =
    [<Fact>]
    member this.``01 - Pipe Identifier``() =        
        let x = "DN 50"
        let y = 
            //Double.Parse(Regex.Match(x,"^DN (\d+)$").Groups.[1].Value)
            ValueParser.parseDN x
        let e = 50.
        Should.equal e y

    [<Fact>]
    member this.``02 - Pipe Length``() =        
        let x = "85.75mm"
        let y = 
            //Double.Parse(Regex.Match(x,"^(\d+(\.\d+)?)mm$").Groups.[1].Value)
            ValueParser.parseLength x
        let e = 85.75
        Should.equal e y

    [<Fact>]
    member this.``03 - parseElbow``() =        
        let x = "90° DN 50"
        let ag,dn = 
            ValueParser.parseElbow x
        let eag = 90.
        let edn = 50.
        Should.equal eag ag
        Should.equal edn dn

    [<Fact>]
    member this.``04 - parseDNxDN``() =        
        let x = "DN 65 x 50"
        let dn1,dn2 = 
            ValueParser.parseDNxDN x
        let edn1 = 65.
        let edn2 = 50.
        Should.equal edn1 dn1
        Should.equal edn2 dn2

    [<Fact>]
    member this.``05 - path test``() =
        let x = @"D:\Application Data\SolidWorks\SW Design Library\routing\ASME\flanges A.SLDASM"
        let y = Path.GetExtension(x).[1..]
        output.WriteLine(y)
        Should.equal y "SLDASM"

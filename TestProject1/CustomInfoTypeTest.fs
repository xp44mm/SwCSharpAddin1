namespace TestProject1

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

type CustomInfoTypeTest(output: ITestOutputHelper) =
    [<Fact>]
    member this.``01 - getCore``() =
        let x = swCustomInfoType_e.swCustomInfoDate
        let y = CustomInfoType.getCore x
        let e = "Date"
        Should.equal e y

    [<Fact>]
    member this.``02 - parseCore``() =
        let x = "Date"
        let y = CustomInfoType.parseCore x
        let e = swCustomInfoType_e.swCustomInfoDate
        Should.equal e y

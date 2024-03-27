namespace TestProject1

open Xunit
open Xunit.Abstractions
open FSharp.xUnit

open System
open System.IO
open System.Text

open FSharp.Idioms
open FSharp.Idioms.Jsons
open FSharp.Idioms.Literal
open Tanks
open UnquotedJson
open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File
open SolidWorks.Interop.SWRoutingLib

type EnumTest(output : ITestOutputHelper) =
    let space (i:int) = String.replicate i " "

    let toggleCode typ name =
        [
            ""
            $"member _.{name}" |> (+) (space 4)
            "with get () =" |> (+) (space 8)
            $"rtSettings.GetRoutingUserPreferenceToggle(int {typ}.{name})" |> (+) (space 12)
            "and set v =" |> (+) (space 8)
            $"rtSettings.SetRoutingUserPreferenceToggle(int {typ}.{name},v)" |> (+) (space 12)
        ]

    let integerCode typ name =
        [
            ""
            $"member _.{name}" |> (+) (space 4)
            "with get () =" |> (+) (space 8)
            $"rtSettings.GetRoutingUserPreferenceIntegerValue(int {typ}.{name})" |> (+) (space 12)
            "and set v =" |> (+) (space 8)
            $"rtSettings.SetRoutingUserPreferenceIntegerValue(int {typ}.{name},v)" |> (+) (space 12)
            "|> ignore" |> (+) (space 12)
        ]

    let doubleCode typ name =
        [
            ""
            $"member _.{name}" |> (+) (space 4)
            "with get () =" |> (+) (space 8)
            $"rtSettings.GetRoutingUserPreferenceDoubleValue(int {typ}.{name})" |> (+) (space 12)
            "and set v =" |> (+) (space 8)
            $"rtSettings.SetRoutingUserPreferenceDoubleValue(int {typ}.{name},v)" |> (+) (space 12)
            "|> ignore" |> (+) (space 12)
        ]

    [<Fact>]
    member this.``01 - generate members``() =
        let outp1 = 
            Enum.GetNames(typeof<swUserPreferenceRoutingToggle_e>)
            |> Seq.map(toggleCode (nameof swUserPreferenceRoutingToggle_e))
            |> Seq.concat
            //|> String.concat "\n"

        let outp2 = 
            Enum.GetNames(typeof<swUserPreferenceRoutingInteger_e>)
            |> Seq.map(integerCode (nameof swUserPreferenceRoutingInteger_e))
            |> Seq.concat

        let outp3 = 
            Enum.GetNames(typeof<swUserPreferenceRoutingDouble_e>)
            |> Seq.map(doubleCode (nameof swUserPreferenceRoutingDouble_e))
            |> Seq.concat

        let outp =
            [outp1;outp2;outp3]
            |> Seq.concat
            |> String.concat "\n"

        output.WriteLine(outp)

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

type DocumentPropertiesCodeGenerator(output : ITestOutputHelper) =
    let space (i:int) = String.replicate i " "

    let code (a:string) (b:string) (name:string) =
        [
            ""
            $"member _.{name}" |> (+) (space 4)
            "with get (opt:swUserPreferenceOption_e) =" |> (+) (space 8)
            $"swModel.Extension.GetUserPreference{a}(int swUserPreference{b}_e.{name}, int opt)" |> (+) (space 12)
            "and set (opt:swUserPreferenceOption_e) value =" |> (+) (space 8)
            $"swModel.Extension.SetUserPreference{a}(int swUserPreference{b}_e.{name}, int opt, value)" |> (+) (space 12)
            "|> ignore" |> (+) (space 12)
        ]

    [<Fact>]
    member _.``01 - generate members``() =
        let lines =
            [
                typeof<swUserPreferenceDoubleValue_e>
                typeof<swUserPreferenceIntegerValue_e>
                typeof<swUserPreferenceStringValue_e>
                typeof<swUserPreferenceToggle_e>
            ]
            |> Seq.collect(fun typ ->
                let b = typ.Name.Replace("swUserPreference","").Replace("_e","")
                let a = b.Replace("Value","")
                Enum.GetNames(typ)
                |> Seq.map(fun name -> a, b, name)
            )
            |> Seq.collect(fun (a,b,name)->
                code a b name
            )

        let outp =
            lines
            |> String.concat "\n"

        output.WriteLine(outp)

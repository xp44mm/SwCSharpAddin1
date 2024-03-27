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

type SystemOptionsCodeGenerator(output : ITestOutputHelper) =
    let space (i:int) = String.replicate i " "

    let code (typ:Type) (a:string) (name:string) =
        let m = "swApp"
        [
            ""
            $"member _.{name}" |> (+) (space 4)
            "with get () =" |> (+) (space 8)
            $"{m}.Get{a}(int {typ.Name}.{name})" |> (+) (space 12)
            "and set v =" |> (+) (space 8)
            $"{m}.Set{a}(int {typ.Name}.{name},v)" |> (+) (space 12)
            if a = "UserPreferenceToggle" then
                ()
            else 
                "|> ignore" |> (+) (space 12)
        ]

    [<Fact>]
    member this.``01 - generate members``() =
        let lines =
            [
                typeof<swUserPreferenceDoubleValue_e> , "UserPreferenceDoubleValue"
                typeof<swUserPreferenceIntegerValue_e>, "UserPreferenceIntegerValue"
                typeof<swUserPreferenceStringValue_e> , "UserPreferenceStringValue"
                typeof<swUserPreferenceToggle_e>      , "UserPreferenceToggle"
            ]
            |> Seq.collect(fun (typ, a) ->
                Enum.GetNames(typ)
                |> Seq.map(fun name -> typ, a, name)
            )
            |> Seq.collect(fun (typ,a,name)->
                code typ a name
            )

        let outp =
            lines
            |> String.concat "\n"

        output.WriteLine(outp)

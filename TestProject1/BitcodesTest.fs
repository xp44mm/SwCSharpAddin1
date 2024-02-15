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

type BitcodesTest(output : ITestOutputHelper) =
    let path = Path.Combine(Dir.CommandData,"bitcodes.tsv")

    [<Fact(
    Skip="这是写文件测试"
    )>]
    member this.``01 - write to json file``() =
        let text =
            [
                "Top Plane", -300
                "Top Plane", 300
                "Front Plane", -300
                "Front Plane", 300
                "Right Plane", -300
                "Right Plane", 300
            ]
            |> Seq.map(fun(p,d)-> $"{p}\t{d}")
            |> String.concat "\n"
        File.WriteAllText(path, text)

    [<Fact>]
    member this.``02 - read from tsv file``() =
        //let path = Path.Combine(Dir.CommandData,"tanks.js")
        let text = File.ReadAllText(path)

        let tbl = Tsv.parseText text
        let ls =
            tbl
            |> Array.map(fun arr ->
                let bitcode = arr.[0]
                let file = if arr.Length > 1 then arr.[1] else ""
                let config = if arr.Length > 2 then arr.[2] else ""
                bitcode,file,config
            )
            |> Array.toList
        output.WriteLine(stringify ls)

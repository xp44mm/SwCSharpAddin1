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

type PlaneTest(output : ITestOutputHelper) =
    let path = Path.Combine(Dir.CommandData,"planes.tsv")

    [<Fact>]
    member this.``00 - Path test``() =
        let y = Path.Combine(Dir.CommandData,"planes.tsv")
        //output.WriteLine(stringify y)
        Should.equal y @"D:\Application Data\GitHub\xp44mm\SwCSharpAddin1\CommandData\planes.tsv"

    [<Fact(
    Skip="这是写文件测试"
    )>]
    member this.``01 - write to Tanks json file test``() =
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

    //[<Fact>]
    //member this.``02 - read from Tanks json file test``() =
    //    let arr = Asia.tsvPlanes()
    //    output.WriteLine(stringify arr)


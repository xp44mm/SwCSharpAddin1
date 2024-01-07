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

type TankTest(output : ITestOutputHelper) =
    let path = Path.Combine(Dir.CommandData,"tanks.js")

    [<Fact>]
    member this.``00 - Path test``() =
        let y = Path.Combine(Dir.CommandData,"tanks.js")
        output.WriteLine(stringify y)
        Should.equal y @"D:\Application Data\GitHub\xp44mm\SwCSharpAddin1\CommandData\tanks.js"

    [<Fact>]
    member this.``01 - read from Tanks json file test``() =
        let text = File.ReadAllText(path)
        let json = Json.parse text
        let ls =
            match json with
            | Json.Array ls ->
                ls
                |> List.map Tank.from
            | _ -> failwith "schema mismatch"
        output.WriteLine(stringify ls)


    [<Fact(
    Skip="这是写文件测试"
    )>]
    member this.``02 - write to Tanks json file test``() =
        let x = [
            {
            bitcode="V0101A"; 直径 = 4200; 高度 = 7300
            }
        ]
        let y = 
            x
            |> List.map(fun t -> t.toJson())
            |> Json.Array
        let z = Json.stringify y
        output.WriteLine(z)
        File.WriteAllText(path,z)

    [<Fact>]
    member this.``03 - loadData test``() =
        let tanks1,tanks2 = Asia.loadData()
        output.WriteLine(stringify tanks1)        
        output.WriteLine(stringify tanks2)

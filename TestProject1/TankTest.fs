namespace TestProject1

open Xunit
open Xunit.Abstractions
open FSharp.xUnit

open System.IO
open System.Text.RegularExpressions


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
        let z = Json.print y
        output.WriteLine(z)
        File.WriteAllText(path,z)

    //[<Fact>]
    //member this.``03 - loadData test``() =
    //    let tanks1,tanks2 = Asia.loadData()
    //    output.WriteLine(stringify tanks1)
    //    output.WriteLine(stringify tanks2)

    [<Fact>]
    member this.``04 - DN PN test``() =
        let x = "DN 100 PN 10"
        let rgx = Regex(@"^DN (\d+) PN (\d+(\.\d+)?)$")
        let gs = rgx.Match(x).Groups
        let dn = gs.[1].Value
        let pn = gs.[2].Value

        Should.equal dn "100"
        Should.equal pn "10"

    [<Fact>]
    member this.``05 - Path GetDirectoryName test``() =
        let x = @"D:\Application Data\GitHub\xp44mm\SwCSharpAddin1\CommandData\tanks.js"
        let y = Path.GetDirectoryName(x)
        output.WriteLine(y)
        Should.equal y @"D:\Application Data\GitHub\xp44mm\SwCSharpAddin1\CommandData"

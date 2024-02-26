namespace FlangeAssemblyBOM

open Xunit
open Xunit.Abstractions
open FSharp.Idioms.Literal
open FSharp.xUnit

type DirTest(output : ITestOutputHelper) =
    let show res = 
        res 
        |> stringify
        |> output.WriteLine

    [<Fact>]
    member this.``01 - first test``() =
        output.WriteLine("testPath:")
        output.WriteLine(Dir.thisPath)

        output.WriteLine("solutionPath:")
        output.WriteLine(Dir.solutionPath)
        //Should.equal y res


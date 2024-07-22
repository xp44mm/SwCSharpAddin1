namespace FSharp.SolidWorks

open Xunit
open Xunit.Abstractions
open FSharp.xUnit

open System
open System.IO
open System.Text

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorks.Interop.SWRoutingLib

open SolidWorksTools
open SolidWorksTools.File

open FSharp.Idioms
open FSharp.Idioms.Jsons
open FSharp.Idioms.Literal
open UnquotedJson

type ComponentArchiveJsonTest (output: ITestOutputHelper) =

    [<Fact>]
    member _.``01 - propsToJson test``() =
        let props =
            Map [
                "pn",("Double","1.0")
                "count",("Number","3")
                "fasteners",("YesOrNo","Yes")
                "material",("Text","PPH")
            ]
        let y = props |> ComponentArchiveJson.propsToJson
        output.WriteLine(stringify y)
        let e = Json.Object [
            "count",Json.Number 3.0;
            "fasteners",Json.True;
            "material",Json.String "PPH";
            "pn",Json.Number 1.0
            ]
        Should.equal e y

    [<Fact>]
    member _.``02-1 - commentToJson test``() =        
        let comment = "{pn:1.6}"
        let y = comment |> ComponentArchiveJson.commentToJson
        output.WriteLine(stringify y)
        let e = Json.Object [
            "pn",Json.Number 1.6
            ]
        Should.equal e y

    [<Fact>]
    member _.``02-2 - commentToJson test``() =        
        let comment = "ignore other content."
        let y = comment |> ComponentArchiveJson.commentToJson
        output.WriteLine(stringify y)
        let e = Json.Object [
            //"pn",Json.Number 1.6
            ]
        Should.equal e y

    [<Fact>]
    member _.``03-1 - specificToJson test``() =
        let x = ComponentArchivePart
        let y = x |> ComponentArchiveJson.specificToJson (fun _ -> Json.Null)
        output.WriteLine(stringify y)
        let e = ["kind",Json.String "Part"]
        Should.equal e y

    [<Fact>]
    member _.``03-2 - specificToJson test``() =
        let x = ComponentArchiveAssembly []
        let y = x |> ComponentArchiveJson.specificToJson (fun _ -> Json.Null)
        output.WriteLine(stringify y)
        let e = [
            "kind",Json.String "Assembly";
            "children",Json.Array []
            ]
        Should.equal e y

    [<Fact>]
    member _.``03-3 - specificToJson test``() =
        let x = ComponentArchiveRouteAssembly []
        let y = x |> ComponentArchiveJson.specificToJson (fun _ -> Json.Null)
        output.WriteLine(stringify y)
        let e = [
            "kind",Json.String "RouteAssembly";
            "children",Json.Array []
            ]
        Should.equal e y

    [<Fact>]
    member _.``04-01 - tryComponentArchive test``() =
        let x = {
            id = 0
            title = ""
            refconfig = ""
            refid = ""
            isVirtual = false
            props = Map []
            comment = ""
            specific = ComponentArchiveRouteAssembly []
        }

        let y = x |> ComponentArchiveJson.from
        output.WriteLine(stringify y)
        let e = Json.Object [
            "title",Json.String "";
            "refconfig",Json.String "";
            "refid",Json.String "";
            "isVirtual",Json.False;
            "props",Json.Object [];
            "kind",Json.String "RouteAssembly";
            "children",Json.Array []
            ]

        Should.equal e y


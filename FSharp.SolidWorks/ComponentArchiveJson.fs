module FSharp.SolidWorks.ComponentArchiveJson

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO
open System.Text.RegularExpressions

open FSharp.Idioms
open FSharp.Idioms.Jsons

open FSharp.Idioms.Literal
open FSharp.Reflection
open FSharp.Idioms.Reflection
open UnquotedJson

let propsToJson (props:Map<string,string*string>) =
    props
    |> Map.toList
    |> List.map(fun (nm,(typ,value)) ->
        let fv =
            match typ with
            | "Number"
            | "Double" 
                -> Json.parse value
            | "YesOrNo" -> 
                StringComparer.OrdinalIgnoreCase.Equals(value, "Yes")
                |> Json.boolean
            | "Text"
            | _ -> Json.String value
        nm,fv
    )
    |> Json.Object

let commentToJson (comment:string) =
    let rgx = Regex(@"^\s*\{[\s\S]*\}\s*$")
    if rgx.IsMatch(comment) then
        Json.parse comment
    else Json.Object []

let specificToJson (loop) (cas:ComponentArchiveSpecific) =
    let getChildren (children:list<ComponentArchive>) =
        children
        |> List.map loop
        |> Json.Array

    match cas with
    | ComponentArchivePart ->
        [
            "kind", Json.String "Part"
        ]
    | ComponentArchiveAssembly children ->
        [
            "kind", Json.String "Assembly"
            "children", getChildren children
        ]
    | ComponentArchiveRouteAssembly children -> 
        [
            "kind", Json.String "RouteAssembly"
            "children", getChildren children
        ]

let tryComponentArchive = fun (ty:Type) ->
    if ty = typeof<ComponentArchive> then
        Some(fun (loop:Type -> obj -> Json) (value:obj) ->
            let ca = value :?> ComponentArchive
            let props =
                ca.props
                |> propsToJson
                |> fun props -> props.assign(commentToJson ca.comment)
            
            Json.Object [
                //id: int
                "title"    , Json.String ca.title
                "refconfig", Json.String ca.refconfig
                "refid"    , Json.String ca.refid
                "isVirtual", Json.boolean ca.isVirtual
                "props"    , props
                //"comments", commentToJson ca.comment
                yield! specificToJson (loop typeof<ComponentArchive>) ca.specific
            ]
        )
    else None

/// fromObj: obj -> Json 
let fromObj: Type -> obj -> Json = JsonReaderApp.mainRead (tryComponentArchive :: JsonReaderApp.readers)

/// from: 't -> Json
let from<'t> (value:'t) = fromObj typeof<'t> value


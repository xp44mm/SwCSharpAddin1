module rec FSharp.SolidWorks.RoutePropUtils

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO
open System.Text.RegularExpressions

open FSharp.Idioms.Jsons

open FSharp.Idioms.Literal
open FSharp.Reflection

let getComponentTypes (title: string) =
    set [title]

//从父元素继承可以继承的属性，丢弃不可继承的属性


//继承所有父元素的散列属性
//子元素的id，父元素有子元素的id则继承下来，并把其字段变成散列属性。

// 继承属性[]
let isProp (propName:string) =
    Regex.IsMatch(propName,@"^\[.*\]$")

// 直接子元素{id}
let isId (propName:string) =
    Regex.IsMatch(propName,@"^\{.*\}$")

// 后代元素<type>
let isTag (propName:string) =
    Regex.IsMatch(propName,@"^<.*>$")

let getName (propName:string) = propName.[1..propName.Length-2]

let bisectProps (props: Map<string,Json>) (id:string) =
    let mid,mother =
        props
        |> Map.partition(fun name _ -> isId name)
    let spreadid =
        if mid.ContainsKey id then // id带{}
            match mid.[id] with
            | Json.Object fields -> Map fields
            | _ -> failwith ""
        else Map.empty
    spreadid, mother

let computeCss (parents: ComponentEasy list) field =

    //通用查找法
    let rec loop (parents: ComponentEasy list) =
        match parents with
        | [] -> None
        | self::tail ->
            if self.props.ContainsKey field then
                Some self.props.[field]
            else
                loop tail
    ()

let capture (route) (fitting) (id:string) =
    //找到id字段，丢弃其他id字段，只留下本id字段
    //id中的属性应该与type中的属性不冲突。
    ()


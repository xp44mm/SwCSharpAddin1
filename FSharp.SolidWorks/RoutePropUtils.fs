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



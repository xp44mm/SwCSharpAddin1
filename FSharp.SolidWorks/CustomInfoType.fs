module FSharp.SolidWorks.CustomInfoType

open System
open System.Text.RegularExpressions

open SolidWorks.Interop.swconst

///获得枚举值的短名称
let getCore (e: swCustomInfoType_e) =
    let x = e.ToString()
    Regex("swCustomInfo(\w+)$").Match(x).Groups.[1].Value

///解析短名称返回枚举值
let parseCore (corestring: string) =
    Enum.Parse(typeof<swCustomInfoType_e>,"swCustomInfo" + corestring)
    :?> swCustomInfoType_e

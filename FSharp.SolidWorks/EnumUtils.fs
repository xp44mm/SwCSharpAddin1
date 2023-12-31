﻿module FSharp.SolidWorks.EnumUtils

open System
open System.Runtime.InteropServices
open System.Collections
open System.Reflection
open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File
open System.Collections.Generic
open System.Diagnostics

/// 名称去掉版本号，始终用最新版的版本号
/// 枚举型替代整型输入
/// 枚举型转化为可区分联合
/// 返回元组或记录代替输出参数
/// 丢弃布尔型返回值，其代表执行的成功与否，始终认为是执行成功的。
/// 检测文本常量，是否typo.

let enumString (enums:string seq)(input:string) =
    let es = HashSet<string>(StringComparer.OrdinalIgnoreCase)
    for e in enums do 
        es.Add e |> ignore
    
    es.IntersectWith [input]
    try Seq.exactlyOne es with
    | _ -> raise(ArgumentOutOfRangeException($"{es},{input}"))

let selecttype (selecttype:string) =
    [
        "ADVSTRUCTMEMBER"
        "ANNOTATIONTABLES"
        "ANNVIEW"
        "ATTRIBUTE"
        "AXIS"
        "BDYFOLDER"
        "BLOCKDEF"
        "BODYFEATURE"
        "BOM"
        "BOMFEATURE"
        "BOMTEMP"
        "BREAKLINE"
        "BROWSERITEM"
        "CAMERAS"
        "CENTERLINE"
        "CENTERMARKS"
        "CENTERMARKSYMS"
        "COMMENT"
        "COMMENTSFOLDER"
        "COMPONENT"
        "COMPPATTERN"
        "CONFIGURATIONS"
        "CONNECTIONPOINT"
        "COORDSYS"
        "COSMETICWELDS"
        "CTHREAD"
        "DATUMPOINT"
        "DATUMTAG"
        "DCABINET"
        "DETAILCIRCLE"
        "DIMENSION"
        "DOCSFOLDER"
        "DOWLELSYM"
        "DRAWINGVIEW"
        "DTMTARG"
        "EDGE"
        "EMBEDLINKDOC"
        "EQNFOLDER"
        "EVERYTHING"
        "EXPLODEDVIEWS"
        "EXPLODELINES"
        "EXPLODESTEPS"
        "EXTSKETCHPOINT"
        "EXTSKETCHSEGMENT"
        "EXTSKETCHTEXT"
        "FACE"
        "FRAMEPOINT"
        "FTRFOLDER"
        "GENERALTABLEFEAT"
        "GTOL"
        "HELIX"
        "HOLESERIES"
        "HOLETABLE"
        "HOLETABLEAXIS"
        "HYPERLINK"
        "IMPORTFOLDER"
        "INCONTEXTFEAT"
        "INCONTEXTFEATS"
        "JOURNAL"
        "LEADER"
        "LIGHTS"
        "LOCATIONS"
        "MAGNETICLINES"
        "MANIPULATOR"
        "MATE" 
        "MATEGROUP"
        "MATEGROUPS"
        "MATESUPPLEMENT"
        "MESH BODY FEATURE"
        "MESHFACETREF"
        "MESHFINREF"
        "MESHVERTEXREF"
        "MSOLIDBODY"
        "NOTE"
        "OBJGROUP" 
        "OLEITEM"
        "PICTURE BODY"
        "PLANE"
        "POINTREF"
        "POSGROUP"
        "PUNCHTABLE"
        "REFCURVE"
        "REFERENCE-EDGE"
        "REFERENCECURVES"
        "REFLINE"
        "REFSURFACE"
        "REVISIONTABLE"
        "REVISIONTABLEFEAT"
        "ROUTEFABRICATED"
        "ROUTEPOINT"
        "SECTIONLINE"
        "SECTIONTEXT"
        "SELECTIONSETFOLDER"
        "SFSYMBOL"
        "SHEET"
        "SILHOUETTE"
        "SIMULATION"
        "SIMULATION_ELEMENT"
        "SKETCH"
        "SKETCHBELT"
        "SKETCHBITMAP"
        "SKETCHCONTOUR"
        "SKETCHHATCH"
        "SKETCHPOINT"
        "SKETCHPOINTFEAT"
        "SKETCHREGION"
        "SKETCHSEGMENT"
        "SKETCHTEXT"
        "SOLIDBODY"
        "SUBSELECTIONSETNODE"
        "SUBSKETCHDEF"
        "SUBSKETCHINST"
        "SUBWELDMENT"
        "SURFACEBODY"
        "SWIFTANN"
        "SWIFTFEATURE"
        "SWIFTSCHEMA"
        "TITLEBLOCK"
        "TITLEBLOCKTABLEFEAT"
        "UNSUPPORTED"
        "VERTEX"
        "VIEWARROW"
        "VISUALSTATE"
        "WELD"
        "WELDBEADS"
        "WELDMENT"
        "WELDMENTTABLE"
        "ZONES"
    ]
    |> enumString <| selecttype


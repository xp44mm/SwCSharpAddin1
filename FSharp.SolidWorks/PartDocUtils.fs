module FSharp.SolidWorks.PartDocUtils

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

let getMaterialPropertyName2 configName (swPart:IPartDoc) =
    let m,db = swPart.GetMaterialPropertyName2(configName)
    m,db

let setMaterialPropertyName2 configName db (mat:string) (swPart:IPartDoc) =
    /// 设置零件，当前配置，当前材料数据库
    swPart.SetMaterialPropertyName2(configName, db, mat)

let mirrorPart2 
    (breakLink : bool)
    (options : swMirrorPartOptions_e)
    (swPart:IPartDoc) =
    let value, resultPart =
        swPart.MirrorPart2(breakLink, int options)
    value, resultPart

let getBodies2 (typ:swBodyType_e)(visibleOnly:bool)(swPart:IPartDoc) = 
    swPart.GetBodies2(int typ, visibleOnly)
    :?> obj[]
    |> Array.map(fun obj -> obj :?> Body2)

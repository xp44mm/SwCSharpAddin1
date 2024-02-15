module CustomPropsConfig1

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open SolidWorks.Interop.SWRoutingLib

open System
open System.Diagnostics
open System.IO
open FSharp.SolidWorks

let PrintProperties (custPrpMgr:CustomPropertyManager) (useCached:bool) (indent:string) =
    let logfile = "d:/PrintProperties.txt"
    if File.Exists(logfile) then File.Delete logfile

    let writefile s = File.AppendAllText(logfile,s+"\n")

    let vPrpNames =
        custPrpMgr.GetNames()
        :?> obj[]
        |> Array.map(fun o -> o :?> string)

    match vPrpNames with
    | [||] ->
        writefile $"{indent}-No Properties-"
    | _ ->
        for prpName in vPrpNames do
            let value,resvalue =  CustomPropertyManagerUtils.GetUpdatedProperty prpName custPrpMgr
            writefile $"{indent}Property: {prpName}"
            writefile $"{indent}Value/Text Expression: {value}"
            writefile $"{indent}Evaluated Value: {resvalue}"
            //writefile $"{indent}Was Resolved: {retval.wasResolved}"
            //writefile $"{indent}Is Linked: {retval.linkToProperty}"
            //writefile $"{indent}Status: {retval.customInfoGetResult}"
            //writefile $""

let PrintPropertiesAtConfigurationSpecific (model:ModelDoc2) (cached:bool) (confName) =
    let swCustPrpMgr = model.Extension.CustomPropertyManager(confName)
    PrintProperties swCustPrpMgr cached "        "

let PrintConfigurationSpecificProperties(model:ModelDoc2) (cached:bool) =
    let vNames =
        model.GetConfigurationNames()
        :?> string[]

    for confName in vNames do
        let swCustPrpMgr = model.Extension.CustomPropertyManager(confName)
        PrintProperties swCustPrpMgr cached "        "


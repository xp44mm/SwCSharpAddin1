module CustomPropsConfig1

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open SolidWorks.Interop.SWRoutingLib

open System
open System.Diagnostics
open System.IO

let PrintProperties (custPrpMgr:CustomPropertyManager) (cached:bool) (indent:string) =
    let logfile = "d:/PrintProperties.txt"
    if File.Exists(logfile) then File.Delete logfile

    let writefile s = File.AppendAllText(logfile,s+"\n")

    let vPrpNames = 
        custPrpMgr.GetNames()
        |> unbox<string[]>

    match vPrpNames with
    | [||] -> 
        writefile $"{indent}-No Properties-"
    | _ ->
        for prpName in vPrpNames do
            let mutable prpVal = ""
            let mutable prpResVal = ""
            let mutable wasResolved = false
            let mutable isLinked = false
            let res = custPrpMgr.Get6(prpName, cached, &prpVal, &prpResVal, &wasResolved, &isLinked)
            
            let status =
                match enum<swCustomInfoGetResult_e> res with
                | swCustomInfoGetResult_e.swCustomInfoGetResult_CachedValue ->
                    "Cached Value"
                | swCustomInfoGetResult_e.swCustomInfoGetResult_ResolvedValue ->
                    "Resolved Value"
                | swCustomInfoGetResult_e.swCustomInfoGetResult_NotPresent ->
                    "Not Present"
                | _ -> failwith "never"

            writefile $"{indent}Property: {prpName}"
            writefile $"{indent}Value/Text Expression: {prpVal}"
            writefile $"{indent}Evaluated Value: {prpResVal}"
            writefile $"{indent}Was Resolved: {wasResolved}" 
            writefile $"{indent}Is Linked: {isLinked}" 
            writefile $"{indent}Status: {status}"
            writefile $""
            

let PrintPropertiesAtConfigurationSpecific (model :ModelDoc2) (cached : bool) (confName) =
    let swCustPrpMgr = model.Extension.CustomPropertyManager(confName)
    PrintProperties swCustPrpMgr cached "        "

let PrintConfigurationSpecificProperties(model :ModelDoc2) (cached : bool) =
    let vNames = 
        model.GetConfigurationNames()
        |> unbox<string[]>              
    
    for confName in vNames do
        let swCustPrpMgr = model.Extension.CustomPropertyManager(confName)
        PrintProperties swCustPrpMgr cached "        "
        

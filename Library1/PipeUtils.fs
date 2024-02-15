module rec PipeComponents.PipeUtils

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst

open System
open System.Diagnostics
open System.IO
open System.Text.RegularExpressions

open FSharp.SolidWorks
open FSharp.Idioms.Literal

///获取管道长度，用于材料清单
let getPipeInfo (swComp:Component2) (swModel: ModelDoc2) =
    let prpName = "SWPipeLength"
    let swCustPrpMgr = swModel.Extension.CustomPropertyManager(swComp.ReferencedConfiguration)
    if CustomPropertyManagerUtils.contains prpName swCustPrpMgr then
        //属性值带单位
        let _,pipeLength = CustomPropertyManagerUtils.GetUpdatedProperty prpName swCustPrpMgr
        // 100mm -> 100
        let len = Double.Parse(Regex.Match(pipeLength,@"^([\d\.]+)mm$").Groups.[1].Value)
        DataPipe len
    else
        DataGenericPart

//// this recursively traverses all of the components in an
//// assembly and prints their name to the immediate window
//let rec traverseComponent (swRootComp:Component2) (swRootModel:ModelDoc2) =
//    match ModelSpecific.from swRootModel with
//    | ModelDrawing _ -> failwith "never"
//    | ModelPart prt -> failwith ""
//    | ModelAssembly assy ->
//        if assy.IsRouteAssembly() then
//            traverseRouteAssemblyComponent swRootComp swRootModel
//        else
//            swRootComp.GetChildren()
//            :?> obj[]
//            |> Array.map(fun o -> o :?> Component2)
//            |> Array.map(fun swComp -> 
//                let modelDoc = swComp.GetModelDoc2() :?> ModelDoc2
//                traverseComponent swComp modelDoc
//            )

//let rec traverseRouteAssemblyComponent (swRootComp:Component2) (swRootModel:ModelDoc2) =
//    match ModelSpecific.from swRootModel with
//    | ModelDrawing _ -> failwith "never"
//    | ModelPart prt -> failwith "管道零件"
//    | ModelAssembly assy ->
//        swRootComp.GetChildren()
//        :?> obj[]
//        |> Array.map(fun o -> o :?> Component2)
//        |> Array.map(fun swComp -> 
//            let modelDoc = swComp.GetModelDoc2() :?> ModelDoc2
//            traverseRouteAssemblyComponent swComp modelDoc
//        )



//    let rec loop (node:ComponentNode) =
//        let specificData =
//            match node.specific with
//            | SpecificPart part ->
//                getPipeInfo node.Component2 node.ModelDoc2
//            | SpecificAssembly(assemDoc,children) ->
//                let children =
//                    children
//                    |> Array.map(fun child -> loop child)

//                if assemDoc.IsRouteAssembly() then
//                    DataRouteAssembly children
//                else 
//                    DataGenericAssembly children
//        {
//            name = node.Component2.Name2
//            ReferencedConfiguration = node.Component2.ReferencedConfiguration
//            ComponentReference = node.Component2.ComponentReference
//            SpecificData = specificData
//        }

//    //根组件要手动展开,因为根组件的引用的模型文件为空，文件就是模型自己。
//    swRootComp.GetChildren()
//    :?> obj[]
//    |> Array.map(fun o -> o :?> Component2)
//    |> Array.map(fun cmp -> 
//        cmp
//        |> ComponentNode.from
//        |> loop
//    )

// Macro Entry point
let main (swApp: ISldWorks) =
    let swRootModel = 
        swApp.ActiveDoc :?> ModelDoc2

    //let swRootAssy = swRootModel :?> AssemblyDoc

    // Get it's root component
    let swRootComp = swRootModel.ConfigurationManager.ActiveConfiguration.GetRootComponent3(true)

    let rootLine =
        [
            Path.GetFileNameWithoutExtension(swRootModel.GetTitle())
            "("
            swRootModel.ConfigurationManager.ActiveConfiguration.Name
            ")"
        ]
        |> String.concat ""

    let outp = 
        [
            rootLine
            yield!
                swRootComp.GetChildren()
                :?> obj[]
                |> Array.map(fun o -> o :?> Component2)
                |> Array.map(fun swComp -> 
                    let modelDoc = swComp.GetModelDoc2() :?> ModelDoc2
                    GeneralComponentClosure.from swComp modelDoc (-1)
                )
                |> Array.collect(fun cl ->
                    cl.getlines()
                    |> Array.map((+)"   ")
                )
        ]
        |> String.concat "\n"

    let path = Path.Combine(Dir.CommandData,"pipebom.txt")
    File.WriteAllText(path,outp)
    swApp.SendMsgToUser path



namespace Library1

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

open System.IO
open FSharp.SolidWorks

type 批量修改零件材质(swApp: ISldWorks) =
    let currentDir = "D:/崔胜利/凯帝隆/湖北武穴锂宝/solidworks/"
    let matDB = "C:/ProgramData/SolidWorks/SOLIDWORKS 2022/自定义材料/凯帝隆.sldmat"
    let logfile = "d:/partmat.txt"

    let ChangeMaterialOfPart (filename: string) (matname: string) =
        let path = Path.Combine( currentDir, filename + ".SLDPRT")

        let swModel =
            swApp
            |> SldWorksUtils.openDoc6 path swDocumentTypes_e.swDocPART swOpenDocOptions_e.swOpenDocOptions_Silent ""

        // 修改所有配置的材质
        let vConfNameArr =
            swModel
            |> ModelDoc2Utils.getConfigurationNames

        let swPart = swModel :?> PartDoc

        for configName in vConfNameArr do
            swPart.SetMaterialPropertyName2(configName, matDB, matname)

        swModel
        |> ModelDoc2Utils.save3 swSaveAsOptions_e.swSaveAsOptions_Silent

        // 打印所有配置的材质
        for configName:string in vConfNameArr do
            let sMatName =
                swPart
                |> PartDocUtils.getMaterialPropertyName2 configName
                |> fst
            let title = swModel.GetTitle()
            let s = $"{title}({configName}){sMatName}\n"
            File.AppendAllText(logfile,s)

        // Close Document
        swModel.GetPathName()
        |> swApp.CloseDoc

    member this.execute() =
        let filenames = [
            "p0701ab-v0701&m0202a&m0202b&m0205"
            "p0702ab-v0701&m0318"
            "p0703ab-v0702&m0302&m0304&m0306&m0308&m0312&m0402&m0404&m0406&m0410&m0417&m0419"
            "p0901-r0201ab&r0202ab&v0308&e0301&e0501&r0410&r0501&r0502&r0503&v0701&v0702&v0801&v0802&v0803&p0323&p0324&m0421"
            "v0701-p0701ab"
            "v0701-p0702ab"
            "v0702-p0703ab"
            ]

        for filename in filenames do
            ChangeMaterialOfPart filename "304"





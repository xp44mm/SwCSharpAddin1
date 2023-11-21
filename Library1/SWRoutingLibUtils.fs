module SWRoutingLibUtils

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swconst
open SolidWorks.Interop.SWRoutingLib

open System
open System.Diagnostics

//SWPipeLength

let getRouteManager (swApp:ISldWorks) =
    let swModel =
        swApp.ActiveDoc
        :?> ModelDoc2

    let swTopLevelAssembly =
        swModel
        :?> AssemblyDoc

    // Get the RouteManager from the top-level assembly
    let rtRouteManager =
        swTopLevelAssembly.GetRouteManager()
        :?> RouteManager

    rtRouteManager

let ExportPipeData (swApp:ISldWorks) =
    let swModel =
        swApp.ActiveDoc
        :?> ModelDoc2

    let swTopLevelAssembly =
        swModel
        :?> AssemblyDoc

    // Get the RouteManager from the top-level assembly
    let rtRouteManager =
        swTopLevelAssembly.GetRouteManager()
        :?> RouteManager


    rtRouteManager.EditRoute()
    let count = rtRouteManager.GetAllRouteSegmentCount()
    swApp.SendMsgToUser $"{count}"

    let count = rtRouteManager.GetAdvancedRouteSelector()
    swApp.SendMsgToUser $"{count}"

    let ids = rtRouteManager.GetAllRouteSegmentIDs() :?> int[]
    swApp.SendMsgToUser (sprintf "%A" ids)

    //let count = rtRouteManager.GetRoutingComponentFromSearchpath("")
    //swApp.SendMsgToUser $"{count}"

    //let count = rtRouteManager.GetRoutingLibComponentReferences("")
    //swApp.SendMsgToUser $"{count}"


    //let autoRoute = rtRouteManager.GetAutoRoute()
    //autoRoute.ShowGuidelines()
    //|> ignore

    //boolstatus = swModel.Extension.SelectByID2("Point3", "SKETCHPOINT", -0.457835, 0.10795, -0.2032, true, 0, null, 0)
    //boolstatus = swModel.Extension.SelectByID2("Point8", "SKETCHPOINT", -0.218948, 0.0508, -0.470281, true, 0, null, 0)
    //resultCode = autoRoute.CreatePointToPointAutoRoute(2)

    rtRouteManager.ExitRoute()

    swTopLevelAssembly.EditAssembly()


    //let prop = rtRouteManager.GetRouteProperty()
    //swApp.SendMsgToUser $"{prop.BendRadius}"
    //()


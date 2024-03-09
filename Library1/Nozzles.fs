namespace Nozzles

open FSharp.Idioms
open FSharp.Idioms.Jsons
open System

//水平管嘴：侧壁，水平，向心，垂直箱壁elev,angle
//斜坡管嘴：侧壁，向心，斜坡 elev,angle,slope
//偏移管嘴：侧壁，偏心，斜坡 elev,angle,slope,offset
//斜坡elev：轴线与外壁交点的elev
//斜坡，偏移伸出长度：端点在侧壁向外偏出伸出长度的虚拟柱面上。

type NozzleLocation = 
    | WallNozzle of
        elevation:float *
        angle:float *
        slope:float *
        offset:float
    | RoofNozzle of // 箱顶管嘴：xyal
        x:float *
        y:float *
        angle:float *
        radius:float

    member this.toJson() = 
        match this with
        | WallNozzle (elevation,angle,slope,offset) ->
            Json.Object [
            "elevation",Json.Number elevation
            "angle",Json.Number angle
            "slope",Json.Number slope
            "offset",Json.Number offset
            ]
        | RoofNozzle (x,y,angle,radius) ->
            Json.Object [
                "x",Json.Number x
                "y",Json.Number y
                "angle",Json.Number angle
                "radius",Json.Number radius
            ]

    static member from (json:Json) = 
        match json with
        | Json.Object _ ->
            if json.hasProperty "elevation" then
                WallNozzle(json.["elevation"].floatValue,json.["angle"].floatValue,json.["slope"].floatValue,json.["offset"].floatValue)
            else
                RoofNozzle(json.["x"].floatValue,json.["y"].floatValue,json.["angle"].floatValue,json.["radius"].floatValue)
        | _ -> failwith ""

type Nozzle = 
    {
        code:string
        PN:float
        DN:float
        location:NozzleLocation
    }
    member this.toJson() = 
        Json.Object [
            "code",Json.String this.code
            "PN",Json.Number this.PN
            "DN",Json.Number this.DN
            yield! this.location.toJson().getEntries()
        ]

    static member from (json:Json) = 
        match json with
        | Json.Object _ ->
            let code = json.["code"].stringText
            let PN = json.["PN"].floatValue
            let DN = json.["DN"].floatValue
            let location = NozzleLocation.from json
            {
                code = code
                PN = PN
                DN = DN
                location = location 
            }
        | _ -> failwith ""



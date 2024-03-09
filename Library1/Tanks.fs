namespace Tanks

open FSharp.Idioms
open FSharp.Idioms.Jsons
open System

type TankP =
    {
        bitcode:string
        直径:float
        高度:float
    }

    member this.toJson() =
        Json.Object [
            nameof this.bitcode, Json.String this.bitcode
            nameof this.直径, Json.Number this.直径
            nameof this.高度, Json.Number this.高度
        ]

    static member from(json:Json) =
        {
            bitcode = json.["bitcode"].stringText
            直径 = json.["直径"].floatValue
            高度 = json.["高度"].floatValue
        }

type TankY =
    {
        bitcode:string
        直径:float
        高度:float
        ChordHeight:float
        BottomHeight:float
    }
    member this.toJson() =
        Json.Object [
            nameof this.bitcode, Json.String this.bitcode
            nameof this.直径, Json.Number this.直径
            nameof this.高度, Json.Number this.高度
            nameof this.ChordHeight, Json.Number this.ChordHeight
            nameof this.BottomHeight, Json.Number this.BottomHeight
        ]
        
    static member from (json:Json) =
        {
            bitcode = json.["bitcode"].stringText
            直径 = json.["直径"].floatValue
            高度 = json.["高度"].floatValue
            ChordHeight = json.["ChordHeight"].floatValue
            BottomHeight = json.["BottomHeight"].floatValue
        }

type Tank =
    | LegTank of TankY
    | VerticalTank of TankP
    member this.toJson() =
        match this with
        | VerticalTank tank -> tank.toJson()
        | LegTank tank -> tank.toJson()

    static member from (json:Json) =
        if json.hasProperty "BottomHeight" then
            TankY.from json
            |> LegTank
        else
            TankP.from json
            |> VerticalTank

type PlaneData = 
    {
        basePlane : string
        distance: double
    }

    member this.toJson() = Json.from<PlaneData> this

    static member from (json:Json) = Json.To<PlaneData> json


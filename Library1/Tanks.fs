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
            //"style", Json.String "立式平底罐"
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
        弦高:float
        底高:float
    }
    member this.toJson() =
        Json.Object [
            nameof this.bitcode, Json.String this.bitcode
            nameof this.直径, Json.Number (this.直径)
            nameof this.高度, Json.Number (this.高度)
            nameof this.弦高, Json.Number (this.弦高)
            nameof this.底高, Json.Number (this.底高)

        ]
        
    static member from (json:Json) =
        {
            bitcode = json.["bitcode"].stringText
            直径 = json.["直径"].floatValue
            高度 = json.["高度"].floatValue
            弦高 = json.["弦高"].floatValue
            底高 = json.["底高"].floatValue
        }

type Tank =
    | LegTank of TankY
    | VerticalTank of TankP
    //| HangerTank of 
    member this.toJson() =
        match this with
        | VerticalTank tank -> tank.toJson()
        | LegTank tank -> tank.toJson()

    static member from (json:Json) =
        if json.ContainsKey "底高" then
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

    member this.toJson() = Json.read<PlaneData> this

    static member from (json:Json) = Json.write<PlaneData> json


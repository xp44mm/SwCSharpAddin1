namespace Training8

open System
open System.Collections
open System.Collections.Generic
open System.Drawing
open System.Diagnostics
open System.Reflection
open System.Text.RegularExpressions
open System.IO
open System.Runtime.InteropServices

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

open FSharp.Idioms
open FSharp.Idioms.Literal
open FSharp.SolidWorks

type AttCalloutHandler() =
    interface SwCalloutHandler with
        member this.OnStringValueChanged(pManipulator,rowID:int,text:string) = 
            let Callout = pManipulator :?> Callout
            [
                Callout.Label2(rowID)
                " Old value: " + Callout.Value(rowID)
                " New value: " + text
            ]
            |> ignore
            //'You could add code here to update the Attribute to reflect the change
                        
            true //'Keep change in Callout

type MyFaceAttributeDef =
    {
        FeedRate:float
        SpeedRate:float
        XPos:float
        YPos:float
        ZPos:float
        Depth:float
        HoleDiameter:float
    }
    static member AddParameters(swAttDef: AttributeDef) =
        swAttDef
        |>AttributeDefUtils.addParameter "FeedRate" swParamType_e.swParamTypeDouble 10.0

        swAttDef
        |>AttributeDefUtils.addParameter "SpeedRate" swParamType_e.swParamTypeDouble 20.0

        swAttDef
        |>AttributeDefUtils.addParameter "XPos" swParamType_e.swParamTypeDouble 0.0

        swAttDef
        |>AttributeDefUtils.addParameter "YPos" swParamType_e.swParamTypeDouble 0.0

        swAttDef
        |>AttributeDefUtils.addParameter "ZPos" swParamType_e.swParamTypeDouble 0.0

        swAttDef
        |>AttributeDefUtils.addParameter "Depth" swParamType_e.swParamTypeDouble 0.0

        swAttDef
        |>AttributeDefUtils.addParameter "HoleDiameter" swParamType_e.swParamTypeDouble 0.0

    // Getting parameters from current attribute
    static member GetParameters(swAtt:Attribute) =
        [
            "FeedRate"
            "SpeedRate"
            "XPos"
            "YPos"
            "ZPos"
            "Depth"
            "HoleDiameter"
        ]
        |> List.map(fun nameIn -> swAtt.GetParameter nameIn :?> Parameter)

    static member from (parameters: Parameter list) =
        {
            FeedRate     = parameters.[0].GetDoubleValue()
            SpeedRate    = parameters.[1].GetDoubleValue()
            XPos         = parameters.[2].GetDoubleValue()
            YPos         = parameters.[3].GetDoubleValue()
            ZPos         = parameters.[4].GetDoubleValue()
            Depth        = parameters.[5].GetDoubleValue()
            HoleDiameter = parameters.[6].GetDoubleValue()
        }

    member this.SetParameters(swAtt:Attribute) =
        swAtt
        |> MyFaceAttributeDef.GetParameters
        |> List.zip [
            this.FeedRate
            this.SpeedRate
            this.XPos
            this.YPos
            this.ZPos
            this.Depth
            this.HoleDiameter
        ]
        |> List.iter(fun(v,p)->
            ParameterUtils.setDoubleValue2 v swInConfigurationOpts_e.swAllConfiguration "" p
        )

    member this.toPairs(j:int) =
        [
            "Attr Name",$"MyFaceAttr{j}"
            "Feed",$"{this.FeedRate}"
            "Speed",$"{this.SpeedRate}"
            "X",$"{this.XPos}"
            "Y",$"{this.YPos}"
            "Z",$"{this.ZPos}"
            "DrillDia.",$"{this.HoleDiameter}"
        ]

module CNCDrilling =
    //Create an Attribute Definition here.
    let def (swApp: ISldWorks) =
        let swAttDef =
            swApp.DefineAttribute ("pubMyFaceAttributeDef")
            :?> AttributeDef
        MyFaceAttributeDef.AddParameters(swAttDef)
        swAttDef.Register()
        |> ignore

        swAttDef

    /// Traversing the body to find all of the cylindrical surfaces
    let generateMachiningInfo (swPart: IPartDoc) =
        swPart
        |> PartDocUtils.getBodies2 swBodyType_e.swSolidBody true
        |> Seq.exactlyOne
        |> Body2Utils.getFaceSeq
        |> Seq.map(fun swFace ->
            swFace
            |> Face2Utils.getSurface
            |> Pair.ofApp swFace
        )
        |> Seq.filter(fun(swFace,swSurface)->swSurface.IsCylinder())
        |> Seq.map(fun (swFace,swSurface) ->
            let cylParams = swSurface.CylinderParams :?> float[]
            let data = {
                FeedRate     = 0.002
                SpeedRate    = 250.0
                XPos         = cylParams.[0]
                YPos         = cylParams.[1]
                ZPos         = cylParams.[2]
                Depth        = 1.3
                HoleDiameter = cylParams.[6] * 2.0
            }

            swFace,data)
        |> Seq.toArray

    //if the current face surface type is cylinder
    //then gather it's info and stuff it into an
    //attribute
    let addAttributesToModel (swModel: ModelDoc2) (swAttDef: AttributeDef) (cylinders:seq<Face2*MyFaceAttributeDef>) =
        cylinders
        |> Seq.iteri(fun j (swFace,data) ->
            //Create an instance of the attribute
            //described in the userform's activate
            //handler
            let swAtt =
                swAttDef
                |> AttributeDefUtils.createInstance5
                    swModel swFace $"MyFaceAttribute-{j}" 0
                    swInConfigurationOpts_e.swAllConfiguration

            //Now set each parameter value of the
            //attribute using info from the
            //cylindrical surface
            data.SetParameters(swAtt)
        )

    //Now to display to the user which faces
    //got attributes use the callout object
    let showCallouts (swModel: ModelDoc2) (cylinders:seq<Face2*MyFaceAttributeDef>) =
        let CalloutHandler = AttCalloutHandler()

        cylinders
        |> Seq.iteri(fun i (swFace,data) ->
            let swSelMgr = swModel.SelectionManager:?> SelectionMgr

            //Create a callout object
            let swCallout = swSelMgr.CreateCallout2(7, CalloutHandler)
            swCallout.TargetStyle <- int swCalloutTargetStyle_e.swCalloutTargetStyle_Circle

            data.toPairs i
            |> Seq.iteri(fun i (name,value) ->
                swCallout.set_Label2(i, name)
                swCallout.set_Value(i, value.ToString())
            )
            let SelData = swSelMgr.CreateSelectData()
            SelData.Callout <- swCallout
            SelData.Mark <- 0

            (swFace:?>IEntity).Select4( true, SelData)
            |> ignore

            swCallout.set_ValueInactive(0, true)
            )

    //This sub does a feature traversal and searches for all the
    //attributes on this model
    //Once we find an attribute, we get its values and format a
    //CNC drilling program using
    //the data stored in the attributes parameters.
    let getAttributesFromFeature (swModel: IModelDoc2) =
        swModel.ClearSelection2(true)

        swModel
        |> ModelDoc2Utils.getFeatureSeq
        |> Seq.filter(fun swFeature -> swFeature.GetTypeName2() = "Attribute")
        |> Seq.map(fun swFeature ->
            swFeature.Select2(true, 0) |> ignore
            let swAtt = swFeature.GetSpecificFeature2() :?> Attribute
            swAtt
        )
        |> Seq.map(fun swAtt ->
            swAtt
            |> MyFaceAttributeDef.GetParameters
            |> MyFaceAttributeDef.from
        )
        |> Seq.map(fun data -> $"{stringify data}")
        |> String.concat "\n"

    let main (swApp: ISldWorks) =
        let swModel = swApp.ActiveDoc :?> ModelDoc2
        let swPart = swApp.ActiveDoc :?> IPartDoc

        let swAttDef = def swApp

        let cylinders = generateMachiningInfo swPart

        //cylinders
        //|> showCallouts swModel

        cylinders
        |> addAttributesToModel swModel swAttDef

        swModel
        |> getAttributesFromFeature
        |> swApp.SendMsgToUser


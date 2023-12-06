module CNCDrilling

open System
open System.Runtime.InteropServices
open System.Collections
open System.Collections.Generic
open System.Drawing
open System.Diagnostics
open System.Reflection
open System.Text.RegularExpressions
open System.IO

open SolidWorks.Interop.sldworks
open SolidWorks.Interop.swpublished
open SolidWorks.Interop.swconst
open SolidWorksTools
open SolidWorksTools.File

open FSharp.Idioms.Literal
open FSharp.SolidWorks
open FSharp.Idioms

// 学习1： 绘制 Callout
// 学习2： 获取ModelDoc中所有Attribute，和他的所有Parameter

let UserForm_Activate
    (swApp: SldWorks)
    =

    //Create an Attribute Definition here.
    let swAttDef =
        swApp.DefineAttribute ("pubMyFaceAttributeDef")
        :?> AttributeDef

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

    swAttDef.Register()

let cmdGenerateMachiningInfo_Click
    (swApp: SldWorks   )
    (swModel: ModelDoc2)
    (swPart: PartDoc   )

    =
    //Traversing the body to find all of the cylindrical surfaces
    swPart
    |> PartDocUtils.getBodies2 swBodyType_e.swSolidBody true

let getCallouts
    (swApp: SldWorks   )
    (swModel: ModelDoc2)
    (swPart: PartDoc   )

    (body:Body2)
    (swAttDef: AttributeDef )
    =
    body
    |> Body2Utils.getFaceSeq
    |> Seq.map(fun swFace ->
        swFace
        |> Face2Utils.getSurface
        |> Pair.ofApp swFace
    )
    |> Seq.filter(fun(swFace,swSurface)->swSurface.IsCylinder())
        //if the current face surface type is cylinder
        //then gather it's info and stuff it into an
        //attribute
    |> Seq.mapi(fun j (swFace,swSurface) ->
        //if swSurface.IsCylinder() then
            let cylParams = swSurface.CylinderParams :?> float[]
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
            //if swAtt <> null then
            let setParamValue paramName value =
                swAtt
                |> AttributeUtils.getParameter paramName
                |> ParameterUtils.setDoubleValue2 value swInConfigurationOpts_e.swAllConfiguration ""

            setParamValue "FeedRate" 0.002
            setParamValue "SpeedRate" 250
            setParamValue "XPos" (cylParams.[0] / 0.0254)
            setParamValue "YPos" (cylParams.[1] / 0.0254)
            setParamValue "ZPos" (cylParams.[2] / 0.0254)
            setParamValue "HoleDiameter" (cylParams.[6] / 0.0254 * 2.0)
            setParamValue "Depth" 1.3

            //Now to display to the user which faces
            //got attributes use the callout object

            let swSelMgr = swModel.SelectionManager:?> SelectionMgr

            //Create a callout object
            //let swCallout: Callout
            let swCallout = swSelMgr.CreateCallout2 (7, null)
            swCallout
            |> CalloutUtils.setTargetStyle swCalloutTargetStyle_e.swCalloutTargetStyle_Circle


            [
                "Attr Name",$"MyFaceAttr{j}"
                "Feed",".002"
                "Speed","250"
                "X",$"{Math.Round(cylParams.[0] / 0.0254, 2)}"
                "Y",$"{Math.Round(cylParams.[1] / 0.0254, 2)}"
                "Z",$"{Math.Round(cylParams.[2] / 0.0254, 2)}"
                "DrillDia.",$"{(cylParams.[6] / 0.0254) * 2.0}"
            ]
            |> Seq.iteri(fun i (lbl,vl) ->
                swCallout.set_Label2(i, lbl)
                swCallout.set_Value(i, vl)
            )

            //CalloutCollection.Add swCallout

            let SelData = swSelMgr.CreateSelectData()
            SelData.Callout <- swCallout
            SelData.Mark <- 0
            (swFace:?>IEntity).Select4( true, SelData) 
            |> ignore
            swCallout.set_ValueInactive(0, true)
            SelData
        )

let cmdGenerateCNCCode_Click
    (swApp: SldWorks   )
    (swModel: ModelDoc2)
    (swPart: PartDoc   )

    (body:Body2)
    (swAttDef: AttributeDef )
    =

    swModel.ClearSelection2(true)

    swModel
    |> ModelDoc2Utils.getFeatureSeq
    |> Seq.filter(fun swFeature -> swFeature.GetTypeName2() = "Attribute")
    |> Seq.map(fun swFeature ->
        swFeature.Select2(true, 0) |> ignore
        let swAtt = swFeature.GetSpecificFeature2() :?> Attribute

        // Getting parameters from current attribute
        // let paramHoleDia: Parameter
        let paramHoleDia =
            swAtt
            |> AttributeUtils.getParameter ("HoleDiameter")// :?> Parameter

        //let paramFeedRate: Parameter
        let paramFeedRate =
            swAtt
            |> AttributeUtils.getParameter("FeedRate") //:?> Parameter

        //let paramSpeedRate: Parameter
        let paramSpeedRate =
            swAtt
            |> AttributeUtils.getParameter("SpeedRate") // :?> Parameter

        //let paramXPos: Parameter
        let paramXPos =
            swAtt
            |> AttributeUtils.getParameter("XPos") // :?> Parameter

        //let paramYPos: Parameter
        let paramYPos =
            swAtt
            |> AttributeUtils.getParameter("YPos") // :?> Parameter

        //let paramZPos: Parameter
        let paramZPos =
            swAtt
            |> AttributeUtils.getParameter("ZPos") // :?> Parameter

        //let paramDepth: Parameter
        let paramDepth =
            swAtt
            |> AttributeUtils.getParameter("Depth") // :?> Parameter
        {|
            paramHoleDia   = paramHoleDia  
            paramFeedRate  = paramFeedRate 
            paramSpeedRate = paramSpeedRate
            paramXPos      = paramXPos     
            paramYPos      = paramYPos     
            paramZPos      = paramZPos     
            paramDepth     = paramDepth    
        |}
    )


//This sub does a feature traversal and searches for all the //attributes on this model
//Once we find an attribute, we get its values and format a //CNC drilling program using
//the data stored in the attributes parameters.

//Add tool change code
let addToolChangeCode
    (paramHoleDia  : float)
    (paramFeedRate : float)
    (paramSpeedRate: float)
    (paramXPos     : float)
    (paramYPos     : float)
    (paramZPos     : float)
    (paramDepth    : float)
    (i:int)
    =
    [
        $"// Drill Dia = {paramHoleDia}"
        "G50 X0 Y0 Z0 // Go Home"
        $"G00 G05 T0{i}"
        $"M03 S{paramSpeedRate}"
        $"G00 X{paramXPos} Y{paramYPos} Z1.0"
        $"G00 Z.05"
        $"G83 F{paramFeedRate} Q{paramHoleDia / 2.0 } Z{paramDepth}"
    ]
    |> String.concat "\n"

let changeDrillingPositions
    (paramXPos:float)
    (paramYPos:float)
    =
    $"X{paramXPos} Y{paramYPos}"

let cnc
    (paramHoleDia: Parameter   )
    (paramFeedRate: Parameter  )
    (paramSpeedRate: Parameter )
    (paramXPos: Parameter      )
    (paramYPos: Parameter      )
    (paramZPos: Parameter      )
    (paramDepth: Parameter     )
    =
    let paramHoleDia   = paramHoleDia  .GetDoubleValue()
    let paramFeedRate  = paramFeedRate .GetDoubleValue()
    let paramSpeedRate = paramSpeedRate.GetDoubleValue()
    let paramXPos      = paramXPos     .GetDoubleValue()
    let paramYPos      = paramYPos     .GetDoubleValue()
    let paramZPos      = paramZPos     .GetDoubleValue()
    let paramDepth     = paramDepth    .GetDoubleValue()

    let mutable FirstPass = true
    let mutable i = 0
    let mutable DrillDiameter = 0.0

    //Add formatting code and add to list box
    //if the drill diameter changes,
    //force tool change code
    if paramHoleDia <> DrillDiameter then
        FirstPass <- true
        i <- i + 1

    //Always store the drill diameter value
    //for comparison
    DrillDiameter <- paramHoleDia

    //Add tool change code if on first pass
    //or drill size changes
    let s =
        if FirstPass then
            addToolChangeCode
                (paramHoleDia  : float)
                (paramFeedRate : float)
                (paramSpeedRate: float)
                (paramXPos     : float)
                (paramYPos     : float)
                (paramZPos     : float)
                (paramDepth    : float)
                (i:int)

        else
            changeDrillingPositions
                (paramXPos:float)
                (paramYPos:float)
    File.WriteAllText(".cnc", s)
    FirstPass <- false

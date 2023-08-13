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

open FSharp.Literals.Literal



let UserForm_Activate
    (swApp: SldWorks        )
    (swModel: ModelDoc2     )
    (swPart: PartDoc        )
    (swAttDef: AttributeDef )
    (swAtt: Attribute       )
    (swAttParam: Parameter  )
    //(retval: Variant        )
    (i: int                 )
    (swFace: Face2          )
    (matProps: float[]     )
    //(DrillDiameter: float   )
    (bRet: Boolean          )
    //(CalloutCollection: Collection)
    //(CalloutHandler: AttCalloutHandler)
    =

    //let swApp = Application.SldWorks
    //let swModel = swApp.ActiveDoc
    
    //if swModel = null then
    //    MsgBox "There is no open document to run this macro on."
    //    Exit Sub

    
    //if swModel.GetType <> swDocPART then
    //    MsgBox "This code only works on a part document."
    //    Exit Sub

    
    //Create an Attribute Definition here.
    let swAttDef = 
        swApp.DefineAttribute ("pubMyFaceAttributeDef")
        |> unbox<AttributeDef>
    swAttDef.AddParameter("FeedRate", int swParamType_e.swParamTypeDouble, 10.0, 0)     |> ignore
    swAttDef.AddParameter("SpeedRate", int swParamType_e.swParamTypeDouble, 20.0, 0)    |> ignore
    swAttDef.AddParameter("XPos", int swParamType_e.swParamTypeDouble, 0.0, 0        ) |> ignore
    swAttDef.AddParameter("YPos", int swParamType_e.swParamTypeDouble, 0.0, 0        ) |> ignore
    swAttDef.AddParameter("ZPos", int swParamType_e.swParamTypeDouble, 0.0, 0        ) |> ignore
    swAttDef.AddParameter("Depth", int swParamType_e.swParamTypeDouble, 0.0, 0       ) |> ignore
    swAttDef.AddParameter("HoleDiameter", int swParamType_e.swParamTypeDouble, 0.0, 0) |> ignore
    swAttDef.Register()
    
   


let cmdGenerateMachiningInfo_Click
    (swApp: SldWorks   )
    (swModel: ModelDoc2)
    (swPart: PartDoc   )

    //(CalloutCollection: Callout[])
    //(CalloutHandler: AttCalloutHandler)
    =
    //Traversing the body to find all of the cylindrical surfaces
    //let CalloutHandler = new AttCalloutHandler()
    //let CalloutCollection = new Collection()
    //let swPart = swModel
    //if not <| swPart = null then
    //let retval = 
        swPart.GetBodies2(int swBodyType_e.swSolidBody, true)
        |> unbox<obj[]>
        |> Array.map(unbox<Body2>)

let getCallouts 
    (swApp: SldWorks   )
    (swModel: ModelDoc2)
    (swPart: PartDoc   )

    (body:Body2) 
    (swAttDef: AttributeDef )
    =
    //let j = 0
    //let faces =
    body
    |> BodyFaceTraversal.getFaceSeq
    |> Seq.map(fun swFace ->
        let swSurface = swFace.GetSurface()|> unbox<Surface>
        swFace,swSurface
    )
    |> Seq.filter(fun(swFace,swSurface)->swSurface.IsCylinder())
        //if the current face surface type is cylinder
        //then gather it//s info and stuff it into an
        //attribute
    |> Seq.mapi(fun j (swFace,swSurface) ->
        //if swSurface.IsCylinder() then
            let cylParams = swSurface.CylinderParams |> unbox<float[]>
            //Create an instance of the attribute
            //described in the userform//s activate
            //handler
            let swAtt = swAttDef.CreateInstance5(swModel, swFace, $"MyFaceAttribute-{j}", 0, int swInConfigurationOpts_e.swAllConfiguration)
                        
            //Now set each parameter value of the
            //attribute using info from the
            //cylindrical surface
            //if swAtt <> null then
            let swAttParam = swAtt.GetParameter ("FeedRate")|> unbox<Parameter>
            let bRet = swAttParam.SetDoubleValue2 (0.002, int swInConfigurationOpts_e.swAllConfiguration, "")
            let swAttParam = swAtt.GetParameter ("SpeedRate")|> unbox<Parameter>
            let bRet = swAttParam.SetDoubleValue2(250, int swInConfigurationOpts_e.swAllConfiguration, "")
            let swAttParam = swAtt.GetParameter ("XPos")|> unbox<Parameter>
            let bRet = swAttParam.SetDoubleValue2 (cylParams.[0] / 0.0254, int swInConfigurationOpts_e.swAllConfiguration, "")
            let swAttParam = swAtt.GetParameter ("YPos")|> unbox<Parameter>
            let bRet = swAttParam.SetDoubleValue2 (cylParams.[1] / 0.0254, int swInConfigurationOpts_e.swAllConfiguration, "")
            let swAttParam = swAtt.GetParameter ("ZPos")|> unbox<Parameter>
            let bRet = swAttParam.SetDoubleValue2 (cylParams.[2] / 0.0254, int swInConfigurationOpts_e.swAllConfiguration, "")
            let swAttParam = swAtt.GetParameter ("HoleDiameter")|> unbox<Parameter>
            let bRet = swAttParam.SetDoubleValue2 ((cylParams.[6] / 0.0254) * 2.0, int swInConfigurationOpts_e.swAllConfiguration, "")
            let swAttParam = swAtt.GetParameter ("Depth")|> unbox<Parameter>
            let bRet = swAttParam.SetDoubleValue2(1.3, int swInConfigurationOpts_e.swAllConfiguration, "")
                                
            //Now to display to the user which faces
            //got attributes use the callout object
                        
            let swSelMgr = swModel.SelectionManager:?> SelectionMgr
            //Create a callout object
            //let swCallout: Callout
            let swCallout = swSelMgr.CreateCallout2 (7, null)
            swCallout.TargetStyle <- int swCalloutTargetStyle_e.swCalloutTargetStyle_Circle
            swCallout.set_Label2(0, "Attr Name")
            swCallout.set_Value(0, $"MyFaceAttr{j}")
            swCallout.set_Label2(1, "Feed")
            swCallout.set_Value(1, ".002")
            swCallout.set_Label2(2, "Speed")
            swCallout.set_Value(2, "250")
            swCallout.set_Label2(3, "X")
            swCallout.set_Value(3, $"{Math.Round(cylParams.[0] / 0.0254, 2)}")
            swCallout.set_Label2(4, "Y")
            swCallout.set_Value(4, $"{Math.Round(cylParams.[1] / 0.0254, 2)}")
            swCallout.set_Label2(5, "Z")
            swCallout.set_Value(5, $"{Math.Round(cylParams.[2] / 0.0254, 2)}")
            swCallout.set_Label2(6, "DrillDia.")
            swCallout.set_Value(6, $"{(cylParams.[6] / 0.0254) * 2.0}")
            //CalloutCollection.Add swCallout

            let SelData = swSelMgr.CreateSelectData()
            SelData.Callout <- swCallout
            SelData.Mark <- 0
            (swFace:?>IEntity).Select4( true, SelData) |> ignore
            swCallout.set_ValueInactive(0, true)
            //let swAtt = null
            SelData
            //j = j + 1
        )
        //let swFace = retval(i).GetFirstFace
        //Do While not <| swFace = null

        //    let swFace = swFace.GetNextFace
        //Loop
    //for i in retval do

    //Next i

    //let swPart = null


//This sub does a feature traversal and searches for all the //attributes on this model
//Once we find an attribute, we get its values and format a //CNC drilling program using
//the data stored in the attributes parameters.

let cmdGenerateCNCCode_Click
    (swApp: SldWorks   )
    (swModel: ModelDoc2)
    (swPart: PartDoc   )

    (body:Body2) 
    (swAttDef: AttributeDef )
    =
    swModel.ClearSelection2 (true)

    let featureSeq =
        swModel
        |> FeatMgrTraversal.getFeatureSeq
        |> Seq.filter(fun swFeature -> swFeature.GetTypeName2() = "Attribute")
        |> Seq.map(fun swFeature ->
            swFeature.Select2(true, 0) |> ignore
            let swAtt = swFeature.GetSpecificFeature2() |> unbox<Attribute>
            
            //Getting parameters from current attribute
            //let paramHoleDia: Parameter
            let paramHoleDia = swAtt.GetParameter ("HoleDiameter") |> unbox<Parameter>
            
            //let paramFeedRate: Parameter
            let paramFeedRate = swAtt.GetParameter("FeedRate")|> unbox<Parameter>
            
            //let paramSpeedRate: Parameter
            let paramSpeedRate = swAtt.GetParameter("SpeedRate")|> unbox<Parameter>
            
            //let paramXPos: Parameter
            let paramXPos = swAtt.GetParameter("XPos")|> unbox<Parameter>
            
            //let paramYPos: Parameter
            let paramYPos = swAtt.GetParameter("YPos")|> unbox<Parameter>
            
            //let paramZPos: Parameter
            let paramZPos = swAtt.GetParameter("ZPos")|> unbox<Parameter>
                    
            //let paramDepth: Parameter
            let paramDepth = swAtt.GetParameter("Depth")|> unbox<Parameter>
                                
            let mutable FirstPass = true
            let mutable i = 0
            let mutable DrillDiameter:float = 0.0

            //Add formatting code and add to list box
            //if the drill diameter changes,
            //force tool change code
            if paramHoleDia.GetDoubleValue() <> DrillDiameter then
                FirstPass <- true
                i <- i + 1

            
            //Always store the drill diameter value
            //for comparison
            DrillDiameter <- paramHoleDia.GetDoubleValue()
            //Add tool change code if on first pass
            //or drill size changes
            if FirstPass then
                //Add tool change code
                File.WriteAllText("", $"// Drill Dia = {paramHoleDia.GetDoubleValue()}")
                File.WriteAllText("", "G50 X0 Y0 Z0 // Go Home")
                File.WriteAllText("", $"G00 G05 T0{i}")
                File.WriteAllText("", $"M03 S{paramSpeedRate.GetDoubleValue()}")
                File.WriteAllText("", $"G00 X{ paramXPos.GetDoubleValue() } Y{ paramYPos.GetDoubleValue() } Z1.0")
                File.WriteAllText("", $"G00 Z.05")
                File.WriteAllText("", $"G83 F{ paramFeedRate.GetDoubleValue() } Q{ paramHoleDia.GetDoubleValue() / 2.0 } Z{ paramDepth.GetDoubleValue()}")
            else
                //Change drilling positions
                File.WriteAllText("", $"X{ paramXPos.GetDoubleValue() } Y{  paramYPos.GetDoubleValue()}")

            FirstPass <- false
        
        
        )

    ////Start feature traversal
    //let swFeature = swModel.FirstFeature()
    //While not <| swFeature = null
    //    //if we find an attribute then get it//s parameters
    //    if swFeature.GetTypeName2 = "Attribute" then
    //    let swFeature = swFeature.GetNextFeature
    //Wend
    //End of CNC program
    File.WriteAllText("", "G50 X0 Y0 Z0")
    File.WriteAllText("", "M30")


//let SwCalloutHandler_OnStringValueChanged
//    (pManipulator : Object) 
//    (RowID :int) 
//    (Text : string) =
//    let Callout = pManipulator |> unbox<Callout>

//    File.AppendAllText("",Callout.Label2(RowID)+"\n")
//    File.AppendAllText("", " Old value: " + Callout.Value(RowID)+"\n")
//    File.AppendAllText("", " New value: " + Text+"\n")
    
//    //You could add code here to update the Attribute to reflect the change
    
//    SwCalloutHandler_OnStringValueChanged <- true //Keep change in Callout


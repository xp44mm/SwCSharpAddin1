Option Explicit

Dim swApp As SldWorks.SldWorks
Dim swModel As SldWorks.ModelDoc2
Dim swPart As SldWorks.PartDoc
Dim swAttDef As SldWorks.attributeDef
Dim swAtt As SldWorks.Attribute
Dim swAttParam As SldWorks.Parameter
Dim retval As Variant
Dim i As Integer
Dim swFace As SldWorks.face2
Dim matProps(8) As Double
Dim DrillDiameter As Double
Dim bRet As Boolean
Dim CalloutCollection As Collection
Dim CalloutHandler As AttCalloutHandler

Private Sub UserForm_Activate()
    Set swApp = Application.SldWorks
    Set swModel = swApp.ActiveDoc
    
    If swModel Is Nothing Then
        MsgBox "There is no open document to run this macro on."
        Exit Sub
    End If
    
    If swModel.GetType <> swDocPART Then
        MsgBox "This code only works on a part document."
        Exit Sub
    End If
    
    'Create an Attribute Definition here.
    Set swAttDef = swApp.DefineAttribute _
                        ("pubMyFaceAttributeDef")
    swAttDef.AddParameter "FeedRate", _
                        SwConst.swParamTypeDouble, 10, 0
    swAttDef.AddParameter "SpeedRate", _
                        SwConst.swParamTypeDouble, 20, 0
    swAttDef.AddParameter "XPos", _
                        SwConst.swParamTypeDouble, 0, 0
    swAttDef.AddParameter "YPos", _
                        SwConst.swParamTypeDouble, 0, 0
    swAttDef.AddParameter "ZPos", _
                        SwConst.swParamTypeDouble, 0, 0
    swAttDef.AddParameter "Depth", _
                        SwConst.swParamTypeDouble, 0, 0
    swAttDef.AddParameter "HoleDiameter", _
                        SwConst.swParamTypeDouble, 0, 0
    swAttDef.Register
    
   
End Sub

Private Sub cmdGenerateMachiningInfo_Click()
    'Traversing the body to find all of the cylindrical surfaces
    Set CalloutHandler = New AttCalloutHandler
    Set CalloutCollection = New Collection
    Set swPart = swModel
    If Not swPart Is Nothing Then
        retval = swPart.GetBodies2(swSolidBody, True)
        For i = 0 To UBound(retval)
            Dim j As Integer
            j = 0
            Set swFace = retval(i).GetFirstFace
            Do While Not swFace Is Nothing
                Dim swSurface As surface
                Set swSurface = swFace.GetSurface
                'if the current face surface type is cylinder
                'then gather it's info and stuff it into an
                'attribute
                If swSurface.IsCylinder Then
                    Dim cylParams As Variant
                    cylParams = swSurface.CylinderParams
                    'Create an instance of the attribute
                    'described in the userform's activate
                    'handler
                     Set swAtt = swAttDef.CreateInstance5 _
                        (swModel, swFace, "MyFaceAttribute-" & _
                        j, 0, SwConst.swAllConfiguration)
                        
                    'Now set each parameter value of the
                    'attribute using info from the
                    'cylindrical surface
                    If Not swAtt Is Nothing Then
                        Set swAttParam = swAtt.GetParameter _
                                ("FeedRate")
                        bRet = swAttParam.SetDoubleValue2 _
                                (0.002, _
                                SwConst.swAllConfiguration, "")
                        Set swAttParam = swAtt.GetParameter _
                                ("SpeedRate")
                        bRet = swAttParam.SetDoubleValue2(250, _
                                SwConst.swAllConfiguration, "")
                        Set swAttParam = swAtt.GetParameter _
                                ("XPos")
                        bRet = swAttParam.SetDoubleValue2 _
                                (cylParams(0) / 0.0254, _
                                SwConst.swAllConfiguration, "")
                        Set swAttParam = swAtt.GetParameter _
                                ("YPos")
                        bRet = swAttParam.SetDoubleValue2 _
                                (cylParams(1) / 0.0254, _
                                SwConst.swAllConfiguration, "")
                        Set swAttParam = swAtt.GetParameter _
                                ("ZPos")
                        bRet = swAttParam.SetDoubleValue2 _
                                (cylParams(2) / 0.0254, _
                                SwConst.swAllConfiguration, "")
                        Set swAttParam = swAtt.GetParameter _
                                ("HoleDiameter")
                        bRet = swAttParam.SetDoubleValue2 _
                                ((cylParams(6) / 0.0254) * 2, _
                                SwConst.swAllConfiguration, "")
                        Set swAttParam = swAtt.GetParameter _
                                ("Depth")
                        bRet = swAttParam.SetDoubleValue2(1.3, _
                                SwConst.swAllConfiguration, "")
                                
                        'Now to display to the user which faces
                        'got attributes use the callout object
                        
                        Dim swSelMgr As SldWorks.SelectionMgr
                        Set swSelMgr = swModel.SelectionManager
                        'Create a callout object
                        Dim swCallout As SldWorks.Callout
                        Set swCallout = swSelMgr.CreateCallout2 _
                            (7, CalloutHandler)
                        swCallout.TargetStyle = _
                                SwConst.swCalloutTargetStyle_e. _
                                swCalloutTargetStyle_Circle
                        swCallout.Label2(0) = "Attr Name"
                        swCallout.Value(0) = "MyFaceAttr" & j
                        swCallout.Label2(1) = "Feed"
                        swCallout.Value(1) = ".002"
                        swCallout.Label2(2) = "Speed"
                        swCallout.Value(2) = "250"
                        swCallout.Label2(3) = "X"
                        swCallout.Value(3) = _
                            Round(cylParams(0) / 0.0254, 2)
                        swCallout.Label2(4) = "Y"
                        swCallout.Value(4) = _
                            Round(cylParams(1) / 0.0254, 2)
                        swCallout.Label2(5) = "Z"
                        swCallout.Value(5) = _
                            Round(cylParams(2) / 0.0254, 2)
                        swCallout.Label2(6) = "DrillDia."
                        swCallout.Value(6) = _
                            (cylParams(6) / 0.0254) * 2
                        CalloutCollection.Add swCallout

                        Dim SelData As SldWorks.SelectData
                        Set SelData = swSelMgr.CreateSelectData
                        SelData.Callout = swCallout
                        SelData.Mark = 0
                        swFace.Select4 True, SelData
                        swCallout.ValueInactive(0) = True
                        Set swAtt = Nothing
                    End If
                    j = j + 1
                End If
                Set swFace = swFace.GetNextFace
            Loop
        Next i
    End If
    Set swPart = Nothing
End Sub


Private Sub cmdGenerateCNCCode_Click()
    'This sub does a feature traversal and searches for all the _
    'attributes on this model
    'Once we find an attribute, we get its values and format a _
    'CNC drilling program using
    'the data stored in the attributes parameters.
    Dim FirstPass As Boolean
    FirstPass = True
    Dim i As Integer
    i = 0
    swModel.ClearSelection2 (True)
    'Start feature traversal
    Dim swFeature As SldWorks.feature
    Set swFeature = swModel.FirstFeature
    While Not swFeature Is Nothing
        'If we find an attribute then get it's parameters
        If swFeature.GetTypeName2 = "Attribute" Then
            swFeature.Select2 True, 0
            Set swAtt = swFeature.GetSpecificFeature2
            
            'Getting parameters from current attribute
            Dim paramHoleDia As SldWorks.Parameter
            Set paramHoleDia = swAtt.GetParameter _
                ("HoleDiameter")
            
            Dim paramFeedRate As SldWorks.Parameter
            Set paramFeedRate = swAtt.GetParameter("FeedRate")
            
            Dim paramSpeedRate As SldWorks.Parameter
            Set paramSpeedRate = swAtt.GetParameter("SpeedRate")
            
            Dim paramXPos As SldWorks.Parameter
            Set paramXPos = swAtt.GetParameter("XPos")
            
            Dim paramYPos As SldWorks.Parameter
            Set paramYPos = swAtt.GetParameter("YPos")
            
            Dim paramZPos As SldWorks.Parameter
            Set paramZPos = swAtt.GetParameter("ZPos")
                    
            Dim paramDepth As SldWorks.Parameter
            Set paramDepth = swAtt.GetParameter("Depth")
                                
            'Add formatting code and add to list box
            'if the drill diameter changes,
            'force tool change code
            If paramHoleDia.GetDoubleValue <> DrillDiameter Then
                FirstPass = True
                i = i + 1
            End If
            
            'Always store the drill diameter value
            'for comparison
            DrillDiameter = paramHoleDia.GetDoubleValue
            'Add tool change code if on first pass
            'or drill size changes
            If FirstPass = True Then
                'Add tool change code
                ListBox1.AddItem "// Drill Dia = " & _
                    paramHoleDia.GetDoubleValue
                ListBox1.AddItem "G50 X0 Y0 Z0 // Go Home"
                ListBox1.AddItem "G00 G05 T0" & i
                ListBox1.AddItem "M03 S" & _
                    paramSpeedRate.GetDoubleValue
                ListBox1.AddItem "G00 X" & _
                    paramXPos.GetDoubleValue & " Y" & _
                    paramYPos.GetDoubleValue & " Z1.0"
                ListBox1.AddItem "G00 Z.05"
                ListBox1.AddItem "G83 F" & _
                    paramFeedRate.GetDoubleValue & " Q" & _
                    paramHoleDia.GetDoubleValue / 2 & " Z" & _
                    paramDepth.GetDoubleValue
            Else
                'Change drilling positions
                ListBox1.AddItem "X" & paramXPos.GetDoubleValue _
                    & " Y" & paramYPos.GetDoubleValue
            End If
            FirstPass = False
        End If
        Set swFeature = swFeature.GetNextFeature
    Wend
    'End of CNC program
    ListBox1.AddItem "G50 X0 Y0 Z0"
    ListBox1.AddItem "M30"
End Sub

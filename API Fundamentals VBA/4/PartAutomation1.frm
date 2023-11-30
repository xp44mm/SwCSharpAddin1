Option Explicit

Dim swApp As SldWorks.SldWorks
Dim swModel As SldWorks.ModelDoc2
Dim swPart As SldWorks.PartDoc

Private Sub cmdBuild_Click()
  Set swApp = Application.SldWorks
  ' Get the file path of the default part template
  Dim PartTemplate As String
  PartTemplate = swApp.GetUserPreferenceStringValue( _
    swUserPreferenceStringValue_e.swDefaultTemplatePart)
  Set swModel = swApp.NewDocument( _
    PartTemplate, 0, 0#, 0#)
  swModel.SketchManager.AddToDB = True
  swModel.Extension.SetUserPreferenceInteger swUnitsLinear, _
    swDetailingNoOptionSpecified, swMM
  'MATERIAL
  Set swPart = swModel
  If optAl.value = True Then
    swPart.SetMaterialPropertyName2 "", "", "1060 Alloy"
  Else
    swPart.SetMaterialPropertyName2 "", "", "Brass"
  End If
  
  'PROFILE
  Dim boolstatus As Boolean
  boolstatus = swModel.Extension.SelectByID2("Front Plane", _
    "PLANE", 0, 0, 0, False, 0, Nothing, 0)
  swModel.SketchManager.InsertSketch False
  If optRectangular.value = True Then
    txtRadius.enabled = False
    Dim Height As Double
    Dim Width As Double
    Height = CDbl(txtHeight.text) / 1000
    Width = CDbl(txtWidth.text) / 1000
    'Turn off dimension dialogs
    swApp.SetUserPreferenceToggle swInputDimValonCreate, _
      False
    Dim SketchSegmentObj As SldWorks.SketchSegment
    'Create the first line in the profile
    Set SketchSegmentObj = _
      swModel.SketchManager.CreateLine _
      (0.05, 0.05, 0, 0.05, 0.05 + Height, 0)
    'Add a dimension to the selected entity
    swModel.Extension.AddDimension 0, 0.05 + Height / 2, _
      0, swSmartDimensionDirection_Down
    swModel.SketchManager.CreateLine 0.05, 0.05 + Height, _
      0, 0.05 + Width, 0.05 + Height, 0
    swModel.SketchManager.CreateLine 0.05 + Width, _
      0.05 + Height, 0, 0.05 + Width, 0.05, 0
    swModel.SketchManager.CreateLine 0.05 + Width, 0.05, _
      0, 0.05, 0.05, 0
    swModel.Extension.AddDimension 0.05 + Width / 2, 0, _
      0, swSmartDimensionDirection_Down
    swModel.ClearSelection2 True
    'Select the origin
    swModel.Extension.SelectByID2 "", "EXTSKETCHPOINT", _
      0, 0, 0, False, 0, Nothing, 0
    'Select an end point on the profile
    swModel.Extension.SelectByID2 "", "SKETCHPOINT", _
      0.05, 0.05, 0, True, 0, Nothing, 0
    'Add a vertical dimension
    swModel.AddVerticalDimension2 0, 0.025, 0
    swModel.ClearSelection2 True
    'Select the origin
    swModel.Extension.SelectByID2 "", "EXTSKETCHPOINT", _
      0, 0, 0, False, 0, Nothing, 0
    'Select an end point on the profile
    swModel.Extension.SelectByID2 "", "SKETCHPOINT", _
      0.05, 0.05, 0, True, 0, Nothing, 0
    'Add a horizontal dimension
    'to fully constrain the sketch
    swModel.AddHorizontalDimension2 0.025, 0, 0
    swModel.ClearSelection2 True
    'Select a profile edge
    SketchSegmentObj.Select4 False, Nothing
    'Create the offset sketch profile from the selected edge
    'and its chain of sketch entities
    swModel.SketchManager.SketchOffset2 0.002, False, _
    True, False, False, False
    swModel.ViewZoomtofit2
  Else
    Dim Radius As Double
    Radius = CDbl(txtRadius.text) / 1000
    swModel.SketchManager.CreateCircleByRadius _
      0.05 + Radius, 0.05 + Radius, 0, Radius
    swModel.SketchManager.SketchOffset2 0.002, False, _
      True, False, False, False
    swModel.ViewZoomtofit2
  End If
  'If Revolve was chosen, an axis of revolution is needed
  If optRevolve.value = True Then
    swModel.SketchManager.CreateLine _
      (0, 0, 0, 0, 0.05, 0).ConstructionGeometry = True
  End If
  swModel.ViewZoomtofit2
  swModel.SketchManager.AddToDB = False
  
  'MACHINE OPERATION
  Dim swFeatMgr As SldWorks.FeatureManager
  If optExtrude.value = True Then
    Dim Depth As Double
    Depth = CDbl(txtDepth.text) / 1000
    Set swFeatMgr = swModel.FeatureManager
    If optRectangular.value = True Then
      If chkContour1.value = True Then
        swModel.SelectionManager.EnableContourSelection _
          = True
        swModel.Extension.SelectByID2 "", _
          "SKETCHCONTOUR", 0.05 + Width / 2, 0.05, 0, _
          True, 0, Nothing, 0
      End If
      If chkContour2.value = True Then
        swModel.SelectionManager.EnableContourSelection _
          = True
        swModel.Extension.SelectByID2 "", _
          "SKETCHCONTOUR", 0.05 + Width / 2, _
          0.05 - 0.002, 0, True, 0, Nothing, 0
      End If
    Else
      If chkContour1.value = True Then
        swModel.SelectionManager.EnableContourSelection _
          = True
        swModel.Extension.SelectByID2 "", _
          "SKETCHCONTOUR", 0.05 + Radius, 0.05, 0, _
          True, 0, Nothing, 0
      End If
      If chkContour2.value = True Then
        swModel.SelectionManager.EnableContourSelection _
          = True
        swModel.Extension.SelectByID2 "", _
          "SKETCHCONTOUR", 0.05 - 0.002, _
          0.05 + Radius, 0, True, 0, Nothing, 0
      End If
    End If
    swFeatMgr.FeatureExtrusion2 True, False, True, 0, 0, _
      Depth, 0, False, False, False, False, 0, 0, 0, 0, _
      0, 0, False, False, False, swStartSketchPlane, 0#, _
      False
    swModel.SelectionManager.EnableContourSelection = False
    swModel.ViewZoomtofit2
  Else
    Dim pi As Double
    pi = 4 * Atn(1)
    Dim Angle As Double
    'Convert to radians
    Angle = CDbl(txtAngle.text) * pi / 180#
    Set swFeatMgr = swModel.FeatureManager
    swFeatMgr.FeatureRevolve2 True, True, False, False, _
      False, False, swEndCondBlind, swEndCondBlind, _
      Angle, 0#, False, False, 0#, 0#, _
      swThinWallOneDirection, 0#, 0#, True, False, True
  End If
End Sub

Private Sub cmdExit_Click()
  End
End Sub


Private Sub MultiPage1_Change()

End Sub

'---------------------Page 1 focus -------------------------
Private Sub optAl_Click()
  optAl.ForeColor = RGB(0, 0, 0)
  optBr.ForeColor = RGB(128, 128, 128)
End Sub

Private Sub optBr_Click()
  optBr.ForeColor = RGB(0, 0, 0)
  optAl.ForeColor = RGB(128, 128, 128)
End Sub

'---------------------Page 2 focus -------------------------
Private Sub optCircular_Click()
  optCircular.ForeColor = RGB(0, 0, 0)
  txtRadius.enabled = True
  txtRadius.Locked = False
  txtRadius.BackColor = RGB(255, 255, 255)
  lblRadius.ForeColor = RGB(0, 0, 0)
  
  optRectangular.ForeColor = RGB(128, 128, 128)
  txtHeight.text = ""
  txtHeight.enabled = False
  txtHeight.Locked = True
  txtHeight.BackColor = RGB(212, 208, 200)
  lblHeight.ForeColor = RGB(128, 128, 128)
  txtWidth.text = ""
  txtWidth.enabled = False
  txtWidth.Locked = True
  txtWidth.BackColor = RGB(212, 208, 200)
  lblWidth.ForeColor = RGB(128, 128, 128)
End Sub

Private Sub optRectangular_Click()
  optRectangular.ForeColor = RGB(0, 0, 0)
  txtHeight.enabled = True
  txtHeight.Locked = False
  txtHeight.BackColor = RGB(255, 255, 255)
  lblHeight.ForeColor = RGB(0, 0, 0)
  txtWidth.enabled = True
  txtWidth.Locked = False
  txtWidth.BackColor = RGB(255, 255, 255)
  lblWidth.ForeColor = RGB(0, 0, 0)
  
  optCircular.ForeColor = RGB(128, 128, 128)
  txtRadius.text = ""
  txtRadius.enabled = False
  txtRadius.Locked = True
  txtRadius.BackColor = RGB(212, 208, 200)
  lblRadius.ForeColor = RGB(128, 128, 128)
End Sub


'---------------------Page 3 focus -------------------------
Private Sub optExtrude_Click()
  optExtrude.ForeColor = RGB(0, 0, 0)
  txtDepth.enabled = True
  txtDepth.Locked = False
  txtDepth.BackColor = RGB(255, 255, 255)
  lblDepth.ForeColor = RGB(0, 0, 0)
  
  optRevolve.ForeColor = RGB(128, 128, 128)
  txtAngle.text = ""
  txtAngle.enabled = False
  txtAngle.Locked = True
  txtAngle.BackColor = RGB(212, 208, 200)
  lblAngle.ForeColor = RGB(128, 128, 128)
  
  chkContour1.enabled = True
  chkContour1.Locked = False
  chkContour2.enabled = True
  chkContour2.Locked = False
End Sub

Private Sub optRevolve_Click()
  optRevolve.ForeColor = RGB(0, 0, 0)
  txtAngle.enabled = True
  txtAngle.Locked = False
  txtAngle.BackColor = RGB(255, 255, 255)
  lblAngle.ForeColor = RGB(0, 0, 0)
  
  optExtrude.ForeColor = RGB(128, 128, 128)
  txtDepth.text = ""
  txtDepth.enabled = False
  txtDepth.Locked = True
  txtDepth.BackColor = RGB(212, 208, 200)
  lblDepth.ForeColor = RGB(128, 128, 128)
  
  chkContour1.enabled = False
  chkContour1.Locked = True
  chkContour2.enabled = False
  chkContour2.Locked = True
End Sub


'---------------------Initial  focus -------------------------
Private Sub UserForm_Initialize()
  'Page 1
  optBr.ForeColor = RGB(128, 128, 128)
  
  'Page 2
  optCircular.ForeColor = RGB(128, 128, 128)
  txtRadius.enabled = False
  txtRadius.Locked = True
  txtRadius.BackColor = RGB(212, 208, 200)
  lblRadius.ForeColor = RGB(128, 128, 128)
  
  'Page 3
  optRevolve.ForeColor = RGB(128, 128, 128)
  txtAngle.enabled = False
  txtAngle.Locked = True
  txtAngle.BackColor = RGB(212, 208, 200)
  lblAngle.ForeColor = RGB(128, 128, 128)
End Sub










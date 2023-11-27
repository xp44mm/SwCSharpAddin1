VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} frmMacro1b 
   Caption         =   "Custom Cylinder"
   ClientHeight    =   3435
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   3240
   OleObjectBlob   =   "frmMacro1b.frx":0000
   ShowModal       =   0   'False
   StartUpPosition =   2  '屏幕中心
End
Attribute VB_Name = "frmMacro1b"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' ============================================================
'
' Copyright 2003-2015 Dassault Syst鑝es SolidWorks Corporation
'
' ============================================================

Option Explicit

Private Sub cmdBuild_Click()
  Dim swApp As Object
  Dim Part As Object
  Dim boolstatus As Boolean
  Dim diameter As Double
  Dim depth As Double
  
  diameter = CDbl(txtDiameter.Text) / 1000
  depth = CDbl(txtDepth.Text) / 1000
  
  'Connect to SOLIDWORKS
  Set swApp = Application.SldWorks
  Set Part = swApp.ActiveDoc
  
  'Create a cylinder on Front Plane
  boolstatus = Part.Extension.SelectByID2("Front Plane", _
    "PLANE", 0, 0, 0, False, 0, Nothing, 0)
  Part.SketchManager.InsertSketch True
  Dim skSegment As Object
  Set skSegment = Part.SketchManager.CreateCircleByRadius _
    (0, 0, 0, diameter / 2)
  Dim myFeature As Object
  Set myFeature = Part.FeatureManager.FeatureExtrusion2(True, _
    False, False, 0, 0, depth, 0.01, False, False, False, _
    False, 1.74532925199433E-02, 1.74532925199433E-02, False, _
    False, False, False, True, True, True, 0, 0, False)
End Sub

Private Sub cmdExit_Click()
  End
End Sub

Private Sub UserForm_Click()

End Sub

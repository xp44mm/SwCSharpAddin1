Attribute VB_Name = "BodyFaceTraversal1"
' ============================================================
'
' Copyright 2003-2022 Dassault Systèmes SolidWorks Corporation
'
' ============================================================

Option Explicit
Dim swApp As SldWorks.SldWorks
Dim swModel As SldWorks.ModelDoc2
Dim swPart As SldWorks.PartDoc
Dim retval As Variant
Dim i As Integer
Dim swFace As SldWorks.face2
Dim matProps(8) As Double

Sub main()
  Set swApp = Application.SldWorks
  If Not swApp Is Nothing Then
    Set swModel = swApp.ActiveDoc
    If Not swModel Is Nothing Then
      'Notice the Explicit Type Casting
      Set swPart = swModel
      If Not swPart Is Nothing Then
        matProps(0) = 1
        matProps(1) = 0
        matProps(2) = 0
        matProps(3) = 1
        matProps(4) = 1
        matProps(5) = 0.3
        matProps(6) = 0.3
        matProps(7) = 0
        matProps(8) = 0
        retval = swPart.GetBodies2(SwConst.swSolidBody, True)
        For i = 0 To UBound(retval)
          Set swFace = retval(i).GetFirstFace
          Do While Not swFace Is Nothing
            swFace.MaterialPropertyValues = matProps
            swModel.ActiveView.GraphicsRedraw Nothing
            Set swFace = swFace.GetNextFace
          Loop
        Next i
      End If
      Set swPart = Nothing
    End If
    Set swModel = Nothing
  End If
  Set swApp = Nothing
End Sub

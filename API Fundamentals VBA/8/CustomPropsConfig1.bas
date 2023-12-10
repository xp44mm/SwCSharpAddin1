Attribute VB_Name = "CustomPropsConfig1"
' ============================================================
'
' Copyright 2003-2022 Dassault Systèmes SolidWorks Corporation
'
' ============================================================

Option Explicit

Dim swApp As SldWorks.SldWorks
Dim swModel As SldWorks.ModelDoc2
Dim CusPropMgr As SldWorks.CustomPropertyManager
Dim AddStatus As Long
Dim retval() As String
Dim i As Integer

Sub main()
    Set swApp = Application.SldWorks
    Set swModel = swApp.ActiveDoc
    Dim density As Double
    density = 2700
    swModel.Extension.SetUserPreferenceDouble _
        swMaterialPropertyDensity, _
        swDetailingNoOptionSpecified, density
    retval = swModel.GetConfigurationNames()
    For i = 0 To UBound(retval)
        'swApp.SendMsgToUser2 retval(i), swMbInformation, swMbOk
        swModel.ShowConfiguration2 retval(i)
        Dim massprops As Variant
        Dim status As Long
        massprops = swModel.Extension.GetMassProperties2 _
            (1, status, False)
        Set CusPropMgr = swModel.Extension. _
            CustomPropertyManager(retval(i))
        AddStatus = CusPropMgr.Add3("Density - " & _
            retval(i), swCustomInfoText, _
            Format(density / 1000, "###0.000000"), _
            swCustomPropertyReplaceValue)
        AddStatus = CusPropMgr.Add3("Mass - " & _
            retval(i), swCustomInfoText, _
            Format(massprops(5) * 1000, "###0.000000"), _
            swCustomPropertyReplaceValue)
        AddStatus = CusPropMgr.Add3("Volume - " & _
            retval(i), swCustomInfoText, _
            Format(massprops(3) * 1000 * 1000, "###0.000000"), _
            swCustomPropertyReplaceValue)
        AddStatus = CusPropMgr.Add3("Area - " & _
            retval(i), swCustomInfoText, _
            Format(massprops(4) * 100 * 100, "###0.000000"), _
            swCustomPropertyReplaceValue)
     Next
End Sub

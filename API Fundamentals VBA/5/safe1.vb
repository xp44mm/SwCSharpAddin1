'--------------------------------------------------
' Preconditions:
' 1. Open a multibody part that has a scale feature.
' 2. Select the scale feature.
'
' Postconditions:
' 1. Deselects the scale feature.
' 2. Selects the faces affected by the scale feature.
' 3. Examine the graphics area.
'--------------------------------------------------
Option Explicit
Sub main()
    Dim swApp As SldWorks.SldWorks
    Dim swModel As SldWorks.ModelDoc2
    Dim swSelMgr As SldWorks.SelectionMgr
    Dim swSelData As SldWorks.SelectData
    Dim swFeat As SldWorks.Feature
    Dim swScaleFeat As SldWorks.ScaleFeatureData
    Dim vBody As Variant
    Dim vBodyArr As Variant
    Dim swBody As SldWorks.Body2
    Dim swFace As SldWorks.Face2
    Dim swEnt As SldWorks.Entity
    Dim swSafeEnt As SldWorks.Entity
    Dim vSafeEnt As Variant
    Dim swSafeEntColl As New Collection
    Dim i As Long
    Dim bRet As Boolean
    Set swApp = CreateObject("SldWorks.Application")
    Set swModel = swApp.ActiveDoc
    Set swSelMgr = swModel.SelectionManager
    Set swFeat = swSelMgr.GetSelectedObject6(1, -1)
    Set swScaleFeat = swFeat.GetDefinition
    
    bRet = swScaleFeat.AccessSelections(swModel, Nothing)
    vBodyArr = swScaleFeat.Bodies
    For Each vBody In vBodyArr
        Set swBody = vBody
        Set swFace = swBody.GetFirstFace
        Do While Not swFace Is Nothing
            ' Face reference is only valid in rolled-back
            ' state, so get a more persistent face reference
            Set swEnt = swFace
            Set swSafeEnt = swEnt.GetSafeEntity
            swSafeEntColl.Add swSafeEnt
            Set swFace = swFace.GetNextFace
        Loop
    Next
    swScaleFeat.ReleaseSelectionAccess
    For Each vSafeEnt In swSafeEntColl
        Set swSafeEnt = vSafeEnt
        bRet = swSafeEnt.Select4(True, swSelData)
    Next
End Sub
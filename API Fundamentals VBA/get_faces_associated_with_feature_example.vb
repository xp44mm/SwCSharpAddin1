'-----------------------------------------------
' Preconditions:
' 1. Open a part document.
' 2. Select a feature in the FeatureManager design
'    tree.
' 3. Open the Immediate window.
'
' Postconditions:
' 1. Gets the name of the feature and number
'    of faces.
' 2. Colors the faces of the feature blue.
'    NOTE: The faces are the same faces as if
'    you selected the feature in the user interface.
' 3. Examine the Immediate window and graphics area.
'-----------------------------------------------
Option Explicit
Sub main()
    Dim swApp As SldWorks.SldWorks
    Dim swModel As SldWorks.ModelDoc2
    Dim swSelMgr As SldWorks.SelectionMgr
    Dim swSelData As SldWorks.SelectData
    Dim swFeat As SldWorks.Feature
    Dim swFaceFeat As SldWorks.Feature
    Dim faceArr As Variant
    Dim oneFace As Variant
    Dim featColors As Variant
    Dim swFace As SldWorks.Face2
    Dim swEnt As SldWorks.Entity
    Dim status As Boolean
    Set swApp = Application.SldWorks
    Set swModel = swApp.ActiveDoc
    Set swSelMgr = swModel.SelectionManager
    Set swFeat = swSelMgr.GetSelectedObject6(1, -1)
    Set swSelData = swSelMgr.CreateSelectData
    Debug.Print "Feature = " + swFeat.Name + " [" + swFeat.GetTypeName + "]"
    Debug.Print "  Face count = " & swFeat.GetFaceCount
    swModel.ClearSelection2 True
    featColors = swModel.MaterialPropertyValues
    featColors(0) = 0  'R
    featColors(1) = 0  'G
    featColors(2) = 1  'B
    faceArr = swFeat.GetFaces: If IsEmpty(faceArr) Then Exit Sub
    For Each oneFace In faceArr
        Set swFace = oneFace
        Set swEnt = swFace
        Set swFaceFeat = swFace.GetFeature
        ' Check to see if face is owned by multiple features
        If swFaceFeat Is swFeat Then
            status = swEnt.Select4(True, swSelData): Debug.Assert status
            swFace.MaterialPropertyValues = featColors
        Else
            Debug.Print "  Other feature = " & swFaceFeat.Name + " [" + swFaceFeat.GetTypeName + "]"
        End If
    Next
    
End Sub
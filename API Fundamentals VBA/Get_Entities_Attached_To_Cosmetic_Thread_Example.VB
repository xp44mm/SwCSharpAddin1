'----------------------------------------------------
' Preconditions:
' 1. Open a drawing of a model with a cosmetic thread.
' 2. Select a drawing view of the model with the cosmetic
'    thread.
'
' Postconditions: Displays a message box with the
' radius of the cosmetic thread.
'-----------------------------------------------------
Option Explicit
Sub main()
    Dim swApp As SldWorks.SldWorks
    Dim activeDocument As SldWorks.DrawingDoc
    Dim pAnnotation As SldWorks.Annotation
    Dim selType As Long
    Dim entityCount As Long
    Dim SelMgr As Object
    Dim entitiesArray As Variant
    Dim attachedEntity As SldWorks.Entity
    Dim selView As SldWorks.View
    Dim annotType As Long
    Dim attachedEntityTypes As Variant
    Dim i As Long
    Dim edgeParams As Variant
    Dim edgeRadius As Double
    Dim faceParams As Variant
    Dim faceRadius As Double    
    Set swApp = CreateObject("SldWorks.Application")
    Set activeDocument = swApp.ActiveDoc    
    If (activeDocument.GetType <> swDocDRAWING) Then
        Exit Sub
    End If    
    Set SelMgr = activeDocument.SelectionManager
    selType = SelMgr.GetSelectedObjectType2(1)    
    If (selType = swSelDRAWINGVIEWS) Then
        ' Get the selected drawing view
        Set selView = SelMgr.GetSelectedObject6(1, -1)
            If (selView Is Nothing) Then
             Exit Sub
            End If
            ' Get first annotation in the view
            Set pAnnotation = selView.GetFirstAnnotation3
            ' Loop through every annotation in view
            While (Not pAnnotation Is Nothing)
                ' Get the type of annotation
                annotType = pAnnotation.GetType
                ' For each CThread, get radius of attached entity
                If (annotType = swCThread) Then
                    ' Get attached entities
                    entitiesArray = pAnnotation.GetAttachedEntities
                    attachedEntityTypes = pAnnotation.GetAttachedEntityTypes
                    ' Get number of attached entities
                    entityCount = UBound(entitiesArray) + 1
                        ' For each entity attached to this CThread
                        For i = 0 To (entityCount - 1)
                        ' Get the individual Edge or Face2 object
                        Set attachedEntity = entitiesArray(i)
                        ' If attached entity is an edge
                            If (attachedEntityTypes(i) = swSelEDGES) Then
                                edgeParams = attachedEntity.GetCurve.CircleParams
                                edgeRadius = edgeParams(6)
                                swApp.SendMsgToUser "Cosmetic Thread Edge Radius = " + Str(edgeRadius)
                            ' If attached entity is a face
                            ElseIf (attachedEntityTypes(i) = swSelFACES) Then
                                faceParams = attachedEntity.GetSurface.CylinderParams
                                faceRadius = faceParams(6)
                                swApp.SendMsgToUser "Cosmetic Thread Face Radius = " + Str(faceRadius)
                            End If
                        Next i
                End If
                Set pAnnotation = pAnnotation.GetNext3
            Wend
        Else
        swApp.SendMsgToUser "Please select a drawing view containing cosmetic thread annotations"
    End If
End Sub
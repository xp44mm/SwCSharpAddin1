Option Explicit

Implements SwCalloutHandler

Private Function SwCalloutHandler_OnStringValueChanged(ByVal pManipulator As Object, ByVal RowID As Long, ByVal Text As String) As Boolean
    Dim Callout As SldWorks.Callout
    Set Callout = pManipulator
    Debug.Print Callout.Label2(RowID)
    Debug.Print " Old value: " & Callout.Value(RowID)
    Debug.Print " New value: " & Text
    
    'You could add code here to update the Attribute to reflect the change
    
    SwCalloutHandler_OnStringValueChanged = True 'Keep change in Callout
End Function

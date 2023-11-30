Dim swApp As Object

Dim Part As Object
Dim boolstatus As Boolean
Dim longstatus As Long, longwarnings As Long

Sub main()

Set swApp = Application.SldWorks

Set Part = swApp.ActiveDoc
boolstatus = Part.Extension.SelectByID2("Line2", "SKETCHSEGMENT", 0.107886594709916, 0.250065733641515, 4.99999999991444E-05, False, 0, Nothing, 0)
Part.SketchAddConstraints "sgHORIZONTAL2D"
boolstatus = Part.Extension.SelectByID2("Line3", "SKETCHSEGMENT", 0.148716067175824, 0.164564014830555, 4.99999999997415E-05, False, 0, Nothing, 0)
Part.SketchAddConstraints "sgVERTICAL2D"
End Sub

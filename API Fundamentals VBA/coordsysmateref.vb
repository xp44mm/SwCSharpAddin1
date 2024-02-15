Set Part = swApp.ActiveDoc
boolstatus = Part.Extension.SelectByID2("v0102a", "COORDSYS", 0, 0, 0, False, 0, Nothing, 0)
Dim myFeature As Object
Set myFeature = Part.FeatureManager.InsertMateReference2("Default", Nothing, 2, 0, True, Nothing, 0, 0, False, Nothing, 0, 0)
Part.ClearSelection2 True

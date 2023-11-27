Imports System
Imports System.Collections
Imports System.Reflection
Imports System.Runtime.InteropServices

Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports SolidWorks.Interop.swpublished
Imports SolidWorksTools
Imports SolidWorksTools.File

Imports System.Collections.Generic
Imports System.Diagnostics

<Guid("337a9aa6-8497-43f7-8f63-94ee03aab10c")> _
    <ComVisible(True)> _
    <SwAddin( _
        Description:="NewMenus description", _
        Title:="NewMenus", _
        LoadAtStartup:=True _
        )> _
        Public Class SwAddin
    Implements SolidWorks.Interop.swpublished.SwAddin

#Region "Local Variables"
    Dim WithEvents iSwApp As SldWorks
    Dim iCmdMgr As ICommandManager
    Dim addinID As Integer
    Dim openDocs As Hashtable
    Dim SwEventPtr As SldWorks
    Dim ppage As UserPMPage
    Dim iBmp As BitmapHandler

    Public Const mainCmdGroupID As Integer = 0
    Public Const mainItemID1 As Integer = 0
    Public Const mainItemID2 As Integer = 1
  Public Const mainItemID3 As Integer = 2
  Public Const rotateCmdGroupID As Integer = 10
  Public Const rotateItemID1 As Integer = 0
  Public Const rotateItemID2 As Integer = 1
  Public Const rotateItemID3 As Integer = 2
	Public Const contextCmdGroupID As Integer = 20
	Public Const flyoutGroupID As Integer = 91

    ' Public Properties
    ReadOnly Property SwApp() As SldWorks
        Get
            Return iSwApp
        End Get
    End Property

    ReadOnly Property CmdMgr() As ICommandManager
        Get
            Return iCmdMgr
        End Get
    End Property

    ReadOnly Property OpenDocumentsTable() As Hashtable
        Get
            Return openDocs
        End Get
    End Property
#End Region

#Region "SolidWorks Registration"

    <ComRegisterFunction()> Public Shared Sub RegisterFunction(ByVal t As Type)

        ' Get Custom Attribute: SwAddinAttribute
        Dim attributes() As Object
        Dim SWattr As SwAddinAttribute = Nothing

        attributes = System.Attribute.GetCustomAttributes(GetType(SwAddin), GetType(SwAddinAttribute))

        If attributes.Length > 0 Then
            SWattr = DirectCast(attributes(0), SwAddinAttribute)
        End If
        Try
            Dim hklm As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine
            Dim hkcu As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser

            Dim keyname As String = "SOFTWARE\SolidWorks\Addins\{" + t.GUID.ToString() + "}"
            Dim addinkey As Microsoft.Win32.RegistryKey = hklm.CreateSubKey(keyname)
            addinkey.SetValue(Nothing, 0)
            addinkey.SetValue("Description", SWattr.Description)
            addinkey.SetValue("Title", SWattr.Title)

            keyname = "Software\SolidWorks\AddInsStartup\{" + t.GUID.ToString() + "}"
            addinkey = hkcu.CreateSubKey(keyname)
            addinkey.SetValue(Nothing, SWattr.LoadAtStartup, Microsoft.Win32.RegistryValueKind.DWord)
        Catch nl As System.NullReferenceException
            Console.WriteLine("There was a problem registering this dll: SWattr is null.\n " & nl.Message)
            System.Windows.Forms.MessageBox.Show("There was a problem registering this dll: SWattr is null.\n" & nl.Message)
        Catch e As System.Exception
            Console.WriteLine("There was a problem registering this dll: " & e.Message)
            System.Windows.Forms.MessageBox.Show("There was a problem registering this dll: " & e.Message)
        End Try
    End Sub

    <ComUnregisterFunction()> Public Shared Sub UnregisterFunction(ByVal t As Type)
        Try
            Dim hklm As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine
            Dim hkcu As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser

            Dim keyname As String = "SOFTWARE\SolidWorks\Addins\{" + t.GUID.ToString() + "}"
            hklm.DeleteSubKey(keyname)

            keyname = "Software\SolidWorks\AddInsStartup\{" + t.GUID.ToString() + "}"
            hkcu.DeleteSubKey(keyname)
        Catch nl As System.NullReferenceException
            Console.WriteLine("There was a problem unregistering this dll: SWattr is null.\n " & nl.Message)
            System.Windows.Forms.MessageBox.Show("There was a problem unregistering this dll: SWattr is null.\n" & nl.Message)
        Catch e As System.Exception
            Console.WriteLine("There was a problem unregistering this dll: " & e.Message)
            System.Windows.Forms.MessageBox.Show("There was a problem unregistering this dll: " & e.Message)
        End Try

    End Sub

#End Region

#Region "ISwAddin Implementation"

    Function ConnectToSW(ByVal ThisSW As Object, ByVal Cookie As Integer) As Boolean Implements SolidWorks.Interop.swpublished.SwAddin.ConnectToSW
        iSwApp = ThisSW
        addinID = Cookie

        ' Setup callbacks
        iSwApp.SetAddinCallbackInfo(0, Me, addinID)

        ' Setup the Command Manager
        iCmdMgr = iSwApp.GetCommandManager(Cookie)
        AddCommandMgr()

        'Setup the Event Handlers
        SwEventPtr = iSwApp
        openDocs = New Hashtable
        AttachEventHandlers()

        'Setup Sample Property Manager
        AddPMP()

        ConnectToSW = True
    End Function

    Function DisconnectFromSW() As Boolean Implements SolidWorks.Interop.swpublished.SwAddin.DisconnectFromSW

        RemoveCommandMgr()
        RemovePMP()
        DetachEventHandlers()

        System.Runtime.InteropServices.Marshal.ReleaseComObject(iCmdMgr)
        iCmdMgr = Nothing
        System.Runtime.InteropServices.Marshal.ReleaseComObject(iSwApp)
        iSwApp = Nothing
        'The addin _must_ call GC.Collect() here in order to retrieve all managed code pointers 
        GC.Collect()
        GC.WaitForPendingFinalizers()

        GC.Collect()
        GC.WaitForPendingFinalizers()

        DisconnectFromSW = True
    End Function
#End Region

#Region "UI Methods"
    Public Sub AddCommandMgr()

        Dim cmdGroup As ICommandGroup

        If iBmp Is Nothing Then
            iBmp = New BitmapHandler()
        End If

        Dim thisAssembly As Assembly

        Dim cmdIndex0 As Integer, cmdIndex1 As Integer
    Dim cmdIndex2 As Integer
    Dim cmdIndexRotate0 As Integer, cmdIndexRotate1 As Integer, cmdIndexRotate2 As Integer
    Dim Title As String = "NewMenus"
    Dim ToolTip As String = "New Menus"
    Dim Hint As String = "New Menus"
    Dim docTypes() As Integer = { _
      swDocumentTypes_e.swDocASSEMBLY, _
                                       swDocumentTypes_e.swDocDRAWING, _
                                       swDocumentTypes_e.swDocPART}

    thisAssembly = System.Reflection.Assembly. _
      GetAssembly(Me.GetType())
   
        Dim cmdGroupErr As Integer = 0
        Dim ignorePrevious As Boolean = False

        Dim registryIDs As Object = Nothing
    Dim getDataResult As Boolean = _
      iCmdMgr.GetGroupDataFromRegistry(mainCmdGroupID, _
                                       registryIDs)

    Dim knownIDs As Integer() = New Integer(2) { _
      mainItemID1, mainItemID2, mainItemID3}

        If getDataResult Then
      'if the IDs don't match, reset the commandGroup
      If Not CompareIDs(registryIDs, knownIDs) Then
                ignorePrevious = True
            End If
        End If

    cmdGroup = iCmdMgr.CreateCommandGroup2( _
      mainCmdGroupID, Title, ToolTip, Hint, -1, _
      ignorePrevious, cmdGroupErr)
        If cmdGroup Is Nothing Or thisAssembly Is Nothing Then
            Throw New NullReferenceException()
        End If
     
    cmdGroup.LargeIconList = _
      iBmp.CreateFileFromResourceBitmap( _
      "NewMenus.ToolbarLarge.bmp", thisAssembly)
    cmdGroup.SmallIconList = _
      iBmp.CreateFileFromResourceBitmap( _
      "NewMenus.ToolbarSmall.bmp", thisAssembly)
    cmdGroup.LargeMainIcon = _
      iBmp.CreateFileFromResourceBitmap( _
      "NewMenus.MainIconLarge.bmp", thisAssembly)
    cmdGroup.SmallMainIcon = _
      iBmp.CreateFileFromResourceBitmap( _
      "NewMenus.MainIconSmall.bmp", thisAssembly)

    Dim menuToolbarOption As Integer = _
      swCommandItemType_e.swMenuItem Or _
      swCommandItemType_e.swToolbarItem

    cmdIndex0 = cmdGroup.AddCommandItem2( _
      "CreateCube", -1, _
      "Create a cube", _
      "Create cube", 0, _
      "CreateCube", "", mainItemID1, _
      menuToolbarOption)
    cmdIndex1 = cmdGroup.AddCommandItem2( _
      "Show PMP", -1, _
      "Display sample property manager", _
      "Show PMP", 2, _
      "ShowPMP", "PMPEnable", mainItemID2, _
      menuToolbarOption)
    'Add New Menu Item
    cmdIndex2 = cmdGroup.AddCommandItem2( _
      "CreateCylinder", -1, _
      "Create an extruded cylinder", _
      "Creates an extruded cylinder", 1, _
      "CreateCylinder", "", mainItemID3, _
      menuToolbarOption)

        cmdGroup.HasToolbar = True
        cmdGroup.HasMenu = True
        cmdGroup.Activate()

        Dim flyGroup As FlyoutGroup
    flyGroup = iCmdMgr.CreateFlyoutGroup(flyoutGroupID, _
      "Dynamic Flyout", "Flyout Tooltip", "Flyout Hint", _
      cmdGroup.SmallMainIcon, cmdGroup.LargeMainIcon, _
      cmdGroup.SmallIconList, cmdGroup.LargeIconList, _
      "FlyoutCallback", "FlyoutEnable")

    'This is never actually used, since it is removed
    'in FlyoutCallback()
    flyGroup.AddCommandItem("FlyoutCommand 1", "test", _
      0, "FlyoutCommandItem1", _
      "FlyoutEnableCommandItem1")

    flyGroup.FlyoutType = _
      swCommandFlyoutStyle_e.swCommandFlyoutStyle_Simple

    'Add Command Manager Tab for each document type
        For Each docType As Integer In docTypes
      Dim cmdTab As ICommandTab = _
        iCmdMgr.GetCommandTab(docType, Title)
            Dim bResult As Boolean

      'if tab exists, but we have ignored the registry
      'info, re-create the tab.  Otherwise the ids won't
      'matchup and the tab will be blank
      If Not cmdTab Is Nothing And _
        Not getDataResult Or _
        ignorePrevious Then
        Dim res As Boolean = _
          iCmdMgr.RemoveCommandTab(cmdTab)
                cmdTab = Nothing
            End If

            If cmdTab Is Nothing Then
                cmdTab = iCmdMgr.AddCommandTab(docType, Title)
        Dim cmdBox As CommandTabBox = _
          cmdTab.AddCommandTabBox

                Dim cmdIDs(3) As Integer
                Dim TextType(3) As Integer

                cmdIDs(0) = cmdGroup.CommandID(cmdIndex0)
        TextType(0) = swCommandTabButtonTextDisplay_e. _
          swCommandTabButton_TextHorizontal
                cmdIDs(1) = cmdGroup.CommandID(cmdIndex1)
        TextType(1) = swCommandTabButtonTextDisplay_e. _
          swCommandTabButton_TextHorizontal
        cmdIDs(2) = cmdGroup.CommandID(cmdIndex2)
        TextType(2) = swCommandTabButtonTextDisplay_e. _
          swCommandTabButton_TextHorizontal
        cmdIDs(3) = cmdGroup.ToolbarId
        TextType(3) = swCommandTabButtonTextDisplay_e. _
          swCommandTabButton_TextHorizontal
                bResult = cmdBox.AddCommands(cmdIDs, TextType)

        Dim cmdBox1 As CommandTabBox = _
          cmdTab.AddCommandTabBox()
                ReDim cmdIDs(1)
                ReDim TextType(1)

                cmdIDs(0) = flyGroup.CmdID
        TextType(0) = swCommandTabButtonTextDisplay_e. _
          swCommandTabButton_TextBelow
                bResult = cmdBox1.AddCommands(cmdIDs, TextType)

                cmdTab.AddSeparator(cmdBox1, cmdIDs(0))
      End If
    Next

    'Check to see whether there has been a change
    'of Rotate Tools Command IDs
    registryIDs = Nothing
    Dim getDataResultRotate As Boolean = _
      iCmdMgr.GetGroupDataFromRegistry( _
      rotateCmdGroupID, registryIDs)
    Dim knownRotateIDs As Integer() = New Integer(2) { _
      rotateItemID1, rotateItemID2, rotateItemID3}
    Dim ignorePreviousRotate As Boolean = False
    If getDataResultRotate Then
			'if the IDs don't match, reset the CommandGroup
      If Not CompareIDs(registryIDs, knownRotateIDs) Then
        ignorePreviousRotate = True
      End If
    End If

    'Add new Rotate Tools command group
    Dim TitleRotate As String = "RotateTools"
    Dim ToolTipRotate As String = "Rotate Tools"
    Dim HintRotate As String = "Rotate Tools"
    Dim cmdGroupRotate As CommandGroup
    cmdGroupRotate = iCmdMgr.CreateCommandGroup2( _
      rotateCmdGroupID, TitleRotate, ToolTipRotate, _
      HintRotate, -1, ignorePreviousRotate, cmdGroupErr)
    cmdGroupRotate.LargeIconList = _
        iBmp.CreateFileFromResourceBitmap _
        ("NewMenus.ToolbarLarge.bmp", thisAssembly)
    cmdGroupRotate.SmallIconList = _
        iBmp.CreateFileFromResourceBitmap _
        ("NewMenus.ToolbarSmall.bmp", thisAssembly)
    cmdGroupRotate.LargeMainIcon = _
        iBmp.CreateFileFromResourceBitmap _
        ("NewMenus.MainIconLarge.bmp", thisAssembly)
    cmdGroupRotate.SmallMainIcon = _
        iBmp.CreateFileFromResourceBitmap _
        ("NewMenus.MainIconSmall.bmp", thisAssembly)

    'Add New Rotate Tools commands
    cmdIndexRotate0 = cmdGroupRotate.AddCommandItem2( _
      "Rotate X", -1, _
      "Rotate the part in the positive x direction", _
      "Rotate in the x direction", 0, "RotateX", "", 0, _
      menuToolbarOption)
    cmdIndexRotate1 = cmdGroupRotate.AddCommandItem2( _
      "Rotate Y", -1, _
      "Rotate the part in the positive y direction", _
      "Rotate in the y direction", 1, "RotateY", "", 1, _
      menuToolbarOption)
    cmdIndexRotate2 = cmdGroupRotate.AddCommandItem2( _
      "Rotate Z", -1, _
      "Rotate the part in the positive z direction", _
      "Rotate in the z direction", 2, "RotateZ", "", 2, _
      menuToolbarOption)

    'We only want a toolbar and no menu
    'for this command group
    cmdGroupRotate.HasToolbar = True
    cmdGroupRotate.HasMenu = False
    cmdGroupRotate.Activate()

    'Add a Rotate Tools Command Manager Tab
    'for each document type
    For Each docType As Integer In docTypes
			Dim cmdTab As CommandTab = _
				iCmdMgr.GetCommandTab(docType, TitleRotate)
      Dim bResult As Boolean

      'if tab exists, but we have ignored the registry
      'info, re-create the tab.  Otherwise the ids won't
			'match up and the tab will be blank
      If Not cmdTab Is Nothing And _
        Not getDataResultRotate Or _
        ignorePreviousRotate Then
        Dim res As Boolean = _
          iCmdMgr.RemoveCommandTab(cmdTab)
        cmdTab = Nothing
      End If

      If cmdTab Is Nothing Then
        cmdTab = _
          iCmdMgr.AddCommandTab(docType, TitleRotate)
        Dim cmdBox As CommandTabBox = _
          cmdTab.AddCommandTabBox
        Dim cmdIDs(2) As Integer
        Dim TextType(2) As Integer
        cmdIDs(0) = _
          cmdGroupRotate.CommandID(cmdIndexRotate0)
        TextType(0) = swCommandTabButtonTextDisplay_e. _
          swCommandTabButton_TextHorizontal
        cmdIDs(1) = _
          cmdGroupRotate.CommandID(cmdIndexRotate1)
        TextType(1) = swCommandTabButtonTextDisplay_e. _
          swCommandTabButton_TextHorizontal
        cmdIDs(2) = _
          cmdGroupRotate.CommandID(cmdIndexRotate2)
        TextType(2) = swCommandTabButtonTextDisplay_e. _
          swCommandTabButton_TextHorizontal
        bResult = cmdBox.AddCommands(cmdIDs, TextType)
            End If
		Next

		Dim cmdGroupContext As CommandGroup
		cmdGroupContext = iCmdMgr.AddContextMenu(contextCmdGroupID, "My Context Menu")
		cmdGroupContext.SelectType = swSelectType_e.swSelFACES
		cmdGroupContext.LargeIconList = _
		iBmp.CreateFileFromResourceBitmap _
		("NewMenus.ToolbarLarge.bmp", thisAssembly)
		cmdGroupContext.SmallIconList = _
				iBmp.CreateFileFromResourceBitmap _
				("NewMenus.ToolbarSmall.bmp", thisAssembly)
		cmdGroupContext.LargeMainIcon = _
				iBmp.CreateFileFromResourceBitmap _
				("NewMenus.MainIconLarge.bmp", thisAssembly)
		cmdGroupContext.SmallMainIcon = _
				iBmp.CreateFileFromResourceBitmap _
				("NewMenus.MainIconSmall.bmp", thisAssembly)

		Dim MenuItem1Id As Integer = 0
		Dim MenuItem1Index As Integer
		MenuItem1Index = cmdGroupContext.AddCommandItem2("Menu Item 1", -1, "Hint", "Tool Tip", 0, "ContextItem1", "", MenuItem1Id, swCommandItemType_e.swMenuItem)
		cmdGroupContext.HasMenu = True
		cmdGroupContext.HasToolbar = False
		cmdGroupContext.Activate()

        thisAssembly = Nothing

    End Sub

	Public Sub ContextItem1()
		Try
		Catch e As Exception
		End Try
	End Sub

	Public Sub RemoveCommandMgr()
		Try
			iBmp.Dispose()
			iCmdMgr.RemoveCommandGroup(mainCmdGroupID)
			iCmdMgr.RemoveCommandGroup(rotateCmdGroupID)
			iCmdMgr.RemoveCommandGroup2(contextCmdGroupID, False)	'Also remove the CommandGroup and its toolbar information from the registry
			iCmdMgr.RemoveFlyoutGroup(flyoutGroupID)
		Catch e As Exception
		End Try
	End Sub


    Function AddPMP() As Boolean
        ppage = New UserPMPage
        ppage.Init(iSwApp, Me)
    End Function

    Function RemovePMP() As Boolean
        ppage = Nothing
    End Function

    Function CompareIDs(ByVal storedIDs() As Integer, ByVal addinIDs() As Integer) As Boolean

        Dim storeList As New List(Of Integer)(storedIDs)
        Dim addinList As New List(Of Integer)(addinIDs)

        addinList.Sort()
        storeList.Sort()

        If Not addinList.Count = storeList.Count Then
            
            Return False
        Else

            For i As Integer = 0 To addinList.Count - 1
                If Not addinList(i) = storeList(i) Then
                    
                    Return False
                End If
            Next
        End If

        Return True
    End Function
#End Region

#Region "Event Methods"
    Sub AttachEventHandlers()
        AttachSWEvents()

        'Listen for events on all currently open docs
        AttachEventsToAllDocuments()
    End Sub

    Sub DetachEventHandlers()
        DetachSWEvents()

        'Close events on all currently open docs
        Dim docHandler As DocumentEventHandler
        Dim key As ModelDoc2
        Dim numKeys As Integer
        numKeys = openDocs.Count
        If numKeys > 0 Then
            Dim keys() As Object = New Object(numKeys - 1) {}

            'Remove all document event handlers
            openDocs.Keys.CopyTo(keys, 0)
            For Each key In keys
                docHandler = openDocs.Item(key)
                docHandler.DetachEventHandlers() 'This also removes the pair from the hash
                docHandler = Nothing
                key = Nothing
            Next
        End If
    End Sub

    Sub AttachSWEvents()
        Try
            AddHandler iSwApp.ActiveDocChangeNotify, AddressOf Me.SldWorks_ActiveDocChangeNotify
            AddHandler iSwApp.DocumentLoadNotify2, AddressOf Me.SldWorks_DocumentLoadNotify2
            AddHandler iSwApp.FileNewNotify2, AddressOf Me.SldWorks_FileNewNotify2
            AddHandler iSwApp.ActiveModelDocChangeNotify, AddressOf Me.SldWorks_ActiveModelDocChangeNotify
            AddHandler iSwApp.FileOpenPostNotify, AddressOf Me.SldWorks_FileOpenPostNotify
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
    End Sub

    Sub DetachSWEvents()
        Try
            RemoveHandler iSwApp.ActiveDocChangeNotify, AddressOf Me.SldWorks_ActiveDocChangeNotify
            RemoveHandler iSwApp.DocumentLoadNotify2, AddressOf Me.SldWorks_DocumentLoadNotify2
            RemoveHandler iSwApp.FileNewNotify2, AddressOf Me.SldWorks_FileNewNotify2
            RemoveHandler iSwApp.ActiveModelDocChangeNotify, AddressOf Me.SldWorks_ActiveModelDocChangeNotify
            RemoveHandler iSwApp.FileOpenPostNotify, AddressOf Me.SldWorks_FileOpenPostNotify
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
    End Sub

    Sub AttachEventsToAllDocuments()
        Dim modDoc As ModelDoc2
        modDoc = iSwApp.GetFirstDocument()
        While Not modDoc Is Nothing
            If Not openDocs.Contains(modDoc) Then
                AttachModelDocEventHandler(modDoc)
            Else
                Dim docHandler As DocumentEventHandler = openDocs(modDoc)
                If Not docHandler Is Nothing Then
                    docHandler.ConnectModelViews()
                End If
            End If
            modDoc = modDoc.GetNext()
        End While
    End Sub

    Function AttachModelDocEventHandler(ByVal modDoc As ModelDoc2) As Boolean
        If modDoc Is Nothing Then
            Return False
        End If
        Dim docHandler As DocumentEventHandler = Nothing

        If Not openDocs.Contains(modDoc) Then
            Select Case modDoc.GetType
                Case swDocumentTypes_e.swDocPART
                    docHandler = New PartEventHandler()
                Case swDocumentTypes_e.swDocASSEMBLY
                    docHandler = New AssemblyEventHandler()
                Case swDocumentTypes_e.swDocDRAWING
                    docHandler = New DrawingEventHandler()
            End Select

            docHandler.Init(iSwApp, Me, modDoc)
            docHandler.AttachEventHandlers()
            openDocs.Add(modDoc, docHandler)
        End If
    End Function

    Sub DetachModelEventHandler(ByVal modDoc As ModelDoc2)
        Dim docHandler As DocumentEventHandler
        docHandler = openDocs.Item(modDoc)
        openDocs.Remove(modDoc)
        modDoc = Nothing
        docHandler = Nothing
    End Sub
#End Region

#Region "Event Handlers"
    Function SldWorks_ActiveDocChangeNotify() As Integer
        'TODO: Add your implementation here
    End Function

    Function SldWorks_DocumentLoadNotify2(ByVal docTitle As String, ByVal docPath As String) As Integer

    End Function

    Function SldWorks_FileNewNotify2(ByVal newDoc As Object, ByVal doctype As Integer, ByVal templateName As String) As Integer
        AttachEventsToAllDocuments()
    End Function

    Function SldWorks_ActiveModelDocChangeNotify() As Integer
        'TODO: Add your implementation here
    End Function

    Function SldWorks_FileOpenPostNotify(ByVal FileName As String) As Integer
        AttachEventsToAllDocuments()
    End Function
#End Region

#Region "UI Callbacks"
    Sub CreateCube()

        'make sure we have a part open
        Dim partTemplate As String
        Dim model As ModelDoc2
        Dim featMan As FeatureManager

        partTemplate = iSwApp.GetUserPreferenceStringValue(swUserPreferenceStringValue_e.swDefaultTemplatePart)
        If Not partTemplate = "" Then
            model = iSwApp.NewDocument(partTemplate, swDwgPaperSizes_e.swDwgPaperA2size, 0.0, 0.0)

            model.InsertSketch2(True)
            model.SketchRectangle(0, 0, 0, 0.1, 0.1, 0.1, False)

            'Extrude the sketch
            featMan = model.FeatureManager
            featMan.FeatureExtrusion(True, _
                                      False, False, _
                                      swEndConditions_e.swEndCondBlind, swEndConditions_e.swEndCondBlind, _
                                      0.1, 0.0, _
                                      False, False, _
                                      False, False, _
                                      0.0, 0.0, _
                                      False, False, _
                                      False, False, _
                                      True, _
                                      False, False)
        Else
            System.Windows.Forms.MessageBox.Show("There is no part template available. Please check your options and make sure there is a part template selected, or select a new part template.")
        End If
    End Sub
    Sub ShowPMP()
        If Not ppage Is Nothing Then
            ppage.Show()
        End If
    End Sub

    Function PMPEnable() As Integer
        If iSwApp.ActiveDoc Is Nothing Then
            PMPEnable = 0
        Else
            PMPEnable = 1
        End If
    End Function

    Sub FlyoutCallback()

        Dim flyGroup As FlyoutGroup = iCmdMgr.GetFlyoutGroup(flyoutGroupID)
        flyGroup.RemoveAllCommandItems()

        flyGroup.AddCommandItem(System.DateTime.Now.ToLongTimeString(), "test", 0, "FlyoutCommandItem1", "FlyoutEnableCommandItem1")

    End Sub

    Function FlyoutEnable() As Integer
        Return 1
    End Function

    Sub FlyoutCommandItem1()
        iSwApp.SendMsgToUser("Flyout command 1")
    End Sub

    Function FlyoutEnableCommandItem1() As Integer
        Return 1
    End Function

  Sub CreateCylinder()
    Dim partTemplate As String
    Dim model As ModelDoc2
    Dim featMan As FeatureManager

    partTemplate = iSwApp.GetUserPreferenceStringValue _
       (swUserPreferenceStringValue_e.swDefaultTemplatePart)
    model = iSwApp.NewDocument(partTemplate, _
        swDwgPaperSizes_e.swDwgPaperA2size, 0.0, 0.0)

    model.SketchManager.InsertSketch(True)
    model.SketchManager.CreateCircleByRadius(0, 0, 0, 0.5)

    'Extrude the sketch
    featMan = model.FeatureManager
    featMan.FeatureExtrusion2(True, _
        False, False, _
        swEndConditions_e.swEndCondBlind, _
        swEndConditions_e.swEndCondBlind, _
        0.1, 0.0, _
        False, False, _
        False, False, _
        0.0, 0.0, _
        False, False, _
        False, False, _
        True, _
        False, False, _
        swStartConditions_e.swStartSketchPlane, _
        0.0, False)
  End Sub

  Sub RotateX()
    'Rotate the part in the plus X direction.
    Dim swModel As ModelDoc2
    swModel = iSwApp.ActiveDoc

    If Not swModel Is Nothing Then
      Dim i As Integer = 0
      While i <= 25
        swModel.ViewRotateplusx()
        i = i + 1
      End While
    End If
  End Sub

  Sub RotateY()
    'Rotate the part in the plus Y direction.
    Dim swModel As ModelDoc2
    swModel = iSwApp.ActiveDoc

    If Not swModel Is Nothing Then
      Dim i As Integer = 0
      While i <= 25
        swModel.ViewRotateplusy()
        i = i + 1
      End While
    End If
  End Sub

  Sub RotateZ()
    'Rotate the part in the plus Z direction.
    Dim swModel As ModelDoc2
    swModel = iSwApp.ActiveDoc

    If Not swModel Is Nothing Then
      Dim i As Integer = 0
      While i <= 25
        swModel.ViewRotateplusz()
        i = i + 1
      End While
    End If
  End Sub

#End Region

End Class


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

'A GUID is created to identify the Add-In Dll to Solidworks.
'the Guid is added to the registry under the SolidWorks Add-Ins registry settings
'ComVisible is the attribute that controls accessibility of this class to COM.
'SwAddin is a custom attribute defined in SolidWorksTools,
'that is used to hold values that will be added to the system registry
<Guid("258bd081-c0a4-4d22-a440-d30626916c3f")> _
    <ComVisible(True)> _
    <SwAddin( _
        Description:="CustomSWAddin description", _
        Title:="CustomSWAddin", _
        LoadAtStartup:=True _
        )> _
        Public Class SwAddin
  'Forces the CustomSwAddin Class to Implement
  'All of the methods exposed by the SwAddin object.
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
  'These two methods are defined on the SwAddIn interface, therefore they
  'MUST be implmented by this class or the project will not compile

  'this method is called by SolidWorks when the add-in is loaded.
    Function ConnectToSW(ByVal ThisSW As Object, ByVal Cookie As Integer) As Boolean Implements SolidWorks.Interop.swpublished.SwAddin.ConnectToSW
    'The add-in stores the SolidWorks application pointer in a global variable.
        iSwApp = ThisSW
    'The add-in stores the cookie in a global variable.
        addinID = Cookie

        ' Setup callbacks
    'The addin uses this method to send SolidWorks a pointer to itself.
    'It also sends the cookie back to SolidWorks for Identification purposes.
        iSwApp.SetAddinCallbackInfo(0, Me, addinID)

        ' Setup the Command Manager
    'The Command Manager is used to create custom menus and custom toolbars
    'in the SolidWorks user interface.
        iCmdMgr = iSwApp.GetCommandManager(Cookie)
        AddCommandMgr()

        'Setup the Event Handlers
        SwEventPtr = iSwApp
        openDocs = New Hashtable
    'The Event handlers are added (decribed in detail in lesson 11)
        AttachEventHandlers()

        'Setup Sample Property Manager
    'A custom PropertyManagerPage is created.
        AddPMP()
    'The add-in informs SolidWorks that this method was successful.
        ConnectToSW = True
    End Function

  'this method is called by SolidWorks when the add-in is unloaded.
  Function DisconnectFromSW() As Boolean _
  Implements SolidWorks.Interop.swpublished.SwAddin.DisconnectFromSW

        RemoveCommandMgr()
        RemovePMP()
        DetachEventHandlers()

        System.Runtime.InteropServices.Marshal.ReleaseComObject(iCmdMgr)
        iCmdMgr = Nothing
        System.Runtime.InteropServices.Marshal.ReleaseComObject(iSwApp)
        iSwApp = Nothing
    'The addin _must_ call GC.Collect() here in order
    'to retrieve all managed code pointers 
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
		Dim Title As String = "VB Addin"
		'Dim Title As String = "&Tools\VB Addin"	'Specifying the top menu allows you to specify the position within it
		Dim ToolTip As String = "VB Addin"


		Dim docTypes() As Integer = {swDocumentTypes_e.swDocASSEMBLY, _
																	 swDocumentTypes_e.swDocDRAWING, _
																	 swDocumentTypes_e.swDocPART}

		thisAssembly = System.Reflection.Assembly.GetAssembly(Me.GetType())

		Dim cmdGroupErr As Integer = 0
		Dim ignorePrevious As Boolean = False

		Dim registryIDs As Object = Nothing
		Dim getDataResult As Boolean = iCmdMgr.GetGroupDataFromRegistry _
																		(mainCmdGroupID, registryIDs)
		Dim knownIDs As Integer() = New Integer(1) {mainItemID1, mainItemID2}

		If getDataResult Then
			If Not CompareIDs(registryIDs, knownIDs) Then
				'if the IDs don't match, reset the commandGroup
				ignorePrevious = True
			End If
		End If
		cmdGroup = iCmdMgr.CreateCommandGroup2(mainCmdGroupID, Title, ToolTip, "", _
		 -1, ignorePrevious, cmdGroupErr)
		If cmdGroup Is Nothing Or thisAssembly Is Nothing Then
			Throw New NullReferenceException()
		End If

		cmdGroup.LargeIconList = iBmp.CreateFileFromResourceBitmap _
																("CustomSWAddin.ToolbarLarge.bmp", thisAssembly)
		cmdGroup.SmallIconList = iBmp.CreateFileFromResourceBitmap _
																("CustomSWAddin.ToolbarSmall.bmp", thisAssembly)
		cmdGroup.LargeMainIcon = iBmp.CreateFileFromResourceBitmap _
																("CustomSWAddin.MainIconLarge.bmp", thisAssembly)
		cmdGroup.SmallMainIcon = iBmp.CreateFileFromResourceBitmap _
																("CustomSWAddin.MainIconSmall.bmp", thisAssembly)

		Dim menuToolbarOption As Integer = swCommandItemType_e.swMenuItem Or _
																				swCommandItemType_e.swToolbarItem
		cmdIndex0 = cmdGroup.AddCommandItem2("CreateCube", -1, "Create a cube", _
												"Create cube", 0, "CreateCube", "CreateCubeEnable", _
												mainItemID1, menuToolbarOption)
		cmdIndex1 = cmdGroup.AddCommandItem2("Show PMP", -1, "Display sample property manager", _
									"Show PMP", 2, "ShowPMP", "PMPEnable", mainItemID2, menuToolbarOption)

		cmdGroup.HasToolbar = True
		cmdGroup.HasMenu = True
		cmdGroup.Activate()

		Dim flyGroup As FlyoutGroup
		flyGroup = iCmdMgr.CreateFlyoutGroup(flyoutGroupID, "Dynamic Flyout", "Flyout Tooltip", _
														"Flyout Hint", cmdGroup.SmallMainIcon, cmdGroup.LargeMainIcon, _
														cmdGroup.SmallIconList, cmdGroup.LargeIconList, _
														"FlyoutCallback", "FlyoutEnable")
		flyGroup.AddCommandItem("FlyoutCommand 1", "test", 0, "FlyoutCommandItem1", _
														"FlyoutEnableCommandItem1")
		flyGroup.FlyoutType = swCommandFlyoutStyle_e.swCommandFlyoutStyle_Simple


		For Each docType As Integer In docTypes
			Dim cmdTab As ICommandTab = iCmdMgr.GetCommandTab(docType, Title)
			Dim bResult As Boolean

			If Not cmdTab Is Nothing And Not getDataResult Or ignorePrevious Then
				'if tab exists, but we have ignored the registry info, re-create the tab.
				'Otherwise the ids won't matchup and the tab will be blank
				Dim res As Boolean = iCmdMgr.RemoveCommandTab(cmdTab)
				cmdTab = Nothing
			End If

			If cmdTab Is Nothing Then
				cmdTab = iCmdMgr.AddCommandTab(docType, Title)

				Dim cmdBox As CommandTabBox = cmdTab.AddCommandTabBox
				'Three commands are added to the first CommandTabBox, those commands are
				'the two commands whose indexes were returned by AddCommandItem and stored in
				'cmdIndex0 and cmdIndex1 and the third command is the command group toolbar
				Dim cmdIDs(3) As Integer
				Dim TextType(3) As Integer
				cmdIDs(0) = cmdGroup.CommandID(cmdIndex0)
				TextType(0) = swCommandTabButtonTextDisplay_e.swCommandTabButton_TextHorizontal
				cmdIDs(1) = cmdGroup.CommandID(cmdIndex1)
				TextType(1) = swCommandTabButtonTextDisplay_e.swCommandTabButton_TextHorizontal
				cmdIDs(2) = cmdGroup.ToolbarId
				TextType(2) = swCommandTabButtonTextDisplay_e.swCommandTabButton_TextHorizontal
				bResult = cmdBox.AddCommands(cmdIDs, TextType)

				Dim cmdBox1 As CommandTabBox = cmdTab.AddCommandTabBox()
				'One command is added to the second CommandTabBox; the command group toolbar
				ReDim cmdIDs(1)
				ReDim TextType(1)

				cmdIDs(0) = flyGroup.CmdID
				TextType(0) = swCommandTabButtonTextDisplay_e.swCommandTabButton_TextBelow
				bResult = cmdBox1.AddCommands(cmdIDs, TextType)

				'Add a separator to the second command tab box before the toolbar command
				cmdTab.AddSeparator(cmdBox1, cmdIDs(0))
			End If
		Next
		thisAssembly = Nothing

	End Sub


    Public Sub RemoveCommandMgr()
        Try
           iBmp.Dispose()
           iCmdMgr.RemoveCommandGroup(mainCmdGroupID)
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
        Dim docHandler As DocumentEventHandler = _
openDocs(modDoc)
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
    'Get the default part template
    partTemplate = iSwApp.GetUserPreferenceStringValue _
            (swUserPreferenceStringValue_e.swDefaultTemplatePart)
        If Not partTemplate = "" Then
      'Create a new document
      model = iSwApp.NewDocument(partTemplate, _
          swDwgPaperSizes_e.swDwgPaperA2size, 0.0, 0.0)

            model.InsertSketch2(True)
            model.SketchRectangle(0, 0, 0, 0.1, 0.1, 0.1, False)

            'Extrude the sketch
            featMan = model.FeatureManager
            featMan.FeatureExtrusion(True, _
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
                                      False, False)
        Else
      System.Windows.Forms.MessageBox.Show _
          ("There is no part template available. " + _
           "Please check your options and make sure there is a " + _
           "part template selected, or select a new part template.")
        End If
    End Sub
  Function CreateCubeEnable() As Integer
    CreateCubeEnable = 1
  End Function

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


#End Region

End Class


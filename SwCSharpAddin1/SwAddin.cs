using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;
using SolidWorks.Interop.swconst;
using SolidWorksTools;
using SolidWorksTools.File;

using FSharp.SolidWorks;

namespace SwCSharpAddin1
{
    [ComVisible(true)]
    [Guid("43f85157-13ec-476b-a57e-02fb5973e8bb")]
    [SwAddin(
            Description = "¥ﬁ §¿˚µƒSW≤Âº˛",
            Title = "CuiShengLi",
            LoadAtStartup = true
            )]
    public class SwAddin : ISwAddin
    {
        public const int cmdGroupID = 5;

        ISldWorks iSwApp;
        public ISldWorks SwApp { get { return this.iSwApp; } }

        ICommandManager iCmdMgr;
        public ICommandManager CmdMgr { get { return this.iCmdMgr; } }

        BitmapHandler iBmp;

        [ComRegisterFunction]
        public static void RegisterFunction(Type t)
        {
            SwAddinAttribute SWattr = null;
            var typ = typeof(SwAddin);

            foreach (System.Attribute attr in typ.GetCustomAttributes(false).Cast<System.Attribute>()) {
                if (attr is SwAddinAttribute) {
                    SWattr = attr as SwAddinAttribute;
                    break;
                }
            }

            try {
                var hklm = Microsoft.Win32.Registry.LocalMachine;
                var hkcu = Microsoft.Win32.Registry.CurrentUser;

                var keyname = "SOFTWARE\\SolidWorks\\Addins\\{" + t.GUID.ToString() + "}";
                var addinkey = hklm.CreateSubKey(keyname);
                addinkey.SetValue(null, 0);

                addinkey.SetValue("Description", SWattr.Description);
                addinkey.SetValue("Title", SWattr.Title);

                keyname = "Software\\SolidWorks\\AddInsStartup\\{" + t.GUID.ToString() + "}";
                addinkey = hkcu.CreateSubKey(keyname);
                addinkey.SetValue(null, Convert.ToInt32(SWattr.LoadAtStartup), Microsoft.Win32.RegistryValueKind.DWord);
            }
            catch (System.NullReferenceException nl) {
                //Console.WriteLine("There was a problem registering this dll: SWattr is null. \n\"" + nl.Message + "\"");
                System.Windows.Forms.MessageBox.Show("There was a problem registering this dll: SWattr is null.\n\"" + nl.Message + "\"");
            }
            catch (System.Exception e) {
                //Console.WriteLine(e.Message);
                System.Windows.Forms.MessageBox.Show("There was a problem registering the function: \n\"" + e.Message + "\"");
            }
        }

        [ComUnregisterFunction]
        public static void UnregisterFunction(Type t)
        {
            try {
                var hklm = Microsoft.Win32.Registry.LocalMachine;
                var hkcu = Microsoft.Win32.Registry.CurrentUser;

                var keyname = "SOFTWARE\\SolidWorks\\Addins\\{" + t.GUID.ToString() + "}";
                hklm.DeleteSubKey(keyname);

                keyname = "Software\\SolidWorks\\AddInsStartup\\{" + t.GUID.ToString() + "}";
                hkcu.DeleteSubKey(keyname);
            }
            catch (System.NullReferenceException nl) {
                //Console.WriteLine("There was a problem unregistering this dll: " + nl.Message);
                System.Windows.Forms.MessageBox.Show("There was a problem unregistering this dll: \n\"" + nl.Message + "\"");
            }
            catch (System.Exception e) {
                //Console.WriteLine("There was a problem unregistering this dll: " + e.Message);
                System.Windows.Forms.MessageBox.Show("There was a problem unregistering this dll: \n\"" + e.Message + "\"");
            }
        }

        public bool ConnectToSW(object ThisSW, int cookie)
        {
            this.iSwApp = (ISldWorks)ThisSW;
            this.iSwApp.SetAddinCallbackInfo(0, this, cookie);

            this.iCmdMgr = this.iSwApp.GetCommandManager(cookie);
            this.AddCommandMgr();

            return true;
        }

        public bool DisconnectFromSW()
        {
            this.RemoveCommandMgr();

            Marshal.ReleaseComObject(this.iCmdMgr);
            this.iBmp.Dispose();
            Marshal.ReleaseComObject(this.iSwApp);

            //The addin _must_ call GC.Collect() here in order to retrieve all managed code pointers 
            GC.Collect();
            GC.WaitForPendingFinalizers();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            return true;
        }

        public void AddCommandMgr()
        {
            // ’ºØ√¸¡ÓœÓƒø
            var cmds = new CommandItemCollection();
            //√¸¡Ó
            cmds.add(
                hintString: "Create a cube",
                toolTip: "Create cube",
                callbackFunction: nameof(CreateCube),
                enableMethod: nameof(this.Always),
                menuTBOption: swCommandItemType_e.swMenuItem
                );

            //√¸¡Ó
            cmds.add(
                hintString: "training1",
                toolTip: "µ⁄1’¬ æ¿˝",
                callbackFunction: nameof(this.Training1),
                enableMethod: nameof(this.Always),
                menuTBOption: swCommandItemType_e.swMenuItem
                );

            //√¸¡Ó
            cmds.add(
                hintString: "connect to sw",
                toolTip: "Õº2-7",
                callbackFunction: nameof(this.Training2_3),
                enableMethod: nameof(this.Always),
                menuTBOption: swCommandItemType_e.swMenuItem
                );

            //√¸¡Ó
            cmds.add(
                hintString: "new part",
                toolTip: "Õº2-12",
                callbackFunction: nameof(this.Training2_NewModel_Part),
                enableMethod: nameof(this.Always),
                menuTBOption: swCommandItemType_e.swMenuItem
                );

            //√¸¡Ó
            cmds.add(
                hintString: "new assy",
                toolTip: "Õº2-12",
                callbackFunction: nameof(this.Training2_NewModel_ASM),
                enableMethod: nameof(this.Always),
                menuTBOption: swCommandItemType_e.swMenuItem
                );

            //√¸¡Ó
            cmds.add(
                hintString: "new drw",
                toolTip: "Õº2-12",
                callbackFunction: nameof(this.Training2_NewModel_DRW),
                enableMethod: nameof(this.Always),
                menuTBOption: swCommandItemType_e.swMenuItem
                );

            //√¸¡Ó
            cmds.add(
                hintString: "New PartDoc",
                toolTip: "Õº2-18",
                callbackFunction: nameof(this.Training2_NewPartDoc),
                enableMethod: nameof(this.Always),
                menuTBOption: swCommandItemType_e.swMenuItem
                );

            //√¸¡Ó
            cmds.add(
                hintString: "New AssemblyDoc",
                toolTip: "Õº2-18",
                callbackFunction: nameof(this.Training2_NewAssemblyDoc),
                enableMethod: nameof(this.Always),
                menuTBOption: swCommandItemType_e.swMenuItem
                );

            //√¸¡Ó
            cmds.add(
                hintString: "New DrawingDoc",
                toolTip: "Õº2-18",
                callbackFunction: nameof(this.Training2_NewDrawingDoc),
                enableMethod: nameof(this.Always),
                menuTBOption: swCommandItemType_e.swMenuItem
                );

            //√¸¡Ó
            cmds.add(
                hintString: "New DrawingDoc",
                toolTip: "≤Ω÷Ë29~31",
                callbackFunction: nameof(this.Training2_existingDocs_connectToSolidWorks),
                enableMethod: nameof(this.Always),
                menuTBOption: swCommandItemType_e.swMenuItem
                );

            //√¸¡Ó
            cmds.add(
                hintString: "ToolbarAndCustomProperty",
                toolTip: "≤Ω÷Ë33~35",
                callbackFunction: nameof(this.Training2_existingDocs_ToolbarAndCustomProperty),
                enableMethod: nameof(this.Always),
                menuTBOption: swCommandItemType_e.swMenuItem
                );

            //√¸¡Ó
            cmds.add(
                hintString: "µ⁄2’¬≤Ω÷Ë36~38",
                toolTip: "",
                callbackFunction: nameof(this.Training2_existingDocs_MirrorPart),
                enableMethod: nameof(this.Always),
                menuTBOption: swCommandItemType_e.swMenuItem
                );

            //√¸¡Ó
            cmds.add(
                hintString: "µ⁄2’¬≤Ω÷Ë39~41",
                toolTip: "",
                callbackFunction: nameof(this.Training2_existingDocs_InsertCavity),
                enableMethod: nameof(this.Always),
                menuTBOption: swCommandItemType_e.swMenuItem
                );

            //√¸¡Ó
            cmds.add(
                hintString: "µ⁄2’¬≤Ω÷Ë42~44",
                toolTip: "",
                callbackFunction: nameof(this.Training2_existingDocs_CreateLayer),
                enableMethod: nameof(this.Always),
                menuTBOption: swCommandItemType_e.swMenuItem
                );

            // √¸¡ÓœÓƒøid
            var itemIDs = cmds.getUserIDs();

            var cmdGroup = CommandManagerUtils.createCommandGroup2(
                    userID: cmdGroupID,
                    title: "CuiShengLi",
                    toolTip: "CuiShengLi tool tip",
                    hint: "hint",
                    ignorePreviousVersion: CommandManagerUtils.ignorePreviousVersion(cmdGroupID, itemIDs, this.iCmdMgr),
                    cmdMgr: this.iCmdMgr
                );

            var callingAssy = Assembly.GetAssembly(this.GetType());
            this.iBmp = new BitmapHandler();

            cmdGroup.LargeMainIcon = this.iBmp.CreateFileFromResourceBitmap("SwCSharpAddin1.MainIconLarge.bmp", callingAssy);
            cmdGroup.SmallMainIcon = this.iBmp.CreateFileFromResourceBitmap("SwCSharpAddin1.MainIconSmall.bmp", callingAssy);
            cmdGroup.LargeIconList = this.iBmp.CreateFileFromResourceBitmap("SwCSharpAddin1.ToolbarLarge.bmp", callingAssy);
            cmdGroup.SmallIconList = this.iBmp.CreateFileFromResourceBitmap("SwCSharpAddin1.ToolbarSmall.bmp", callingAssy);

            cmds.update(cmdGroup);

            cmdGroup.HasMenu = true;
            cmdGroup.HasToolbar = false;
            cmdGroup.Activate();

        }

        public void RemoveCommandMgr()
        {
            this.iCmdMgr.RemoveCommandGroup(cmdGroupID);
        }

        public void CreateCube()
        {
            //iSwApp.SendMsgToUser("’‚ «’ºŒªµƒ√¸¡Ó");
            //SldWorksUtils.testPipeBom(iSwApp);
            //var clss = new Library1.RecursiveTraverseAssembly(iSwApp);
            //clss.Main();
            //SWRoutingLibUtils.ExportPipeData(iSwApp);
            //SldWorksUtils.readSWPipeLength(iSwApp);

            //trainingcylinder.main(iSwApp);
            //training2.cmdConnect(iSwApp);
            //training2.cmdNewModel_Part(iSwApp);

            //training4.testPartMat(iSwApp);
            //training4.rectangularExtrude(iSwApp);
            //training4.circularExtrude(iSwApp);
            //training4.testDrawCirc(iSwApp);
            //training4.testCircleContourRevolve(iSwApp);
            training5.testSelectFace(this.iSwApp);

            //SldWorksUtils.testCutLists(iSwApp);
            //SldWorksUtils.detectCutLists(iSwApp);
            //SldWorksUtils.setPartWeldment(iSwApp);

        }

        public void Training1()
        {
            training1.exec(this.iSwApp);
        }

        public void Training2_3()
        {
            training2.connectToSolidWorks(this.iSwApp);
        }

        public void Training2_NewModel_Part()
        {
            training2.NewModel_Part(this.iSwApp);
        }

        public void Training2_NewModel_ASM()
        {
            training2.NewModel_ASM(this.iSwApp);
        }

        public void Training2_NewModel_DRW()
        {
            training2.NewModel_DRW(this.iSwApp);
        }

        public void Training2_NewPartDoc()
        {
            training2.NewPartDoc(this.iSwApp);
        }

        public void Training2_NewAssemblyDoc()
        {
            training2.NewAssemblyDoc(this.iSwApp);
        }

        public void Training2_NewDrawingDoc()
        {
            training2.NewDrawingDoc(this.iSwApp);
        }

        public void Training2_existingDocs_connectToSolidWorks()
        {
            training2_existingDocs.connectToSolidWorks(this.iSwApp);
        }

        public void Training2_existingDocs_ToolbarAndCustomProperty()
        {
            training2_existingDocs.ToolbarAndCustomProperty(this.iSwApp);
        }

        public void Training2_existingDocs_MirrorPart()
        {
            training2_existingDocs.MirrorPart(this.iSwApp);
        }

        public void Training2_existingDocs_InsertCavity()
        {
            training2_existingDocs.InsertCavity(this.iSwApp);
        }

        public void Training2_existingDocs_CreateLayer()
        {
            training2_existingDocs.CreateLayer(this.iSwApp);
        }

        public bool Always() { return true; }
    }

}

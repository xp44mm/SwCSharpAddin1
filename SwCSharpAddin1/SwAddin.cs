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
            Description = "SwCSharpAddin1 description",
            Title = "SwCSharpAddin1",
            LoadAtStartup = true
            )]
    public class SwAddin : ISwAddin
    {
        public SwAddin()
        {
            this.iBmp = new BitmapHandler();
        }

        public const int cmdGroupID = 5;
        public const int cmdItemID1 = 0;
        public const int cmdItemID2 = 1;

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
            var thisAssembly = Assembly.GetAssembly(this.GetType());

            // 命令项目id
            var itemIDs = new HashSet<int> { cmdItemID1 };

            //ICommandGroup cmdGroup;
            var cmdGroup = CommandManagerUtils.createCommandGroup2(
                    userID: cmdGroupID,
                    title: "CuiShengLi",
                    toolTip: "CuiShengLi tool tip",
                    hint: "hint",
                    ignorePreviousVersion: CommandManagerUtils.ignorePreviousVersion(cmdGroupID, itemIDs, this.iCmdMgr),
                    cmdMgr: this.iCmdMgr
                );

            cmdGroup.LargeMainIcon = this.iBmp.CreateFileFromResourceBitmap("SwCSharpAddin1.MainIconLarge.bmp", thisAssembly);
            cmdGroup.SmallMainIcon = this.iBmp.CreateFileFromResourceBitmap("SwCSharpAddin1.MainIconSmall.bmp", thisAssembly);

            cmdGroup.LargeIconList = this.iBmp.CreateFileFromResourceBitmap("SwCSharpAddin1.ToolbarLarge.bmp", thisAssembly);
            cmdGroup.SmallIconList = this.iBmp.CreateFileFromResourceBitmap("SwCSharpAddin1.ToolbarSmall.bmp", thisAssembly);

            //命令0
            CommandGroupUtils.addCommandItem2(
                "CreateCube", "Create a cube", "Create cube", 0,
                nameof(CreateCube), nameof(this.EnalbeCreateCube), cmdItemID1, swCommandItemType_e.swMenuItem, cmdGroup);

            cmdGroup.HasToolbar = false;
            cmdGroup.HasMenu = true;
            cmdGroup.Activate();

        }

        public void RemoveCommandMgr()
        {
            this.iCmdMgr.RemoveCommandGroup(cmdGroupID);
        }

        public void CreateCube()
        {
            //iSwApp.SendMsgToUser("这是占位的命令");
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

        public bool EnalbeCreateCube() { return true; }
    }

}

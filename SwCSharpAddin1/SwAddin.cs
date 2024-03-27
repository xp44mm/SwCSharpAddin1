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
            Description = "崔胜利的SW插件",
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
            //收集命令项目
            var cmds = new CommandItemCollection();


            //命令
            cmds.add(
                hintOrTip: "附录D装配体遍历",
                callbackFunction: nameof(this.AppendexD_WatchAssemblyTraversal)
                );

            //命令
            cmds.add(
                hintOrTip: "箱子",
                callbackFunction: nameof(this.Salon_tank)
                );
            //命令
            cmds.add(
                hintOrTip: "提取箱子数据",
                callbackFunction: nameof(this.Salon_tankinfo)
                );
            //命令
            cmds.add(
                hintOrTip: "批量生成箱子",
                callbackFunction: nameof(this.Asia_generate)
                );

            //命令
            cmds.add(
                hintOrTip: "批量创建参考平面",
                callbackFunction: nameof(this.Asia_createPlanes)
                );

            ////命令
            //cmds.add(
            //    hintOrTip: "插入圆柱参考配合",
            //    callbackFunction: nameof(this.圆柱配合参考)
            //    );

            //命令
            cmds.add(
                hintOrTip: "库特征",
                callbackFunction: nameof(this.库特征)
                );

            //命令
            cmds.add(
                hintOrTip: "箱罐信息",
                callbackFunction: nameof(this.箱罐信息)
                );

            //命令
            cmds.add(
                hintOrTip: "生成管嘴的配合参考",
                callbackFunction: nameof(this.generateNozzleMateRefs)
                );

            //命令
            cmds.add(
                hintOrTip: "坐标系",
                callbackFunction: nameof(this.获取坐标系)
                );

            //命令
            cmds.add(
                hintOrTip: "收集所有坐标系并生成配合参考",
                callbackFunction: nameof(this.收集所有坐标系并生成配合参考)
                );

            //命令
            cmds.add(
                hintOrTip: "在所有配置隐藏选中的特征",
                callbackFunction: nameof(this.blankSelectedFeatures)
                );

            //命令
            cmds.add(
                hintOrTip: "unblank selectecd features",
                callbackFunction: nameof(this.显示特征)
                );

            //命令
            cmds.add(
                hintOrTip: "读取文件的自定义属性",
                callbackFunction: nameof(this.readCustomProps)
                );

            //命令
            cmds.add(
                hintOrTip: "写文件的自定义属性",
                callbackFunction: nameof(this.writeCustomProps)
                );

            //命令
            cmds.add(
                hintOrTip: "添加组件并坐标系配合",
                callbackFunction: nameof(this.addManyCompToCoordSys)
                );

            ////命令
            //cmds.add(
            //    hintOrTip: "管道材料明细表",
            //    callbackFunction: nameof(this.pipeBom)
            //    );

            //命令
            cmds.add(
                hintOrTip: "测试组件遍历",
                callbackFunction: nameof(this.ComponentEasy)
                );

            //命令
            cmds.add(
                hintOrTip: "读取组件类型",
                callbackFunction: nameof(this.ComponentTypeReader_main)
                );

            //命令
            cmds.add(
                hintOrTip: "输出管道js数据",
                callbackFunction: nameof(this.RouteWrapper)
                );

            //命令
            cmds.add(
                hintOrTip: "设置系统选项",
                callbackFunction: nameof(this.SystemOptionsSetting_main)
                );
            
            //命令
            cmds.add(
                hintOrTip: "注释示例",
                callbackFunction: nameof(this.CommentExample_main)
                );

            // *****命令组*****
            var cmdGroup = CommandManagerUtils.createCommandGroup2(
                    userID: cmdGroupID,
                    title: "CuiShengLi",
                    toolTip: "CuiShengLi tool tip",
                    hint: "hint",
                    ignorePreviousVersion: cmds.getUserIDs().SetEquals(CommandManagerUtils.getIDsFromRegistry(cmdGroupID, this.iCmdMgr)),
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


        public void PipeUtils_main()
        {
            //SWRoutingLibUtils.ExportPipeData(iSwApp);

            //var clss = new Library1.RecursiveTraverseAssembly(iSwApp);
            //clss.Main();

            PipeComponents.PipeUtils.main(this.iSwApp);
        }

        public void SystemOptionsSetting_main()
        {
            SystemOptionsSetting.main(this.iSwApp);
        }

        //public void pipeBom()
        //{
        //    PipeComponents.PipeUtils.pipebom(this.iSwApp);
        //}

        public void AppendexD_WatchAssemblyTraversal()
        {
            WatchAssemblyTraversal.main(this.iSwApp);
        }

        public void Salon_tank()
        {
            Salon.tank(this.iSwApp);
        }
        public void Salon_tankinfo()
        {
            Salon.tankinfo(this.iSwApp);
        }
        public void Asia_generate()
        {
            Asia.generate(this.iSwApp);
        }

        public void Asia_createPlanes()
        {
            Asia.createPlanes(this.iSwApp);
        }

        //public void 圆柱配合参考()
        //{
        //    Asia.preselect(this.iSwApp);
        //}

        public void 库特征()
        {
            Asia.getLibraryFeatureData(this.iSwApp);
        }

        public void generateNozzleMateRefs()
        {
            FacesWithFeature.generateNozzleMateRefs(this.iSwApp);
        }

        public void 箱罐信息()
        {
            FacesWithFeature.tankInfo(this.iSwApp);
        }

        public void 获取坐标系()
        {
            CoordinateSystem.getAllOfCoordinateSystems(this.iSwApp);
        }

        public void 收集所有坐标系并生成配合参考()
        {
            CoordinateSystem.collectCoordSysMateRefs(this.iSwApp);
        }

        public void blankSelectedFeatures()
        {
            BlankRefGeom.blankSelectedFeatures(this.iSwApp);
        }

        public void 显示特征()
        {
            BlankRefGeom.unblankSelectedFeatures(this.iSwApp);
        }

        public void readCustomProps()
        {
            CustomPropsApp.readCustomProps(this.iSwApp);
        }

        public void writeCustomProps()
        {
            CustomPropsApp.writeCustomProps(this.iSwApp);
        }

        public void addManyCompToCoordSys()
        {
            CoordinateSystem.addManyCompToCoordSys(this.iSwApp);
        }

        public void ComponentEasy()
        {
            ComponentEasyApp.main(this.iSwApp);
        }

        public void ComponentTypeReader_main()
        {
            ComponentTypeReader.main(this.iSwApp);
        }

        public void RouteWrapper()
        {
            RouteWrapperApp.main(this.iSwApp);
        }

        public void CommentExample_main()
        {
            CommentExample.main(this.iSwApp);
        }

        public bool Always() { return true; }
    }

}

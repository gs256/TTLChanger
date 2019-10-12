using System;
using System.IO;
using System.Windows.Shapes;
using IWshRuntimeLibrary;

namespace TTLChanger
{
    public static class AppMng
    {
        private const string ShortcutName = "TTL Changer.lnk";
        private const string IconName = "Icon.ico";

        public  static void CreateShortcut()
        {
            string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string linkPath = deskDir;
            string exePatn = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string curPath = Environment.CurrentDirectory;

            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\" + ShortcutName ;
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            //shortcut.Hotkey = "Ctrl+Shift+N";
            shortcut.IconLocation = curPath + @"\" + IconName;
            shortcut.TargetPath = exePatn;
            shortcut.Save();

        }

    }
}

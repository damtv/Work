using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using Работа.Views;

namespace Работа.Classes
{
    class Config_2
    {
        public string patchAppExe =
            System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        public struct configMainApp
        {
            public bool ch_1;
            public bool ch_3;
            public bool ch_5;
            public bool ch_6;
            public bool ch_2_1;
            public bool ch_2_2;
            public bool ch_2_3;
            public bool ch_2_4;
            public bool ch_2_5;
            public bool ch_2_6;
        }
        public configMainApp savDat = new configMainApp();
        Realty_info pm;

        public Realty_info Realty_info { get; }

        public Config_2(Realty_info demwin)
        {
            pm = demwin;
            try
            {
                FileSystem.FileOpen(1, patchAppExe + "\\demo_wpf.ini", OpenMode.Binary);
                ValueType tempState = new configMainApp();
                FileSystem.FileGet(1, ref tempState);
                savDat = ((configMainApp)tempState);
                pm.Check_1.IsChecked = savDat.ch_1;
                pm.Check_3.IsChecked = savDat.ch_3;
                pm.Check_5.IsChecked = savDat.ch_5;
                pm.Check_6.IsChecked = savDat.ch_6;
                pm.Check2_1.IsChecked = savDat.ch_2_1;
                pm.Check2_2.IsChecked = savDat.ch_2_2;
                pm.Check2_3.IsChecked = savDat.ch_2_3;
                pm.Check2_4.IsChecked = savDat.ch_2_4;
                pm.Check2_5.IsChecked = savDat.ch_2_5;
                pm.Check2_6.IsChecked = savDat.ch_2_6;
                FileSystem.FileClose(1);
            }
            catch { FileSystem.FileClose(1); }
        }

        public int SavConfig()
        {
            savDat.ch_1 = (bool)pm.Check_1.IsChecked;
            savDat.ch_3 = (bool)pm.Check_3.IsChecked;
            savDat.ch_5 = (bool)pm.Check_5.IsChecked;
            savDat.ch_6 = (bool)pm.Check_6.IsChecked;
            savDat.ch_2_1 = (bool)pm.Check2_1.IsChecked;
            savDat.ch_2_2 = (bool)pm.Check2_2.IsChecked;
            savDat.ch_2_3 = (bool)pm.Check2_3.IsChecked;
            savDat.ch_2_4 = (bool)pm.Check2_4.IsChecked;
            savDat.ch_2_5 = (bool)pm.Check2_5.IsChecked;
            savDat.ch_2_6 = (bool)pm.Check2_6.IsChecked;
            FileSystem.FileOpen(1, patchAppExe + "\\demo_wpf.ini", OpenMode.Random);
            FileSystem.FilePut(1, savDat);
            FileSystem.Seek(1, 1);
            FileSystem.FileClose(1);
            return 0;
        }
    
    }
}

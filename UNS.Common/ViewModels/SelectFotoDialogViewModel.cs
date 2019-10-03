using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.ComponentModel;
using System.Collections.Generic;
using UNS.Common;
using UNS.Common.Operators;
using UNS.Common.Views;
using System.IO;
using System.Linq;

namespace UNS.Common.ViewModels
{
    [POCOViewModel]
    public class SelectFotoDialogViewModel
    {
        #region Constructors
        public SelectFotoDialogViewModel(IEnumerable<string> unius,DirectoryInfo sourceDir):base()
        { UNIUs = unius.ToList();
            SourceDir = sourceDir;
        }
        public SelectFotoDialogViewModel():base() { }

        public static SelectFotoDialogViewModel Create(IEnumerable<string> unius, DirectoryInfo sourceDir)
        {
            return ViewModelSource.Create(() => new SelectFotoDialogViewModel(unius,sourceDir));
        }
        #endregion
        #region Properties
        public bool InstallationFolder { get; set; }
        public bool UnInstallationFolder { get; set; }
        public bool LightFolder { get; set; }
        public bool RepairsFolder { get; set; }
        public bool ConnectionFolder { get; set; }
        public virtual string ResultPath { get; set; }
        public bool RenameToSubdirs { get; set; } = true;
        public bool CopyToSubdirs { get; set; } = true;
        public bool OverlayText { get; set; } = true;
        protected virtual IFolderBrowserDialogService FolderBrowserDialogService { get { return this.GetService<IFolderBrowserDialogService>(); } }
        public virtual ICurrentWindowService WindowService { get { return null; } }
        public ISplashScreenService splashScreenService { get { return this.GetService<ISplashScreenService>(); } }
        public List<string> UNIUs { get; set; }
        public DirectoryInfo SourceDir { get; private set; }
        #endregion
        #region PropertyChanged
        public void OnResultPathChanged(string oldValue)
        {
            
        }
        #endregion
        #region Commands        
        [Command]
        public void ShowDialog()
        {
            if (FolderBrowserDialogService.ShowDialog())
                ResultPath = FolderBrowserDialogService.ResultPath;
        }
        public virtual bool CanShowDialog()
        { return true; }
        [Command]
        public virtual void Copy()
        {           
            var ii = new ImageOperator();
            var destinationDir = new DirectoryInfo(ResultPath);
                var dirList = new List<string>();
                if (UnInstallationFolder) dirList.Add("Фото_демонтажа");
                if (InstallationFolder) dirList.Add("Фото_монтажа");
                if (ConnectionFolder) dirList.Add("Фото_подключения");
                if (RepairsFolder) dirList.Add("Фото_ремонта");
                if (LightFolder) dirList.Add("Фото_свет");
                WindowService.Hide();
                splashScreenService.ShowSplashScreen();
                ii.CopyByNumbers(SourceDir, destinationDir, UNIUs, dirList, RenameToSubdirs, CopyToSubdirs, OverlayText);
                splashScreenService.HideSplashScreen();
                WindowService.Close();           
        }
        public virtual bool CanCopy() { return !string.IsNullOrEmpty(ResultPath) && (UnInstallationFolder || InstallationFolder || RepairsFolder || LightFolder || ConnectionFolder) ? true : false; }
        #endregion
    }
}
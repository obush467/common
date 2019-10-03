using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.ComponentModel;
using System.Collections.Generic;
using UNS.Common;

namespace UNS.Dialogs.ViewModels
{
    [POCOViewModel]
    public class SelectFotoDialogViewModel
    {
        #region Properties
        public bool InstallationFolder { get; set; }
        public bool UnInstallationFolder { get; set; }
        public bool LightFolder { get; set; }
        public bool RepairsFolder { get; set; }
        public bool ConnectionFolder { get; set; }
        public virtual string ResultPath { get; set; }
        protected virtual IFolderBrowserDialogService FolderBrowserDialogService { get { return this.GetService<IFolderBrowserDialogService>(); } }
        public List<string> UNIUs { get; set; }
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
            var selectFoto = new SelectFotoDialogView();
            var destinationDir = new DirectoryInfo("C:\\Temp\\2");
            if ((bool)selectFoto.ShowDialog())
            {
                var dirList = new List<string>();
                if ((bool)selectFoto.PhotoUnInstallation) dirList.Add("Фото_демонтажа");
                if ((bool)selectFoto.PhotoInstallation) dirList.Add("Фото_монтажа");
                if ((bool)selectFoto.PhotoConnection) dirList.Add("Фото_подключения");
                if ((bool)selectFoto.PhotoRepairs) dirList.Add("Фото_ремонта");
                if ((bool)selectFoto.PhotoLight) dirList.Add("Фото_свет");
                ii.CopyByNumbers(DUFilesDir, destinationDir, UNIUs, dirList, true, false, true);
            }
        }
        public virtual bool CanCopy() { return !string.IsNullOrEmpty(ResultPath) ? true : false; }
        #endregion
    }
}
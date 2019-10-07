using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UNS.Common;
using UNS.Common.ViewModels;
using UNS.Common.Views;


namespace UnitTestCommon
{


    [TestClass]
    public class UNSViewsDialogTest
    {
        [TestMethod]
        public void PrePrintDialogTest()
        {
            PrePrintDialog view = new PrePrintDialog()
            {
                DataContext = new PrePrintDialogViewModel<FileItem>(
            new ObservableCollection<FileItem>(new List<FileItem>()
            {new FileItem(){ FileInfo=null,Pattern="111111"} }))
            };
            view.ShowDialog();
        }

    }
}


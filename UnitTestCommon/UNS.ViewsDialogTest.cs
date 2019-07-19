using UNS.Common;
using UNS.Common.Office;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using UNS.Models;
using UNS.ViewModels;
using UNS.Views.Dialogs;


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


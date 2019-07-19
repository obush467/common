using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNS.ViewModels
{

    public class PrePrintDialogViewModel<T> : ViewModelBase
    {
        #region Constructors
        public PrePrintDialogViewModel(IEnumerable<T> list)
        { PrintList = new ObservableCollection<T>(list); }
        #endregion
        #region Properties
        public ObservableCollection<T> PrintList { get; set; }
        public string Title { get; set; } = "";
        public PrinterSettings PrinterSettings { get; set;}
        #endregion
        #region Methods
        public void Print()
        { }
        #endregion
    }

}

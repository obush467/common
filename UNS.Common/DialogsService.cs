using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Common.ViewModels;
using UNS.Common.Views;

namespace UNS.Common
{
    public static class DialogsService
    {
        public static void SelectPhotoDialog(IEnumerable<string> UNIUs, DirectoryInfo DUFilesDir)
        {
            var selectFoto = SelectFotoDialogViewModel.Create(UNIUs, DUFilesDir);
            var d = new SelectFotoDialogView
            {
                DataContext = selectFoto
            };
            d.ShowDialog();
        } 
    }
}

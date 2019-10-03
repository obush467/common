using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Core;

namespace UNS.Common.Views
{
    /// <summary>
    /// Логика взаимодействия для SelectFotoDialog.xaml
    /// </summary>
    public partial class SelectFotoDialogView : ThemedWindow
    {
        private List<string> uNIUs;
        private DirectoryInfo dUFilesDir;

        public SelectFotoDialogView()
        {
            InitializeComponent();
        }

        public SelectFotoDialogView(List<string> uNIUs, DirectoryInfo dUFilesDir):base()
        {
            this.uNIUs = uNIUs;
            this.dUFilesDir = dUFilesDir;
        }

        private void BtnCopy_Click(object sender, RoutedEventArgs e)
        {
            //DialogResult = true;           
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;           
        }
    }
}

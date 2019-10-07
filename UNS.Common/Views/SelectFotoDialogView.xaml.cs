using DevExpress.Xpf.Core;
using System.Collections.Generic;
using System.IO;
using System.Windows;

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

        public SelectFotoDialogView(List<string> uNIUs, DirectoryInfo dUFilesDir) : base()
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

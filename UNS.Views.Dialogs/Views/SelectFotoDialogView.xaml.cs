using System;
using System.Collections.Generic;
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

namespace UNS.Dialogs.Views
{
    /// <summary>
    /// Логика взаимодействия для SelectFotoDialog.xaml
    /// </summary>
    public partial class SelectFotoDialogView : Window
    {
        public SelectFotoDialogView()
        {
            InitializeComponent();
        }

        private void BtnCopy_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        
       //public bool? PhotoInstallation { get { return chInstallation.IsChecked; } }
        //public bool? PhotoUnInstallation { get { return chUnInstallation.IsChecked; } }
        //public bool? PhotoRepairs { get { return chRepairs.IsChecked; } }
        //public bool? PhotoConnection { get { return chConnection.IsChecked; } }
        //public bool? PhotoLight { get { return chLight.IsChecked; } }
    }
}

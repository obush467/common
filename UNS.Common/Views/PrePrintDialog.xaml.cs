using System.Windows;

namespace UNS.Common.Views
{
    /// <summary>
    /// Логика взаимодействия для PrePrintDialog.xaml
    /// </summary>
    public partial class PrePrintDialog : Window
    {
        public PrePrintDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

    }
}

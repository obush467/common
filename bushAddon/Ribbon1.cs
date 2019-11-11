using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;

namespace bushAddon
{
    public partial class Ribbon1
    {


        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        { }

        private void Button_ToFias_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                foreach (Range r in Globals.ThisAddIn.Application.Selection as Range)
                {
                    // r.Value2 = Utility.AddressOperator.To_fias(r.Value); 
                }
            }
            catch
            { }
            finally
            {
            }
        }
        private void Button_CreateFolders_Click(object sender, RibbonControlEventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Globals.ThisAddIn.utilities.CreateDuFolders(folderBrowserDialog.SelectedPath);
            }
        }

        private void Button_CreateHyperlinks_Click(object sender, RibbonControlEventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Globals.ThisAddIn.utilities.CreateDuHyperlinks(folderBrowserDialog.SelectedPath);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_CreateLetter_Click(object sender, RibbonControlEventArgs e)
        {
            ((RibbonButton)sender).Enabled = false;
            Globals.ThisAddIn.utilities.CreateLetters();
            ((RibbonButton)sender).Enabled = true;
        }

        private void Button_UpdateByDB_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.utilities.UpdateByDB();
        }

        private void Button_PrintDislocations_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.utilities.PrintDislocations();
        }
        private void Button_PrintAkts_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.utilities.PrintAkts();
        }

        private void Button_PrintProdactionComplects_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.utilities.PrintProdactionComplects();
        }
        private void Button_ReplaceOwnerToPrim_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.utilities.ReplaceOwnerToPrim();
        }

        private void Button_UpdateBTI_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.utilities.BTIWallType();
        }

        private void Button_PassportCreate_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.utilities.CreatePassports();
        }

        private void Button_KLADR_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void Button_PassportPrint_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.utilities.PrintPassports();
        }

        private void Button_InstallationPassport_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.utilities.InstallationPassportsPrint();
        }

        private void BtnCopyPhotos_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.utilities.CopyFoto();
        }

        private void button_UpdateStatus_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.utilities.UpdateStatusInstallation();
        }

        private void button_UpdateUNOM_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.utilities.UpdateUNOM();
        }
    }
}
using System.Collections.Generic;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Windows.Forms;
using System.IO;

namespace bushAddon
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }
        protected void EnableCalculations(bool Enable)
        {
            foreach (Worksheet sh in Globals.ThisAddIn.Application.Sheets)
            {
                sh.EnableCalculation = Enable;
            }
        }
        private void Button1_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                Worksheet activeWorksheet = Globals.ThisAddIn.Application.ActiveSheet as Worksheet;
                EnableCalculations(false);
                Range r = Globals.ThisAddIn.Application.Selection as Range;
                List<string> words = new List<string>();
                words.Add("улица");
                words.Add("аллея");
                words.Add("бульвар");
                words.Add("проезд");
                words.Add("переулок");
                words.Add("проспект");
                words.Add("площадь");
                words.Add("шоссе");
                words.Add("тупик");
                foreach (Range r1 in r.Cells)
                { r1.Value2 = common.Strings.Shifter.Words_shift(r1.Value, words); }
            }
            catch
            { }
            finally
            {
                EnableCalculations(true);
            }
        }

        private void Button_CreateFolders_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                Worksheet activeWorksheet = Globals.ThisAddIn.Application.ActiveSheet as Worksheet;
                EnableCalculations(false);
                Range r = Globals.ThisAddIn.Application.Selection as Range;
                FolderBrowserDialog dirdialog = new FolderBrowserDialog();
                DialogResult dres = dirdialog.ShowDialog();
                DirectoryInfo dir = new DirectoryInfo(dirdialog.SelectedPath);
                foreach (Range r1 in r.Cells)
                {
                    if (dir.Exists)
                    {
                        activeWorksheet.Hyperlinks.Add(r1, dir.CreateSubdirectory(r1.Text).FullName);
                    }
                }
            }
            catch
            { }
            finally
            {
                EnableCalculations(true);
            }
        }

        
        private void Button_CreateLetter_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                Worksheet activeWorksheet = Globals.ThisAddIn.Application.ActiveSheet as Worksheet;
                EnableCalculations(false);
                Range r = Globals.ThisAddIn.Application.Selection as Range;
                FolderBrowserDialog dirdialog = new FolderBrowserDialog();
                DialogResult dres = dirdialog.ShowDialog();
                DirectoryInfo dir = new DirectoryInfo(dirdialog.SelectedPath);
                foreach (Range r1 in r.Cells)
                {
                    if (dir.Exists)
                    {
                        activeWorksheet.Hyperlinks.Add(r1, dir.CreateSubdirectory(r1.Text).FullName);
                    }
                }
            }
            catch
            { }
            finally
            {
                EnableCalculations(true);
            }

        }
    }
}

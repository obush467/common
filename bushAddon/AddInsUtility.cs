using bushAddon;
using common;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using UNS.Models.Entities;
using UNS.Models.Models;
using Utility;
using common.Interfaces;
using System.Windows.Forms;
using System.Threading.Tasks;
using UNS.Views.Dialogs;
using UNS.ViewModels;
using System.Collections.ObjectModel;
using UNS.ViewsModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

[ComVisible(true)]
public interface IAddInUtilities
{
    void ImportData();
    void PrintAkts(PrinterSettings printerSettings);
    void PrintDislocations(PrinterSettings printerSettings);
    void BTIWallType();
}

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class AddInUtilities : IAddInUtilities
{
    DirectoryInfo rootletters = new DirectoryInfo("\\\\NAS-D4\\integra\\Письма\\");
    DirectoryInfo templatesDir = new DirectoryInfo("\\\\NAS-D4\\integra\\Шаблоны\\");
    private string _lettersTemplate = "Адреса в письмо2.xltx";
    FileInfo lettersTemplate
    {
        get { return new FileInfo(Path.Combine(templatesDir.FullName, _lettersTemplate)); }
        set { _lettersTemplate = value.Name; }
    }
    public DirectoryInfo _DUFilesDir { get; set; } =
        (new DirectoryInfo("C:\\DU_Files\\")).Exists ?
            new DirectoryInfo("C:\\DU_Files\\") :
            new DirectoryInfo("\\\\NAS-D4\\integra\\DU_Files\\");
    // This method tries to write a string to cell A1 in the active worksheet.
    public void ImportData()
    {
        Worksheet activeWorksheet = Globals.ThisAddIn.Application.ActiveSheet as Worksheet;

        if (activeWorksheet != null)
        {
            Range range1 = activeWorksheet.get_Range("A1", System.Type.Missing);
            range1.Value2 = "This is my data";
        }
    }


    public void PrintDislocations(PrinterSettings printerSettings)
    {
        if (printerSettings == null) printerSettings = new PrinterSettings() { Copies = 1 };
        var printDialog = new PrePrintDialog();
        var printFiles = SelectFilesByNumbers<Dislocation>(
            SelectByPattern(),
            new List<PrintPattern>()
            {
                new PrintPattern()
                {
                    Pattern = "*дислокация*",
                    Copies = 1
                }
            });
        var printFilesPreview = printFiles.Select(s => new Dislocation()
        {
            UNIU = s.Pattern
        });

        printDialog.DataContext = new PrePrintDialogViewModel<Dislocation>(printFilesPreview) { Title = "Печать дислокаций" };

        if ((bool)printDialog.ShowDialog() && (bool)printDialog.DialogResult)
        {

            Print(printFiles);
        }
    }

    public void PrintAkts(PrinterSettings printerSettings)
    {
        Print(new List<PrintPattern>()
        {
            new PrintPattern()
            {
                Pattern = "*Акт_монтажа_заготовка*.pdf",
                Copies = 1
            }
        });
    }

    public void PrintProdactionComplects(PrinterSettings printerSettings)
    {
        Print(new List<PrintPattern>()
        {
            new PrintPattern()
            {
                Pattern = "*дислокация*",
                Copies = 1
            },
                        new PrintPattern()
            {
                Pattern = "*Акт_монтажа_заготовка*",
                Copies = 1
            }
        });
    }

    internal void CreateDuFolders(string directoryPath)
    {
        try
        {
            Worksheet activeWorksheet = Globals.ThisAddIn.Application.ActiveSheet as Worksheet;
            EnableCalculations(false);
            Range r = Globals.ThisAddIn.Application.Selection as Range;
            DirectoryInfo dir = new DirectoryInfo(directoryPath);
            foreach (Range r1 in r.Cells)
            {
                if (dir.Exists)
                {
                    try
                    {
                        DirectoryInfo dudir = dir.CreateSubdirectory(r1.Text);
                        dudir.CreateSubdirectory("Фото_монтажа");
                        dudir.CreateSubdirectory("Акты_монтажа");
                        activeWorksheet.Hyperlinks.Add(r1, dudir.FullName);
                    }
                    catch
                    { }
                }
            }
        }
        catch (Exception)
        { }
        finally
        {
            EnableCalculations(true);
        }
    }

    protected List<T> SelectFilesByNumbers<T>(IEnumerable<string> numbers, IEnumerable<PrintPattern> printPatterns)
    {
        var numberFiles = new List<T>();
        foreach (var number in numbers)
        {
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(_DUFilesDir.FullName, number));

            if (dir.Exists)
            {
                foreach (var pattern in printPatterns)
                {
                    var file = dir.GetFiles(pattern.Pattern).OrderByDescending(o => o.CreationTime).FirstOrDefault();
                    if (file != null && file.Exists)
                    { numberFiles.Add(new FileItem() { FileInfo = file, Pattern = number, PrinterSettings = pattern.PrinterSettings }); }
                    else
                    { numberFiles.Add(new FileItem() { FileInfo = file, Pattern = number, PrinterSettings = pattern.PrinterSettings }); }
                }
            }
            else
            {
                foreach (var pattern in printPatterns)
                    numberFiles.Add(new FileItem() { FileInfo = null, Pattern = number, PrinterSettings = pattern.PrinterSettings });
            }
        }
        return numberFiles;
    }

    public void Print(FileInfo file, PrinterSettings printerSettings)
    {
        if (file != null && file.Exists)
            switch (file.Extension)
            {
                case ".pdf":
                    (new PDF_Operator()).Print(file, printerSettings);
                    break;
                case ".ppt":
                    (new PPT_Operator()).Print(file, printerSettings);
                    break;
                case ".pptx":
                    (new PPT_Operator()).Print(file, printerSettings);
                    break;
                case ".doc":
                    (new Word_Operator()).Print(file, printerSettings);
                    break;
                case ".docx":
                    (new Word_Operator()).Print(file, printerSettings);
                    break;
            }
    }

    public void Print(List<FileItem> printFiles)
    {
        foreach (var printfile in printFiles)
        { Print(printfile.FileInfo, printfile.PrinterSettings); }
    }

    public void Print(IEnumerable<PrintPattern> printpatterns)
    {
        try
        {
            EnableCalculations(false);
            var findNuimbers = SelectByPattern();
            if (findNuimbers != null && findNuimbers.Any())
            {
                PrePrintDialog view = new PrePrintDialog()
                {
                    DataContext = new PrePrintDialogViewModel<FileItem>(
        new ObservableCollection<FileItem>()
                )
                };
                view.ShowDialog();
                foreach (var findNumber in findNuimbers)
                {
                    DirectoryInfo dir = new DirectoryInfo(Path.Combine(_DUFilesDir.FullName, findNumber));
                    if (dir.Exists)
                    {
                        foreach (var pattern in printpatterns)
                        {
                            var file = dir.GetFiles(pattern.Pattern).OrderByDescending(o => o.CreationTime).FirstOrDefault();
                            Print(file, pattern.PrinterSettings);
                        }
                    }
                }
            }
        }
        catch (Exception innere)
        { }
        finally
        {
            EnableCalculations(true);
        }

    }

    internal void CreateLetters()
    {
        var currentBookName = Path.GetFileNameWithoutExtension(Globals.ThisAddIn.Application.ActiveWorkbook.Name);
        try
        {
            Range firm = Globals.ThisAddIn.Application.Selection as Range;
            List<IntegraDUExcel> integraDUs = ReestrSheet();
            List<IntegraDUExcel> selected = (from row in integraDUs
                                             where row.HouseOwner != null &&
                                                   row.HouseOwner.ToString() == firm.Value2
                                             orderby row.AddressO, row.AddressH
                                             select row).ToList();
            if (selected != null && selected.Count > 0)
            {
                Workbook newWB = Globals.ThisAddIn.Application.Workbooks
                        .Add(lettersTemplate.FullName);
                for (int n = 0; n <= selected.Count - 1; n++)
                {
                    Range destRow = newWB.Sheets[1].Cells.Rows[n + 2];
                    destRow.Cells[1, 1].Value = n + 1;
                    destRow.Cells[1, 2].Value = selected[n].AddressO;
                    destRow.Cells[1, 3].Value = selected[n].AddressH;
                    destRow.Cells[1, 4].Value = selected[n].UNOM;
                    destRow.Cells[1, 5].Value = selected[n].UNIU;
                    if (selected[n].LetterOutNumber == null) selected[n].LetterOutNumber = "в работу";
                }
                var newpath = Path.Combine(rootletters.FullName, currentBookName, "На отправку", firm.Value2.Replace(@"\\", ":").Replace(@"""", "") + ".xlsx");
                newWB.SaveAs(newpath);
                newWB.Close();
                //var wordOp = new Word_Operator();
                var bookmInserter = new Hashtable();
                if (selected.FirstOrDefault().DirectorPosition != null)
                    bookmInserter.Add("ChiefPosition", selected.FirstOrDefault().DirectorPosition.ToString());
                if (selected.FirstOrDefault().Director != null)
                {
                    bookmInserter.Add("ChiefFullName", selected.FirstOrDefault().Director.ToString());
                    bookmInserter.Add("ChiefShortName", selected.FirstOrDefault().Director.ToString());
                }
                if (selected.FirstOrDefault().HouseOwner != null)
                    bookmInserter.Add("Organization", selected.FirstOrDefault().HouseOwner.ToString());
                //Word_Operator.CreateBookmarkedDocument(new FileInfo(Path.ChangeExtension(newpath, "docx")), (new FileInfo("\\\\NAS-D4\\integra\\Шаблоны\\Запрос1.dotx")), bookmInserter);
            }
        }
        catch (Exception innere)
        { }
        finally
        {
            EnableCalculations(true);
        }
    }

    public void BTIWallType()
    {
        using (UNSModel context = new UNSModel())
        {
            EnableCalculations(false);
            List<IntegraDUExcel> integraDUs = ReestrSheet();
            integraDUs.Remove(integraDUs[0]);
            List<IntegraDUExcel> hasUNOMs =
                (from integraDU in integraDUs
                 where integraDU.BTIwallType == null
                 select integraDU).ToList();
            foreach (IntegraDUExcel destRow in hasUNOMs)
            {
                try
                {
                    int unom = int.Parse(destRow.UNOM.ToString());
                    var query = new List<BTI2018_UNOM_Result>();// (from bti in context.BTI2018_UNOM(unom) select bti).ToList();
                    if (query.Any())
                    {
                        destRow.BTIwallType = query.FirstOrDefault().Material;
                        destRow.BTIdestination = query.FirstOrDefault().Purpose;
                    }
                }
                catch (Exception)
                { }
            }
            EnableCalculations(true);
        }
    }
    private List<IntegraDUExcel> ReestrSheet()
    {
        Worksheet WSSource = Globals.ThisAddIn.Application.Sheets["Реестр"];
        EnableCalculations(false);
        Globals.ThisAddIn.Application.CopyObjectsWithCells = true;
        UNS.Models.ExcelLoader _excelLoader = new UNS.Models.ExcelLoader(Globals.ThisAddIn.Application);
        _excelLoader.AttachRows(WSSource);
        return (from row in _excelLoader.Rows
                where row.UNIU != null &&
                      row.UNOM != null
                      && row.UNOM != null
                      && row.UNIU != null
                orderby row.AddressO, row.AddressH
                select row).ToList();
    }
    private List<IntegraHouses> HouseSheet()
    {
        Worksheet WSSource = Globals.ThisAddIn.Application.Sheets["Дома"];
        EnableCalculations(false);
        Globals.ThisAddIn.Application.CopyObjectsWithCells = true;
        UNS.Models.ExcelLoader _excelLoader = new UNS.Models.ExcelLoader(Globals.ThisAddIn.Application);
        _excelLoader.AttachHouses(WSSource);
        return (from row in _excelLoader.Houses
                where row.UNOM != null
                      && !string.IsNullOrEmpty(row.UNOM.ToString())
                orderby row.Address
                select row).ToList();
    }

    protected void EnableCalculations(bool Enable)
    {
        foreach (Worksheet sh in Globals.ThisAddIn.Application.Sheets)
        {
            sh.EnableCalculation = Enable;
        }
    }

    /// <summary>
    /// Создаёт список номеров ДУ из выделенно
    /// </summary>
    /// <returns></returns>
    public List<string> SelectByPattern()
    {
        Range selected = Globals.ThisAddIn.Application.Selection as Range;
        var result = new List<string>();
        try
        {
            foreach (Range range in selected)
            {
                var matchNumber = Regex.Match(((string)range.Value2).Trim(), "\\d{5}ДУ\\d{6}");
                if (matchNumber != null && matchNumber.Captures.Count > 0 && !range.EntireRow.Hidden)
                {
                    result.Add(matchNumber.Groups[0].Value);
                }
            }
        }
        catch (Exception error)
        {
#if DEBUG
            Logger.Log.Debug(error.Message);
#else
            Logger.Log.Error(error.Message);
#endif
        }
        return result;
    }

}
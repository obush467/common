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
using UNSData.Entities;
using UNSData.Models;
using Utility;

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
        Print(new List<PrintPattern>()
        {
            new PrintPattern()
            {
                Pattern = "*дислокация*",
                Copies = 1
            }
        }, printerSettings);

    }

    public void PrintAkts(PrinterSettings printerSettings)
    {
        Print(new List<PrintPattern>()
        {
            new PrintPattern()
            {
                Pattern = "*Акт_монтажа_заготовка*.pdf",
                Copies = 3
            }
        }, printerSettings);
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
                Copies = 3
            }
        }, printerSettings);
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

    public void Print(IEnumerable<PrintPattern> printpatterns, PrinterSettings printerSettings)
    {
        try
        {
            EnableCalculations(false);
            List<FileItem> dislocations = new List<FileItem>();
            var findNuimbers = SelectByPattern();
            if (findNuimbers != null && findNuimbers.Any())
            {
                foreach (string findNumber in findNuimbers)
                {
                    DirectoryInfo dir = new DirectoryInfo(Path.Combine(_DUFilesDir.FullName, findNumber));
                    if (dir.Exists)
                    {
                        foreach (var pattern in printpatterns)
                        {
                            var file = dir.GetFiles(pattern.Pattern).OrderByDescending(o => o.CreationTime).FirstOrDefault();
                            if (file != null && file.Exists)
                                switch (file.Extension)
                                {
                                    case ".pdf":
                                        printerSettings.Copies = pattern.Copies;
                                        (new PDF_Operator()).Print(file, printerSettings);
                                        break;
                                    case ".ppt":
                                        printerSettings.Copies = pattern.Copies;
                                        (new PPT_Operator()).Print(file, printerSettings);
                                        break;
                                    case ".pptx":
                                        printerSettings.Copies = pattern.Copies;
                                        (new PPT_Operator()).Print(file, printerSettings);
                                        break;
                                    case ".doc":
                                        printerSettings.Copies = pattern.Copies;
                                        (new Word_Operator()).Print(file, printerSettings);
                                        break;
                                    case ".docx":
                                        printerSettings.Copies = pattern.Copies;
                                        (new Word_Operator()).Print(file, printerSettings);
                                        break;
                                }
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
        UNSData.ExcelLoader _excelLoader = new UNSData.ExcelLoader(Globals.ThisAddIn.Application);
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
        UNSData.ExcelLoader _excelLoader = new UNSData.ExcelLoader(Globals.ThisAddIn.Application);
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
    internal class FileItem
    {
        public string Pattern { get; set; }
        public FileInfo FileInfo { get; set; }
        public string Status { get; set; }
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
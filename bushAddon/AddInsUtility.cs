using bushAddon;
using UNS.Common;
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
using UNS.Models;
using Utility;
using UNS.Common.Interfaces;
using System.Windows.Forms;
using System.Threading.Tasks;
using UNS.Views.Dialogs;
using UNS.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UNS.Common.Office;
using System.Globalization;

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
    FileInfo LettersTemplate
    {
        get { return new FileInfo(Path.Combine(templatesDir.FullName, _lettersTemplate)); }
        set { _lettersTemplate = value.Name; }
    }
    public DirectoryInfo DUFilesDir { get; set; } =
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
            foreach (var printFile in printFiles)
            { printFile.Print(); };
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
                        dudir.CreateSubdirectory("Фото_подключения");
                        dudir.CreateSubdirectory("Фото_демонтажа");
                        dudir.CreateSubdirectory("Фото_ремонта");
                        dudir.CreateSubdirectory("Фото_свет");
                        dudir.CreateSubdirectory("Акты_монтажа");
                        dudir.CreateSubdirectory("Фото_устранения_замечаний");
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

    internal object PrintPassport()
    {
        throw new NotImplementedException();
    }

    public void InstallationPassportPrint()
    {
        List<IntegraDUExcel> integraDUs = ReestrSheet();
        var UNIUs = SelectByPattern();         
        var templateName = Path.Combine(templatesDir.FullName, "Установка.xltx");
        Workbook newWB = Globals.ThisAddIn.Application.Workbooks
            .Add(templateName);
        int n = 1;
        foreach (var UNIU in UNIUs)
        {
            IntegraDUExcel row= (from integraDU in integraDUs
             where integraDU.UNIU.ToString() == UNIU
             select integraDU).FirstOrDefault();
            Range destRow = newWB.Sheets[1].Cells.Rows[n + 1];
            newWB.Sheets[1].Range("UNIU").Value = row.UNIU;// Уникальный номер
            newWB.Sheets[1].Range("DUType").Value = row.DUtype; //Тип ДУ
            newWB.Sheets[1].Range("AdmArea").Value = row.AdmArea; //Округ
            newWB.Sheets[1].Range("District").Value = row.District;// Район
            newWB.Sheets[1].Range("AddressObject").Value = row.AddressO;// Улица
            newWB.Sheets[1].Range("AddressHouse").Value = row.AddressH;// Номер дома
            newWB.Sheets[1].Range("ContentObject").Value = row.ContentO;// Информационное содержание - Улица
            newWB.Sheets[1].Range("ContentHouse").Value = row.ContentH;// Информационное содержание -Номер дома                                                                      
            newWB.Sheets[1].Range("WallType").Value = row.BTIwallType;// БТИ - Тип стен
            newWB.Sheets[1].Range("Purpose").Value = row.BTIdestination;// БТИ - Назначение
            newWB.Sheets[1].Range("HouseOwner").Value = row.HouseOwner;// Принадлежность
            newWB.Sheets[1].Range("Contacts").Value = row.Contacts;// Контактные данные
            DateTimeFormatInfo ddd = new DateTimeFormatInfo()
            {
                DateSeparator = "-",
                TimeSeparator = "-+"
            };           
            string filename = String.Join("_",UNIU,"задание_на_монтаж",DateTime.Now.ToString("yyyy-MM-dd-hh-mm",ddd));
            newWB.PrintOutEx();
            newWB.SaveAs(("Z:\\Для производства\\В печать\\" + filename + ".xlsx").Replace(@"\\", ":"));
        }

    }

    internal void CreateDuHyperlinks(string directoryPath)
    {
        try
        {
            Worksheet activeWorksheet = Globals.ThisAddIn.Application.ActiveSheet as Worksheet;
            EnableCalculations(false);
            Range r = Globals.ThisAddIn.Application.Selection as Range;
            DirectoryInfo dir = new DirectoryInfo(directoryPath);
            foreach (Range r1 in r.Cells)
            {
                try
                {
                    var path = Path.Combine(dir.FullName, r1.Text);
                    activeWorksheet.Hyperlinks.Add(r1, path);
                }
                catch
                { }
            }
        }
        catch (Exception)
        { }
        finally
        {
            EnableCalculations(true);
        }
    }
    protected List<T> SelectFilesByNumbers<T>(IEnumerable<string> numbers, IEnumerable<PrintPattern> printPatterns) where T : FileItem, new()
    {
        var numberFiles = new List<T>();
        foreach (var number in numbers)
        {
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(DUFilesDir.FullName, number));

            if (dir.Exists)
            {
                foreach (var pattern in printPatterns)
                {
                    var file = dir.GetFiles(pattern.Pattern).OrderByDescending(o => o.CreationTime).FirstOrDefault();
                    if (file != null && file.Exists)
                    { numberFiles.Add(new T() { FileInfo = file, Pattern = number, PrinterSettings = pattern.PrinterSettings }); }
                    else
                    { numberFiles.Add(new T() { FileInfo = file, Pattern = number, PrinterSettings = pattern.PrinterSettings }); }
                }
            }
            else
            {
                foreach (var pattern in printPatterns)
                    numberFiles.Add(new T() { FileInfo = null, Pattern = number, PrinterSettings = pattern.PrinterSettings });
            }
        }
        return numberFiles;
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
                    DataContext = new PrePrintDialogViewModel<FileItem>(new ObservableCollection<FileItem>())
                };
                view.ShowDialog();
                foreach (var findNumber in findNuimbers)
                {
                    DirectoryInfo dir = new DirectoryInfo(Path.Combine(DUFilesDir.FullName, findNumber));
                    if (dir.Exists)
                    {
                        foreach (var pattern in printpatterns)
                        {
                            var file = new FileItem() { FileInfo = dir.GetFiles(pattern.Pattern).OrderByDescending(o => o.CreationTime).FirstOrDefault(), PrinterSettings = pattern.PrinterSettings };
                            file.Print();
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

    internal void UpdateByDB()
    {
        using (UNSModel context = new UNSModel())
        {
            EnableCalculations(false);
            List<IntegraDUExcel> integraDUs = ReestrSheet();
            integraDUs.Remove(integraDUs[0]);
            List<IntegraDUExcel> hasUNOMs =
                (from integraDU in integraDUs
                 where integraDU.IntoProductionDate == null
                 //&& integraDU.CoordinationDate == null
                 //&& integraDU.LetterOutNumber == null
                 && integraDU.HouseOwner == null
                 select integraDU).ToList();

            foreach (IntegraDUExcel destRow in hasUNOMs)
            {
                try
                {
                    int unom = int.Parse(destRow.UNOM.ToString());
                    List<AddressOwnerFind_Result> AddressOwners = context.AddressOwnerFind(unom).ToList();
                    if (AddressOwners.Any())
                    {
                        AddressOwnerFind_Result AddressOwner = AddressOwners.Single();
                        if (AddressOwner.ShortName != null) destRow.HouseOwner = AddressOwner.ShortName;
                        if (AddressOwner.ChiefName != null) destRow.Director = AddressOwner.ChiefName;
                        if (AddressOwner.ChiefPosition != null) destRow.DirectorPosition = AddressOwner.ChiefPosition;
                        if (AddressOwner.Contacts != null) destRow.Contacts = AddressOwner.Contacts;
                    }
                }
                catch (FormatException)
                { }
                catch (InvalidOperationException ie)
                { }
                catch (Exception e1)
                { }
            }
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
                        .Add(LettersTemplate.FullName);
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

    internal void ReplaceOwnerToPrim()
    {
        using (UNSModel _context = new UNSModel())
        {
            EnableCalculations(false);
            List<IntegraDUExcel> integraDUs = ReestrSheet();
            integraDUs.Remove(integraDUs[0]);
            List<IntegraDUExcel> hasUNOMs =
                (from integraDU in integraDUs
                 where integraDU.IntoProductionDate == null
                 && integraDU.CoordinationDate == null
                 && integraDU.LetterOutNumber == null
                 && integraDU.HouseOwner != null
                 && integraDU.Contacts == null
                 select integraDU).ToList();
            foreach (IntegraDUExcel destRow in hasUNOMs)
            {
                int _unom = int.Parse(destRow.UNOM.ToString());
                if (destRow.Comment == null)
                {
                    destRow.Comment = destRow.HouseOwner;
                }
                else
                {
                    destRow.Comment = string.Join("; ", destRow.Comment, destRow.HouseOwner);
                }
                destRow.HouseOwner = null;
            }
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
    /// <summary>
    /// Создание технических паспортов в основной папке
    /// </summary>
    internal void CreatePassport()
    {
        using (var context = new UNSModel())
        {
            var UNIUs = SelectByPattern();
            ;
            foreach (var UNIU in UNIUs)
            {
                var integraDUExcelLayout = context.IntegraDUExcelLayouts.Where(w => w.UNIU == UNIU).FirstOrDefault();
                Hashtable hashtable = new Hashtable();
                if (integraDUExcelLayout.ContentObjectFullPath != null && integraDUExcelLayout.ContentHouseFullPath != null)
                {
                    hashtable.Add("obj1", new InsertedObject()
                    {
                        FromFile = new FileInfo(integraDUExcelLayout.ContentObjectFullPath),
                        Height = 80,
                        Wight = 150
                    });
                    hashtable.Add("obj2", new InsertedObject()
                    {
                        FromFile = new FileInfo(integraDUExcelLayout.ContentHouseFullPath),
                        Height = 80,
                        Wight = 150
                    });
                }
                else
                    if (integraDUExcelLayout.ContentObjectFullPath != null && integraDUExcelLayout.ContentHouseFullPath == null)
                {
                    hashtable.Add("obj1", new InsertedObject()
                    {
                        FromFile = new FileInfo(integraDUExcelLayout.ContentObjectFullPath),
                        Height = 80,
                        Wight = 150
                    });
                }
                else
                    if (integraDUExcelLayout.ContentObjectFullPath == null && integraDUExcelLayout.ContentHouseFullPath != null)

                    hashtable.Add("obj1", new InsertedObject()
                    {
                        FromFile = new FileInfo(integraDUExcelLayout.ContentHouseFullPath),
                        Height = 80,
                        Wight = 150
                    });

                hashtable.Add("UNIU", integraDUExcelLayout.UNIU);
                hashtable.Add("Okrug", integraDUExcelLayout.Okrug);
                hashtable.Add("District", integraDUExcelLayout.District);
                hashtable.Add("Address", string.Join(", ", integraDUExcelLayout.AddressObject, integraDUExcelLayout.AddressHouse));
                hashtable.Add("DUType", integraDUExcelLayout.DUType);
                hashtable.Add("date_of_manufacture", DateTime.Now.ToLongDateString());
                DirectoryInfo saveDir = new DirectoryInfo(Path.Combine(DUFilesDir.FullName, integraDUExcelLayout.UNIU));
                var newWordFileName = new FileInfo(Path.Combine(
                                            saveDir.FullName,
                                            Path.ChangeExtension(string.Join("_", integraDUExcelLayout.UNIU, "технический_паспорт", DateTime.Now.ToString("yyyyMMdd")),
                                        "docx")));
                // Passport_Word_Operator.CreateBookmarkedDocument(newWordFileName,
                //    new FileInfo("\\\\NAS-D4\\integra\\Шаблоны\\Приложение5_Технический_паспорт8.dotx"), hashtable);
                //Word_Operator.ExportToPDF(newWordFileName);
            }
        }
    }

    private List<IntegraDUExcel> ReestrSheet()
    {
        Worksheet WSSource = Globals.ThisAddIn.Application.Sheets["Реестр"];
        EnableCalculations(false);
        Globals.ThisAddIn.Application.CopyObjectsWithCells = true;
        ExcelLoader _excelLoader = new ExcelLoader(Globals.ThisAddIn.Application);
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
        ExcelLoader _excelLoader = new ExcelLoader(Globals.ThisAddIn.Application);
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
    /// Создаёт список номеров ДУ из выделенного диапазона Excel
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
            Logger.Logger.Debug(error.Message);
#else
            Logger.Logger.Error(error.Message);
#endif
        }
        return result;
    }
    public List<IntegraDU> ReestrSheet1()
    {
        Worksheet WSSource = Globals.ThisAddIn.Application.Sheets["Реестр"];
        EnableCalculations(false);
        Globals.ThisAddIn.Application.CopyObjectsWithCells = true;
        ExcelLoader _excelLoader = new ExcelLoader(Globals.ThisAddIn.Application);
        return _excelLoader.MapRows(WSSource);
    }


    public void CopyFoto()
    {
        var UNIUs = SelectByPattern();
    }
}
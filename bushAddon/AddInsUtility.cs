using AutoMapper;
using bushAddon;
using bushAddon.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using UNS.Common;
using UNS.Common.Entities;
using UNS.Common.ViewModels;
using UNS.Common.Views;
using UNS.Models;
using UNS.Models.Entities;
using UNS.Models.Mappers;
using Excel = Microsoft.Office.Interop.Excel;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class AddInUtilities : IAddInUtilities
{
    readonly DateTimeFormatInfo dateInFileNameFormat = new DateTimeFormatInfo()
    {
        DateSeparator = "-",
        TimeSeparator = "-+"
    };
    public IMapper Mapper = new MapperConfiguration(cfg => cfg.AddProfile<DUTechnicalCertificate_DUStages>()).CreateMapper();
    readonly DirectoryInfo rootletters = new DirectoryInfo("\\\\NAS-D4\\integra\\Письма\\");
    readonly DirectoryInfo templatesDir = new DirectoryInfo("\\\\NAS-D4\\integra\\Шаблоны\\");
    private string _lettersTemplate = "Адреса в письмо2.xltx";
    FileInfo LettersTemplate
    {
        get { return new FileInfo(Path.Combine(templatesDir.FullName, _lettersTemplate)); }
        set { _lettersTemplate = value.Name; }
    }
    public DirectoryInfo DUFilesDir { get; set; } =
        new DirectoryInfo("C:\\DU_Files\\").Exists ?
            new DirectoryInfo("C:\\DU_Files\\") :
            new DirectoryInfo("\\\\NAS-D4\\integra\\DU_Files\\");
    public void ImportData()
    {
        if (Globals.ThisAddIn.Application.ActiveSheet is Excel.Worksheet activeWorksheet)
        {
            Excel.Range range1 = activeWorksheet.get_Range("A1", System.Type.Missing);
            range1.Value2 = "This is my data";
        }
    }

    public void PrintDislocations()
    {
        Print(SelectFilesByPatterns(
                new List<PrintPattern>()
                {
                new PrintPattern()
                {
                    Pattern = "*дислокация*",
                    Copies = 1
                }
                }));
    }

    public void PrintPassports()
    {
        Print(SelectFilesByPatterns(
            new List<PrintPattern>()
            {
                new PrintPattern()
                {
                    Pattern = "*технический_паспорт*",
                    PrinterSettings = new PrinterSettings()
                    {
                            Copies = 1,
                            Duplex = Duplex.Vertical
                    }}}));
    }

    public void PrintAkts()
    {
        Print(SelectFilesByPatterns(new List<PrintPattern>()
        {
            new PrintPattern()
            {
                Pattern = "*Акт_монтажа_заготовка*.pdf",
                Copies = 1
            }
        }));
    }

    public void PrintProdactionComplects()
    {
        Print(SelectFilesByPatterns(new List<PrintPattern>()
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
        }));
    }

    internal void CreateDuFolders(string directoryPath)
    {
        try
        {
            Excel.Worksheet activeWorksheet = Globals.ThisAddIn.Application.ActiveSheet as Excel.Worksheet;
            EnableCalculations(false);
            Excel.Range r = Globals.ThisAddIn.Application.Selection as Excel.Range;
            DirectoryInfo dir = new DirectoryInfo(directoryPath);
            foreach (Excel.Range r1 in r.Cells)
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

    internal void Print(IEnumerable<FileItem> printItems)
    {
        try
        {
            EnableCalculations(false);
            var printDialog = new PrePrintDialog();
            var preview = printItems.Select(s => new { Номер = s.Pattern, Имя_файла = s.FileInfo.Name, Наличие = s.Status }).AsEnumerable();
            printDialog.DataContext = new PrePrintDialogViewModel<dynamic>(preview) { Title = "Печать" };
            if ((bool)printDialog.ShowDialog() && (bool)printDialog.DialogResult)
            {
                foreach (var printFile in printItems)
                { printFile.Print(); };
            }
        }
        catch (Exception ex)
        {
            Logger.Logger.Error(ex.Message);
        }
        finally
        {
            EnableCalculations(true);
        }
    }

    public IEnumerable<FileItem> SelectFilesByPatterns(IEnumerable<PrintPattern> printPatterns)
    {
        return SelectFilesByNumbers(SelectByPattern(), printPatterns);
    }

    public void InstallationPassportsPrint()
    {
        List<IntegraDUExcel> integraDUs = ReestrSheet();
        var UNIUs = SelectByPattern();
        foreach (var UNIU in UNIUs)
        {
            var newWB = InstallationPassportCreate(integraDUs, UNIU);
            if (newWB != null)
            {
                newWB.PrintOutEx();
                //string filename = String.Join("_", UNIU, "задание_на_монтаж", DateTime.Now.ToString("yyyy-MM-dd-hh-mm", dateInFileNameFormat)) + ".xlsx";                
                //newWB.SaveAs(Path.Combine(DUFilesDir.FullName, "Для производства", "В печать", filename).Replace(@"\\", ":"));
                newWB.Close(SaveChanges:false);
            }
        }
    }
    public Excel.Workbook InstallationPassportPrint(IEnumerable<IntegraDUExcel> integraDUExcels, string UNIU)
    {
        var ip = InstallationPassportCreate(integraDUExcels, UNIU);
        ip.PrintOutEx();
        return ip;
    }
    public Excel.Workbook InstallationPassportCreate(IEnumerable<IntegraDUExcel> integraDUExcels, string UNIU)
    {
       
        IntegraDUExcel row = (from integraDU in integraDUExcels
                              where integraDU.UNIU.ToString().Trim() == UNIU
                              select integraDU).FirstOrDefault();
        if (row != null)
        {
            var templateName = Path.Combine(templatesDir.FullName, "Установка.xltx");
            Excel.Workbook newWB = Globals.ThisAddIn.Application.Workbooks.Add(templateName);
            Excel.Range destRow = newWB.Sheets[1].Cells.Rows[2];
            newWB.Sheets[1].Range("UNIU").Value = row.UNIU;// Уникальный номер
            newWB.Sheets[1].Range("DUType").Value = row.DUtype; //Тип ДУ
            newWB.Sheets[1].Range("AdmArea").Value = row.AdmArea; //Округ
            newWB.Sheets[1].Range("District").Value = row.District;// Район
            newWB.Sheets[1].Range("AddressObject").Value = row.AddressObject;// Улица
            newWB.Sheets[1].Range("AddressHouse").Value = row.AddressHouse;// Номер дома
            newWB.Sheets[1].Range("ContentObject").Value = row.ContentObject;// Информационное содержание - Улица
            newWB.Sheets[1].Range("ContentHouse").Value = row.ContentHouse;// Информационное содержание -Номер дома                                                                      
            newWB.Sheets[1].Range("WallType").Value = row.BTIwallType;// БТИ - Тип стен
            newWB.Sheets[1].Range("Purpose").Value = row.BTIdestination;// БТИ - Назначение
            newWB.Sheets[1].Range("HouseOwner").Value = row.HouseOwner;// Принадлежность
            newWB.Sheets[1].Range("Contacts").Value = row.Contacts;// Контактные данные
            return newWB;
        }
        else return null;
    }
    internal void CreateDuHyperlinks(string directoryPath)
    {
        try
        {
            Excel.Worksheet activeWorksheet = Globals.ThisAddIn.Application.ActiveSheet as Excel.Worksheet;
            EnableCalculations(false);
            Excel.Range r = Globals.ThisAddIn.Application.Selection as Excel.Range;
            DirectoryInfo dir = new DirectoryInfo(directoryPath);
            foreach (Excel.Range r1 in r.Cells)
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
    protected List<FileItem> SelectFilesByNumbers(IEnumerable<string> numbers, IEnumerable<PrintPattern> printPatterns)
    {
        var numberFiles = new List<FileItem>();
        foreach (var number in numbers)
        {
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(DUFilesDir.FullName, number));
            if (dir.Exists)
            {
                foreach (var pattern in printPatterns)
                {
                    var file = dir.GetFiles(pattern.Pattern).OrderByDescending(o => o.CreationTime).FirstOrDefault();
                    if (file != null && file.Exists)
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

    internal void UpdateByDB()
    {
        using (UNSModel context = new UNSModel())
        {
            EnableCalculations(false);
            List<IntegraDUExcel> integraDUs = ReestrSheet();
            integraDUs.Remove(integraDUs[0]);
            var hasUNOMs =
                (from integraDU in integraDUs
                 join stage in context.IntegraDUStages
                 on integraDU.UNIU equals stage.UNIU
                 where integraDU.IntoProductionDate == null
                 //&& integraDU.CoordinationDate == null
                 //&& integraDU.LetterOutNumber == null
                 && integraDU.HouseOwner == null
                 select new { integraDU, stage.UNOM }).ToList();
            foreach (var destRow in hasUNOMs)
            {
                try
                {
                    int unom = int.Parse(destRow.UNOM.ToString());
                    List<AddressOwnerFind_Result> AddressOwners = context.AddressOwnerFind(unom).ToList();
                    if (AddressOwners.Any())
                    {
                        AddressOwnerFind_Result AddressOwner = AddressOwners.Single();
                        if (AddressOwner.ShortName != null) destRow.integraDU.HouseOwner = AddressOwner.ShortName;
                        if (AddressOwner.ChiefName != null) destRow.integraDU.Director = AddressOwner.ChiefName;
                        if (AddressOwner.ChiefPosition != null) destRow.integraDU.DirectorPosition = AddressOwner.ChiefPosition;
                        if (AddressOwner.Contacts != null) destRow.integraDU.Contacts = AddressOwner.Contacts;
                    }
                }
                catch (FormatException)
                { }
                catch (InvalidOperationException ie)
                { Logger.Logger.Error(ie.Message); }
                catch (Exception exception)
                { Logger.Logger.Error(exception.Message); }
            }
            EnableCalculations(true);
        }
    }

    internal void CreateLetters()
    {
        var currentBookName = Path.GetFileNameWithoutExtension(Globals.ThisAddIn.Application.ActiveWorkbook.Name);
        try
        {
            Excel.Range firm = Globals.ThisAddIn.Application.Selection as Excel.Range;
            using (var context = new UNSModel())
            {
                var fullselected = (from row in ReestrSheet()
                                    join unsrow in context.IntegraDUStages
                                    on row.UNIU equals unsrow.UNIU
                                    where row.HouseOwner != null &&
                                          row.HouseOwner.ToString() == firm.Value2
                                          && row.LetterOutData == null
                                          && row.LetterOutNumber == null
                                    orderby row.AddressObject, row.AddressHouse
                                    select new { row, unsrow }).ToList();
                var unsselected = fullselected.Select(s => s.unsrow);
                var selected = fullselected.Select(s => s.row);
                if (selected.Any())
                {
                    var currentDateLetterCount = context.SimplifiedLetters.Where(w => w.OutgoingDate == DateTime.Today).Count();
                    currentDateLetterCount++;
                    var selectedFirst = selected.FirstOrDefault();
                    var newLeller = new SimplifiedLetter()
                    {
                        OutgoingNumber = string.Join("/", DateTime.Now.ToString("yyyyMMdd"), currentDateLetterCount.ToString()),
                        OutgoingDate = DateTime.Now.Date,
                        Recipient = selectedFirst.HouseOwner?.ToString(),
                        RecipientDirectorName = selectedFirst.Director?.ToString(),
                        RecipientDirectorPosition = selectedFirst.DirectorPosition?.ToString(),
                        IntegraDUStages = unsselected.ToList()
                    };
                    Excel.Workbook newWB = Globals.ThisAddIn.Application.Workbooks
                            .Add(LettersTemplate.FullName);
                    for (int n = 0; n <= selected.Count() - 1; n++)
                    {
                        Excel.Range destRow = newWB.Sheets[1].Cells.Rows[n + 2];
                        destRow.Cells[1, 1].Value = n + 1;
                        destRow.Cells[1, 2].Value = selected.ElementAt(n).AddressObject;
                        destRow.Cells[1, 3].Value = selected.ElementAt(n).AddressHouse;
                        destRow.Cells[1, 4].Value = selected.ElementAt(n).UNOM;
                        destRow.Cells[1, 5].Value = selected.ElementAt(n).UNIU;
                        if (selected.ElementAt(n).LetterOutNumber == null) selected.ElementAt(n).LetterOutNumber = newLeller.OutgoingNumber;
                        if (selected.ElementAt(n).LetterOutData == null) selected.ElementAt(n).LetterOutData = newLeller.OutgoingDate;
                    }
                    var newpath = Path.Combine(rootletters.FullName, currentBookName, "На отправку", firm.Value2.Replace(@"\\", ":").Replace(@"""", ""));//+ ".xlsx"
                    newWB.SaveAs(newpath, Excel.XlFileFormat.xlOpenXMLWorkbook);
                    newWB.Close();
                    var oper = new QueryToHouseOwner_Word_Operator();
                    oper.Create(newpath,
                        newLeller.Recipient,
                        newLeller.RecipientDirectorPosition,
                        newLeller.RecipientDirectorName,
                        newLeller.OutgoingNumber,
                        newLeller.OutgoingDate
                        );
                    context.SimplifiedLetters.Add(newLeller);
                    context.SaveChanges();
                }
            }
        }
        catch (Exception innere)
        { Logger.Logger.Error(innere.Message); }
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
            var hasUNOMs =
                    (from integraDU in integraDUs
                        join stage in context.IntegraDU
                        on integraDU.UNIU equals stage.UNIU
                        select new {integraDU, stage }).ToList();
            foreach (var destRow in hasUNOMs)
            {
                try
                {
                        destRow.integraDU.BTIwallType =destRow.stage.BTIWallType;
                        destRow.integraDU.BTIdestination =destRow.stage.BTITarget;
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
    internal void CreatePassports()
    {
        using (var context = new UNSModel())
        {
            var UNIUs = SelectByPattern();
            var passportOperator = new Passport_Word_Operator();
            var newPassportContents = new List<DUTechnicalCertificate>();
            var idu = context.IntegraDUStages.Where(w => UNIUs.Contains(w.UNIU)).ToList().Select(s => Mapper.Map<IntegraDUStages, DUTechnicalCertificate>(s));
            foreach (var UNIU in UNIUs)
            {
                var newPassportContent = idu.Where(w => w.UNIU == UNIU).FirstOrDefault();
                newPassportContents.Add(newPassportContent);
            }
            passportOperator.Create(newPassportContents);
            context.DUTechnicalCertificates.AddRange(newPassportContents);
            context.SaveChanges();
        }
    }

    private List<IntegraDUExcel> ReestrSheet()
    {
        Excel.Worksheet WSSource = Globals.ThisAddIn.Application.Sheets["Реестр"];
        EnableCalculations(false);
        Globals.ThisAddIn.Application.CopyObjectsWithCells = true;
        ExcelLoader _excelLoader = new ExcelLoader(Globals.ThisAddIn.Application);
        _excelLoader.AttachRows(WSSource);
        return (from row in _excelLoader.Rows
                where row.UNIU != null
                orderby row.AddressObject, row.AddressHouse
                select row).ToList();
    }
    private List<UNS.Common.Entities.IntegraHouses> HouseSheet()
    {
        Excel.Worksheet WSSource = Globals.ThisAddIn.Application.Sheets["Дома"];
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
        foreach (Excel.Worksheet sh in Globals.ThisAddIn.Application.Sheets)
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
        Excel.Range selected = Globals.ThisAddIn.Application.Selection as Excel.Range;
        var result = new List<string>();
        try
        {
            foreach (Excel.Range range in selected)
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
        Excel.Worksheet WSSource = Globals.ThisAddIn.Application.Sheets["Реестр"];
        EnableCalculations(false);
        Globals.ThisAddIn.Application.CopyObjectsWithCells = true;
        ExcelLoader _excelLoader = new ExcelLoader(Globals.ThisAddIn.Application);
        return _excelLoader.MapRows(WSSource);
    }


    public void CopyFoto()
    {
        var UNIUs = SelectByPattern();
        DialogsService.SelectPhotoDialog(UNIUs, DUFilesDir);
    }

}

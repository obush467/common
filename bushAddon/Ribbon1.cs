using common;
using common.Office;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UNSData.Entities;
using UNSData.Models;

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
            catch
            { }
            finally
            {
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
                          && !string.IsNullOrEmpty(row.UNOM.ToString())
                          && !string.IsNullOrEmpty(row.UNIU.ToString())
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_CreateLetter_Click(object sender, RibbonControlEventArgs e)
        {
            Uri rootletters = new Uri("\\\\NAS-D4\\integra\\Письма\\");
            var currentBookName = Path.GetFileNameWithoutExtension(Globals.ThisAddIn.Application.ActiveWorkbook.Name);
            try
            {
                Range firm = Globals.ThisAddIn.Application.Selection as Range;
                List<IntegraDUExcel> selected = (from row in ReestrSheet()
                                                 where row.HouseOwner != null &&
                                                       row.HouseOwner.ToString() == firm.Value2
                                                 orderby row.AddressO, row.AddressH
                                                 select row).ToList();
                if (selected != null && selected.Count > 0)
                {
                    Workbook newWB = Globals.ThisAddIn.Application.Workbooks
                            .Add("C:\\Users\\Bushmakin\\Documents\\Настраиваемые шаблоны Office\\Адреса в письмо2.xltx");
                    for (int n = 0; n <= selected.Count - 1; n++)
                    {
                        Range destRow = newWB.Sheets[1].Cells.Rows[n + 2];
                        destRow.Cells[1, 1].Value = n + 1;
                        destRow.Cells[1, 2].Value = selected[n].AddressO;
                        destRow.Cells[1, 3].Value = selected[n].AddressH;
                        destRow.Cells[1, 4].Value = selected[n].UNOM;
                        destRow.Cells[1, 5].Value = selected[n].UNIU;
                        selected[n].LetterOutNumber = "в работу";
                    }
                    var newpath = Path.Combine(rootletters.LocalPath, currentBookName, "На отправку", firm.Value2.Replace(@"\\", ":").Replace(@"""", "") + ".xlsx");
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
            { MessageBox.Show(innere.Message); }
            finally
            {
                EnableCalculations(true);
            }



        }

        private void Button_SetUNOM_Click(object sender, RibbonControlEventArgs e)
        {
            List<IntegraDUExcel> integraDUs = ReestrSheet();
            integraDUs.Remove(integraDUs[0]);
            List<IntegraHouses> integraHouses = HouseSheet();
            integraHouses.Remove(integraHouses[0]);
            var hasUNOM =
                from integraHouse in integraHouses
                join integraDU in integraDUs
                on integraHouse.UNOM.ToString() equals integraDU.UNOM.ToString()
                where integraHouse.UNOM != null
                && integraHouse.UNOM.ToString() != "#Н/Д"
                && integraDU.Director == null
                && integraDU.HouseOwner != integraHouse.Organisation
                //&& integraDU.Director==null
                && integraDU.DirectorPosition == null
                select new
                {
                    integraHouse.UNOM,
                    integraHouse.Organisation,
                    integraHouse.Person,
                    integraHouse.PersonPosition,
                    integraHouse.Telephone,
                    integraHouse.Email,
                    integraDU
                };
            foreach (var h in hasUNOM.ToList())
            {
                h.integraDU.Director = h.Person;
                h.integraDU.DirectorPosition = h.PersonPosition;
                h.integraDU.HouseOwner = h.Organisation;
                h.integraDU.Contacts = string.Join(";", h.Telephone, h.Email);

            }
        }

        private void Button_toPrinting_Click(object sender, RibbonControlEventArgs e)
        {
            List<IntegraDUExcel> integraDUs = ReestrSheet();
            integraDUs.Remove(integraDUs[0]);
            List<IntegraDUExcel> hasUNOM =
                (from integraDU in integraDUs
                 where integraDU.IntoProductionDate == null
                 && integraDU.CoordinationDate != null
                 select integraDU).ToList();
            Workbook newWB = Globals.ThisAddIn.Application.Workbooks
                .Add("C:\\Users\\Bushmakin\\Documents\\Настраиваемые шаблоны Office\\В_производство.xltx");
            for (int n = 0; n <= hasUNOM.Count() - 1; n++)
            {
                Range destRow = newWB.Sheets[1].Cells.Rows[n + 2];
                destRow.Cells[1, 1].Value = n + 1;
                destRow.Cells[1, 2].Value = hasUNOM[n].DUtype; //Тип ДУ
                destRow.Cells[1, 3].Value = hasUNOM[n].AdmArea; //Округ
                destRow.Cells[1, 4].Value = hasUNOM[n].District;// Район
                destRow.Cells[1, 5].Value = hasUNOM[n].AddressO;// Улица
                destRow.Cells[1, 6].Value = hasUNOM[n].AddressH;// Номер дома
                destRow.Cells[1, 7].Value = hasUNOM[n].ContentO;// Информационное содержание - Улица
                destRow.Cells[1, 8].Value = hasUNOM[n].ContentH;// Информационное содержание -Номер дома
                //destRow.Cells[1, 9].Value = hasUNOM[n].UNOM;// UNOM
                destRow.Cells[1, 9].Value = hasUNOM[n].UNIU;// Уникальный номер
                destRow.Cells[1, 10].Value = hasUNOM[n].BTIwallType;// БТИ - Тип стен
                destRow.Cells[1, 11].Value = hasUNOM[n].BTIdestination;// БТИ - Назначение
                destRow.Cells[1, 12].Value = hasUNOM[n].WallType; // Тип стен
                destRow.Cells[1, 13].Value = hasUNOM[n].HouseOwner;// Принадлежность
                destRow.Cells[1, 14].Value = hasUNOM[n].Contacts;// Контактные данные
                destRow.Cells[1, 15].Value = hasUNOM[n].Director;// Руководитель
                destRow.Cells[1, 16].Value = hasUNOM[n].DirectorPosition;// Должность руководителя
                destRow.Cells[1, 17].Value = hasUNOM[n].LetterOutNumber;// номер исх письма
                destRow.Cells[1, 18].Value = hasUNOM[n].LetterOutData;// Дата исх письма
                destRow.Cells[1, 19].Value = hasUNOM[n].LetterIn;// Наличие ответа вход
                destRow.Cells[1, 20].Value = hasUNOM[n].CoordinationDate;// Дата согласования
                hasUNOM[n].IntoProductionDate = DateTime.Now;
                destRow.Cells[1, 21].Value = hasUNOM[n].IntoProductionDate;// Дата передачи в производство
            }
            DateTimeFormatInfo ddd = new DateTimeFormatInfo();
            ddd.DateSeparator = "-";
            ddd.TimeSeparator = "-+";
            ddd.PMDesignator = "обожравшись";
            string filename = DateTime.Now.ToString("yyyy-MM-dd-hh-mm в производство", ddd);
            newWB.SaveAs(("Z:\\Для производства\\В печать\\" + filename + ".xlsx").Replace(@"\\", ":"));


        }

        private void Button_UpdateByDB_Click(object sender, RibbonControlEventArgs e)
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
                        List<AddressOwnerFind_Result> AddressOwners;// = context.AddressOwnerFind(unom).ToList();
                        /*if (AddressOwners.Any())
                        {
                            AddressOwnerFind_Result AddressOwner = AddressOwners.First();
                            destRow.HouseOwner = AddressOwner.ShortName;
                            destRow.Director = AddressOwner.ChiefName;
                            destRow.DirectorPosition = AddressOwner.ChiefPosition;
                            destRow.Contacts = AddressOwner.Contacts;
                        }*/
                    }
                    catch (Exception e1)
                    { MessageBox.Show(e1.Message); }
                }
                EnableCalculations(true);
            }
        }

        private void Button_PrintDislocations_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                FolderBrowserDialog dirdialog = new FolderBrowserDialog();
                DialogResult dres = dirdialog.ShowDialog();
                DirectoryInfo rootdir = new DirectoryInfo(dirdialog.SelectedPath);
                if (dres == DialogResult.OK && rootdir.Exists)
                {
                    List<FileInfo> _dislocations = new List<FileInfo>();
                    Range selected = Globals.ThisAddIn.Application.Selection as Range;
                    if (selected != null && selected.Count > 0)
                    {
                        /* foreach (Range range in selected)
                         {
                             if (range.Hyperlinks != null && range.Hyperlinks.Count > 0)
                             { _dislocations.Add(new FileInfo(range.Hyperlinks[1].Address.ToString())); }
                         }*/
                        foreach (Range range in selected)
                        {
                            if (range.Value2 != null)
                            {
                                DirectoryInfo dir = new DirectoryInfo(Path.Combine(rootdir.FullName, range.Value2));
                                if (dir.Exists)
                                {
                                    FileInfo[] files = dir.GetFiles("*.ppt*");
                                    _dislocations.AddRange(files);
                                }
                            }
                        }
                        common.PPT_Operator.PrintPPT(_dislocations);
                    }
                }
            }
            catch (Exception innere)
            { MessageBox.Show(innere.Message); }
            finally
            {
                EnableCalculations(true);
            }

        }
        private void Button1_PrintDislocations_Click(object sender, RibbonControlEventArgs e)
        { Globals.ThisAddIn.utilities.PrintAkts(); }


        private void Button_ReplaceOwnerToPrim_Click(object sender, RibbonControlEventArgs e)
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

        private void Button_UpdateBTI_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.utilities.BTIWallType();
        }

        private void Button7_Click(object sender, RibbonControlEventArgs e)
        {
            using (var context = new UNSModel("data source=BUSHMAKIN;initial catalog=UNS;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
            {
                var integraDUExcelLayouts = context.IntegraDUExcelLayouts.OrderBy(o => o.Number).ToList();
                foreach (var integraDUExcelLayout in integraDUExcelLayouts)
                {
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
                    string rootdir = "\\\\bushmakin\\mssqlserver\\UNS\\DU_Files\\";
                    DirectoryInfo saveDir = new DirectoryInfo(new Uri(new Uri(rootdir), integraDUExcelLayout.UNIU).LocalPath);
                    if (!saveDir.Exists) saveDir.Create();
                    var newWordFileName = new FileInfo(Path.Combine(
                                                saveDir.FullName,
                                                Path.ChangeExtension(string.Join("_", integraDUExcelLayout.UNIU, "технический_паспорт", DateTime.Now.ToString("yyyyMMdd")),
                                            "docx")));
                    //Word_Operator.CreateBookmarkedDocument(newWordFileName,
                      //  new FileInfo("\\\\NAS-D4\\integra\\Шаблоны\\Приложение5_Технический_паспорт.dotx"), hashtable);
                    //Word_Operator.ExportToPDF(newWordFileName);
                }
            }

        }
    }
    }

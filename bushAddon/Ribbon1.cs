using System.Collections.Generic;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Linq;
using UNSentityes.Entityes;
using System;
using System.Globalization;
using UNSDataModel.Entities;

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
        private List<IntegraDUExcel> ReestrSheet()
        {
            Worksheet WSSource = Globals.ThisAddIn.Application.Sheets["Реестр"];
            EnableCalculations(false);
            Globals.ThisAddIn.Application.CopyObjectsWithCells = true;
            UNSentityes.ExcelLoader _excelLoader = new UNSentityes.ExcelLoader(Globals.ThisAddIn.Application);
            _excelLoader.AttachRows(WSSource);
            return (from row in _excelLoader.Rows
                    where row.UNIU != null &&
                          row.UNOM != null
                          && !string.IsNullOrEmpty(row.UNOM.ToString())
                          && !string.IsNullOrEmpty(row.UNIU.ToString())
                    orderby row.AddressO, row.AddressH
                    select row).ToList();
        }
        private List<integraHouses> HouseSheet()
        {
            Worksheet WSSource = Globals.ThisAddIn.Application.Sheets["Дома"];
            EnableCalculations(false);
            Globals.ThisAddIn.Application.CopyObjectsWithCells = true;
            UNSentityes.ExcelLoader _excelLoader = new UNSentityes.ExcelLoader(Globals.ThisAddIn.Application);
            _excelLoader.AttachHouses(WSSource);
            return (from row in _excelLoader.Houses
                    where row.UNOM != null
                          && !string.IsNullOrEmpty(row.UNOM.ToString())
                    orderby row.Address
                    select row).ToList();
        }
        private void Button_CreateLetter_Click(object sender, RibbonControlEventArgs e)
        {
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
                    newWB.SaveAs(("Z:\\Письма\\На отправку\\" + firm.Value2 + ".xlsx").Replace(@"\\", ":").Replace(@"""",""));
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
            List<integraHouses> integraHouses = HouseSheet();
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
            UNSEntities _context = new UNSEntities();
            EnableCalculations(false);
            List<IntegraDUExcel> _integraDUs = ReestrSheet();
            _integraDUs.Remove(_integraDUs[0]);
            List<IntegraDUExcel> _hasUNOMs =
                (from integraDU in _integraDUs
                 where integraDU.IntoProductionDate == null
                 && integraDU.CoordinationDate == null
                 && integraDU.LetterOutNumber ==null
                 select integraDU).ToList();
            List<AddressOwner_Result> _AddressOwners = 
                (from _addressOwner in _context.AddressOwner().ToList()
                join _hasUNOM in _hasUNOMs on _addressOwner.UNOM.ToString() equals _hasUNOM.UNOM.ToString()
                 select _addressOwner).ToList();
            _hasUNOMs =
                (from _integraDU in _hasUNOMs
                    join _addressOwner in _AddressOwners
                    on _integraDU.UNOM.ToString() equals _addressOwner.UNOM.ToString()
                 select _integraDU).ToList();
            foreach (IntegraDUExcel destRow in _hasUNOMs)
            {
                int _unom = int.Parse(destRow.UNOM.ToString()); 
                AddressOwner_Result _AddressOwner =
                    (from ao in _AddressOwners
                     where ao.UNOM == _unom
                     select ao).FirstOrDefault<AddressOwner_Result>();
                if (_AddressOwner != null)
                {
                    destRow.HouseOwner = _AddressOwner.ShortName;
                    destRow.Director = _AddressOwner.ChiefName;
                    destRow.DirectorPosition = _AddressOwner.ChiefPosition;
                    destRow.Contacts = _AddressOwner.Contacts;
                }
            }
            EnableCalculations(true);
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
    }
}

using UNS.Common;
using UNS.Common.Office;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNS.Models.Entities;
using UNS.Models;
using Utility;
namespace bushAddon
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        { }
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
                EnableCalculations(false);
                foreach (Range r in Globals.ThisAddIn.Application.Selection as Range)
                {
                    //r.Value2 = Utility.AddressOperator.To_fias(r.Value); 
                }
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
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                ((RibbonButton)e.Control).Enabled = false;
                Globals.ThisAddIn.utilities.CreateDuFolders(folderBrowserDialog.SelectedPath);
                ((RibbonButton)e.Control).Enabled = true;
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
                          && !string.IsNullOrEmpty(row.UNOM.ToString())
                          && !string.IsNullOrEmpty(row.UNIU.ToString())
                    orderby row.AddressO, row.AddressH
                    select row).ToList();
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
                        List<AddressOwnerFind_Result> AddressOwners = context.AddressOwnerFind(unom).ToList();
                        if (AddressOwners.Any())
                        {
                            AddressOwnerFind_Result AddressOwner = AddressOwners.Single();
                            destRow.HouseOwner = AddressOwner.ShortName;
                            destRow.Director = AddressOwner.ChiefName;
                            destRow.DirectorPosition = AddressOwner.ChiefPosition;
                            destRow.Contacts = AddressOwner.Contacts;
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

        private void Button_PrintDislocations_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.utilities.PrintDislocations(printDialogDUAddon.PrinterSettings);
        }
        private void Button_PrintAkts_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.utilities.PrintAkts(printDialogDUAddon.PrinterSettings);
        }

        private void Button_PrintProdactionComplects_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.utilities.PrintProdactionComplects(printDialogDUAddon.PrinterSettings);
        }
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
                    // Passport_Word_Operator.CreateBookmarkedDocument(newWordFileName,
                    //    new FileInfo("\\\\NAS-D4\\integra\\Шаблоны\\Приложение5_Технический_паспорт8.dotx"), hashtable);
                    //Word_Operator.ExportToPDF(newWordFileName);
                }
            }

        }

        private void Button2_Click(object sender, RibbonControlEventArgs e)
        {

        }
    }
}

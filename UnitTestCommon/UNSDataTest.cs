using common;
using common.Office;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNSData.Models;

namespace UnitTestCommon
{
    //[TestClass]
    public class UNSDataTest
    {
        [TestMethod]
        public void IntegraDUExcelLayoutsTest()
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
                   Word_Operator.CreateBookmarkedDocument(newWordFileName,
                        new FileInfo("\\\\NAS-D4\\integra\\Шаблоны\\Приложение5_Технический_паспорт.dotx"), hashtable);
                    Word_Operator.ExportToPDF(newWordFileName);
                }
            }

        }

    }
    }


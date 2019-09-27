using UNS.Common.Interfaces;
using UNS.Common.Office;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using UNS.Models.Entities;
using UNS.Common;

namespace UNS.Common
{
    public class Passport_Word_Operator : Word_Operator<PassportContent>
    {
        protected DirectoryInfo _templateDir;
        protected DirectoryInfo _rootdir;
        protected string TemplateFileName = "Приложение5_Технический_паспорт9.dotx";
        protected DateTime DefaultDate_of_manufacture = DateTime.MinValue;
        public Passport_Word_Operator(DirectoryInfo templateDir, DirectoryInfo rootdir)
        {
            _rootdir = rootdir;
            _templateDir = templateDir;
        }
        public Passport_Word_Operator() : this(new DirectoryInfo("\\\\NAS-D4\\integra\\Шаблоны\\"), new DirectoryInfo("\\\\NAS-D4\\integra\\DU_files\\"))
        { }

        public IEnumerable<FileInfo> Create(IEnumerable<PassportContent> passportContents)
        {
            var result = new List<FileInfo>();
            foreach (var b in passportContents)
                {
                    result.Add(Create(b.Number.ToString(), b.UNIU, b.Okrug, b.District, b.AddressObject, b.AddressHouse, b.DUType,b.DateManufacture));
                }
            return result;
        }

        public FileInfo Create(string Number, string UNIU, string Okrug, string District, string AddressObject, string AddressHouse, string DUType, DateTime date_of_manufacture)
        {           
            Hashtable hashtable = new Hashtable
            {
                { "UNIU", UNIU },
                { "Okrug", Okrug },
                { "District", District },
                { "Address", string.Join(", ", AddressObject, AddressHouse) },
                { "DUType", DUType },
                { "date_of_manufacture", date_of_manufacture.ToLongDateString() }
            };
            if (DUType == "ДУ-К-УД" || DUType == "ДУ-М-УД")
            {
                hashtable.Add("DUTypePrim1", "*");
                hashtable.Add("DUTypePrim2", "* типоисполнение ДУ: квартальный ДУ-К-УД состоит из ДУ-К-У и ДУ-К-Д; магистральный ДУ-М-УД состоит из ДУ-М-У и ДУ-М-Д");
            }
            DirectoryInfo saveDir = new DirectoryInfo(new Uri(new Uri(_rootdir.FullName), UNIU).LocalPath);
            if (!saveDir.Exists) saveDir.Create();
            var newWordFileName = Path.Combine(saveDir.FullName,string.Join("_", Number, UNIU, "технический_паспорт"));
            var saveFormats = new List<WdSaveFormat>
            {
                WdSaveFormat.wdFormatPDF
            };
            CreateBookmarkedDocument(newWordFileName,
                _templateDir.GetFiles(TemplateFileName).SingleOrDefault(), hashtable, saveFormats);
            return new FileInfo(newWordFileName);
        }
        public FileInfo Create(PassportContent passportContent)
        {
            Hashtable hashtable = new Hashtable
            {
                { "UNIU", passportContent.UNIU },
                { "Okrug", passportContent.Okrug },
                { "District", passportContent.District },
                { "Address", string.Join(", ", passportContent.AddressObject, passportContent.AddressHouse) },
                { "DUType", passportContent.DUType },
                { "date_of_manufacture", passportContent.DateManufacture.ToLongDateString() }
            };
            if (passportContent.ContentObjectFullPath != null && passportContent.ContentHouseFullPath != null)
            {
                var contentObjectFullPath = new FileInfo(passportContent.ContentObjectFullPath);
                hashtable.Add("obj1", new InsertedObject()
                {
                    FromFile = contentObjectFullPath,
                    Height = 70,
                    Wight = 150
                });
                var contentHouseFullPath = new FileInfo(passportContent.ContentHouseFullPath);
                hashtable.Add("obj2", new InsertedObject()
                {
                    FromFile = contentHouseFullPath,
                    Height = 70,
                    Wight = 150
                });
            }
            else
                if (passportContent.ContentObjectFullPath != null && passportContent.ContentHouseFullPath == null)
            {
                hashtable.Add("obj1", new InsertedObject()
                {
                    FromFile = new FileInfo(passportContent.ContentObjectFullPath),
                    Height = 70,
                    Wight = 150
                });
            }
            else
                if (passportContent.ContentObjectFullPath == null && passportContent.ContentHouseFullPath != null)

                hashtable.Add("obj1", new InsertedObject()
                {
                    FromFile = new FileInfo(passportContent.ContentHouseFullPath),
                    Height = 70,
                    Wight = 150
                });
            var schemeName = Path.Combine(_templateDir.FullName, "Схемы_в_тех_паспорт", passportContent.DUType + "_схема.png");
            hashtable.Add("lightScheme2", new InsertedObject()
            {
                FromFile = new FileInfo(schemeName),
                Height = 80,
                Wight = 150
            });
            hashtable.Add("lightScheme1", new InsertedObject()
            {
                FromFile = new FileInfo(Path.Combine(_templateDir.FullName, "Схемы_в_тех_паспорт", "схема_подключения_световой_арматуры.png")),
                Height = 80,
                Wight = 150
            });
            hashtable.Add("elScheme", new InsertedObject()
            {
                FromFile = new FileInfo(schemeName),
                Height = 80,
                Wight = 150
            });
            if (passportContent.DUType == "ДУ-К-УД" || passportContent.DUType == "ДУ-М-УД")
            {
                hashtable.Add("DUTypePrim1", "*");
                hashtable.Add("DUTypePrim2", "* типоисполнение ДУ: квартальный ДУ-К-УД состоит из ДУ-К-У и ДУ-К-Д; магистральный ДУ-М-УД состоит из ДУ-М-У и ДУ-М-Д");
            }
            CreateFunc rt = (x, y) => DUTypesTable_Creator.Create(x, passportContent.DUType);
            hashtable.Add("tableDU", rt);

            DirectoryInfo saveDir = new DirectoryInfo(new Uri(new Uri(_rootdir.FullName), passportContent.UNIU).LocalPath);
            if (!saveDir.Exists) saveDir.Create();
            var newWordFileName = Path.Combine(saveDir.FullName,string.Join("_", passportContent.UNIU, "технический_паспорт", DateTime.Now.ToString("yyyyMMdd")));

            var saveFormats = new List<WdSaveFormat>();
            saveFormats.Add(WdSaveFormat.wdFormatPDF);
            CreateBookmarkedDocument(newWordFileName,
                _templateDir.GetFiles("Приложение5_Технический_паспорт9.dotx").SingleOrDefault(), hashtable, saveFormats);
            return new FileInfo( newWordFileName);

        }

        public void Print(PassportContent passportContents)
        {
            throw new NotImplementedException();
        }

        public void Print(IEnumerable<PassportContent> passportContents)
        {
            foreach (PassportContent integraDUExcelLayout in passportContents)
                Print(integraDUExcelLayout);
        }

        public void Print(PassportContent document, PrinterSettings printerSettings)
        {
            throw new NotImplementedException();
        }

        public void Print(IEnumerable<PassportContent> document, PrinterSettings printerSettings)
        {
            throw new NotImplementedException();
        }

    }
}


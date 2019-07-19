using common.Interfaces;
using common.Office;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using UNS.Models.Entities;

namespace common
{
    public class Passport_Word_Operator : Word_Operator, IOutDocument<IntegraDUExcelLayout>
    {
        protected DirectoryInfo _templateDir;
        protected DirectoryInfo _rootdir;
        protected DateTime DefaultDate_of_manufacture = DateTime.MinValue;
        protected Word_Operator word_Operator = new Word_Operator();
        public Passport_Word_Operator(DirectoryInfo templateDir, DirectoryInfo rootdir)
        {
            _rootdir = rootdir;
            _templateDir = templateDir;
        }

        public Passport_Word_Operator() : this(new DirectoryInfo("\\\\NAS-D4\\integra\\Шаблоны\\"), new DirectoryInfo("\\\\NAS-D4\\integra\\DU_files\\"))
        { }
        public void Create(IEnumerable<IntegraDUExcelLayout> integraDUExcelLayouts)
        {
            foreach (var integraDUExcelLayout in integraDUExcelLayouts)
            {
                Create(integraDUExcelLayout);
            }
        }

        public void Create(IEnumerable<IntegraDUExcelLayout> integraDUExcelLayouts, IEnumerable<DateTime> days)
        {
            int counter = 0;
            int counterLength = 500;
            List<List<IntegraDUExcelLayout>> groupDays = integraDUExcelLayouts.GroupBy(_ => counter++ / counterLength).Select(v => v.ToList()).ToList();
            for (var n = 0; n < days.Count(); n++)
            {
                var day = days.ToArray()[n];
                var block = groupDays.ToArray()[n];
                foreach (var b in block)
                {
                    Create(b.Number.ToString(), b.UNIU, b.Okrug, b.District, b.AddressObject, b.AddressHouse, b.DUType, day);
                }
            }
        }

        public void Create(string Number, string UNIU, string Okrug, string District, string AddressObject, string AddressHouse, string DUType, DateTime date_of_manufacture)
        {
            var flist = new List<FileInfo>();
            Hashtable hashtable = new Hashtable();
            hashtable.Add("UNIU", UNIU);
            hashtable.Add("Okrug", Okrug);
            hashtable.Add("District", District);
            hashtable.Add("Address", string.Join(", ", AddressObject, AddressHouse));
            hashtable.Add("DUType", DUType);
            hashtable.Add("date_of_manufacture", date_of_manufacture.ToLongDateString());
            if (DUType == "ДУ-К-УД" || DUType == "ДУ-М-УД")
            {
                hashtable.Add("DUTypePrim1", "*");
                hashtable.Add("DUTypePrim2", "* типоисполнение ДУ: квартальный ДУ-К-УД состоит из ДУ-К-У и ДУ-К-Д; магистральный ДУ-М-УД состоит из ДУ-М-У и ДУ-М-Д");
            }
            DirectoryInfo saveDir = new DirectoryInfo(new Uri(new Uri(_rootdir.FullName), UNIU).LocalPath);
            if (!saveDir.Exists) saveDir.Create();
            var newWordFileName = new FileInfo(Path.Combine(
                                        saveDir.FullName,
                                        Path.ChangeExtension(string.Join("_", Number, UNIU, "технический_паспорт"/*, DateTime.Now.ToString("yyyyMMdd")*/),
                                    "docx")));

            var saveFormats = new List<WdSaveFormat>();
            saveFormats.Add(WdSaveFormat.wdFormatPDF);

            word_Operator.CreateBookmarkedDocument(newWordFileName,
                _templateDir.GetFiles("Приложение5_Технический_паспорт9.dotx").SingleOrDefault(), hashtable, saveFormats);
            flist.Add(newWordFileName);
        }
        public void Create(IntegraDUExcelLayout integraDUExcelLayout)
        {

            var flist = new List<FileInfo>();
            Hashtable hashtable = new Hashtable();
            hashtable.Add("UNIU", integraDUExcelLayout.UNIU);
            hashtable.Add("Okrug", integraDUExcelLayout.Okrug);
            hashtable.Add("District", integraDUExcelLayout.District);
            hashtable.Add("Address", string.Join(", ", integraDUExcelLayout.AddressObject, integraDUExcelLayout.AddressHouse));
            hashtable.Add("DUType", integraDUExcelLayout.DUType);
            var date_of_manufacture = DateTime.Now;
            hashtable.Add("date_of_manufacture", date_of_manufacture.ToLongDateString());
            if (integraDUExcelLayout.ContentObjectFullPath != null && integraDUExcelLayout.ContentHouseFullPath != null)
            {
                var contentObjectFullPath = new FileInfo(integraDUExcelLayout.ContentObjectFullPath);
                hashtable.Add("obj1", new InsertedObject()
                {
                    FromFile = contentObjectFullPath,
                    Height = 70,
                    Wight = 150
                });
                var contentHouseFullPath = new FileInfo(integraDUExcelLayout.ContentHouseFullPath);
                hashtable.Add("obj2", new InsertedObject()
                {
                    FromFile = contentHouseFullPath,
                    Height = 70,
                    Wight = 150
                });
            }
            else
                if (integraDUExcelLayout.ContentObjectFullPath != null && integraDUExcelLayout.ContentHouseFullPath == null)
            {
                hashtable.Add("obj1", new InsertedObject()
                {
                    FromFile = new FileInfo(integraDUExcelLayout.ContentObjectFullPath),
                    Height = 70,
                    Wight = 150
                });
            }
            else
                if (integraDUExcelLayout.ContentObjectFullPath == null && integraDUExcelLayout.ContentHouseFullPath != null)

                hashtable.Add("obj1", new InsertedObject()
                {
                    FromFile = new FileInfo(integraDUExcelLayout.ContentHouseFullPath),
                    Height = 70,
                    Wight = 150
                });
            var schemeName = Path.Combine(_templateDir.FullName, "Схемы_в_тех_паспорт", integraDUExcelLayout.DUType + "_схема.png");
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
            if (integraDUExcelLayout.DUType == "ДУ-К-УД" || integraDUExcelLayout.DUType == "ДУ-М-УД")
            {
                hashtable.Add("DUTypePrim1", "*");
                hashtable.Add("DUTypePrim2", "* типоисполнение ДУ: квартальный ДУ-К-УД состоит из ДУ-К-У и ДУ-К-Д; магистральный ДУ-М-УД состоит из ДУ-М-У и ДУ-М-Д");
            }
            CreateFunc rt = (x, y) => DUTypesTable_Creator.Create(x, integraDUExcelLayout.DUType);
            hashtable.Add("tableDU", rt);

            DirectoryInfo saveDir = new DirectoryInfo(new Uri(new Uri(_rootdir.FullName), integraDUExcelLayout.UNIU).LocalPath);
            if (!saveDir.Exists) saveDir.Create();
            var newWordFileName = new FileInfo(Path.Combine(
                                        saveDir.FullName,
                                        Path.ChangeExtension(string.Join("_", integraDUExcelLayout.UNIU, "технический_паспорт", DateTime.Now.ToString("yyyyMMdd")),
                                    "docx")));

            var saveFormats = new List<WdSaveFormat>();
            saveFormats.Add(WdSaveFormat.wdFormatPDF);
            (new Word_Operator()).CreateBookmarkedDocument(newWordFileName,
                _templateDir.GetFiles("Приложение5_Технический_паспорт9.dotx").SingleOrDefault(), hashtable);//, saveFormats);
            //flist.Add(newWordFileName);

        }

        public void Print(IntegraDUExcelLayout integraDUExcelLayout)
        {
            throw new NotImplementedException();
        }

        public void Print(IEnumerable<IntegraDUExcelLayout> integraDUExcelLayouts)
        {
            foreach (IntegraDUExcelLayout integraDUExcelLayout in integraDUExcelLayouts)
                Print(integraDUExcelLayout);
        }

        public void Print(IntegraDUExcelLayout document, short copies = 1)
        {
            throw new NotImplementedException();
        }

        public void Print(IEnumerable<IntegraDUExcelLayout> document, short copies = 1)
        {
            throw new NotImplementedException();
        }

        public void Print(IntegraDUExcelLayout document, PrinterSettings printerSettings)
        {
            throw new NotImplementedException();
        }

        public void Print(IEnumerable<IntegraDUExcelLayout> document, PrinterSettings printerSettings)
        {
            throw new NotImplementedException();
        }
    }
}


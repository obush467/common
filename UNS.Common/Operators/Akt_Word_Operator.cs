using UNS.Common.Interfaces;
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
    public class Akt_Word_Operator : Word_Operator<PassportContent>, IOutDocument<PassportContent>
    {
        protected static DirectoryInfo _templateDir = new DirectoryInfo("\\\\NAS-D4\\integra\\Шаблоны\\");
        protected static DirectoryInfo _rootdir = new DirectoryInfo("\\\\NAS-D4\\integra\\DU_Files\\");
       

        public Akt_Word_Operator(DirectoryInfo templateDir, DirectoryInfo rootdir)
        {
            _rootdir = rootdir;
            _templateDir = templateDir;
        }

        public Akt_Word_Operator() : this(_templateDir, _rootdir)
        { }
        public void Create(IEnumerable<PassportContent> akts)
        {
            foreach (PassportContent integraDUExcelLayout in akts)
            {
                Create(integraDUExcelLayout);
            }
        }

        public void Create(PassportContent integraDUExcelLayout)
        {
            var flist = new List<FileInfo>();
            Hashtable hashtable = new Hashtable();
            hashtable.Add("DU1", integraDUExcelLayout.UNIU);
            hashtable.Add("DU2", integraDUExcelLayout.UNIU);
            switch (integraDUExcelLayout.DUType)
            {
                case "ДУ-К-УД":
                    hashtable.Add("Scheme1", "2");
                    hashtable.Add("Scheme2", "2");
                    hashtable.Add("Power", "25,5");
                    break;
                case "ДУ-М-УД":
                    hashtable.Add("Scheme1", "2");
                    hashtable.Add("Scheme2", "2");
                    hashtable.Add("Power", "54,5");
                    break;
                case "ДУ-К-У":
                    hashtable.Add("Scheme1", "1");
                    hashtable.Add("Scheme2", "1");
                    hashtable.Add("Power", "21");
                    break;
                case "ДУ-К-С":
                    hashtable.Add("Scheme1", "1");
                    hashtable.Add("Scheme2", "1");
                    hashtable.Add("Power", "21");
                    break;
                case "ДУ-М-С":
                    hashtable.Add("Scheme1", "1");
                    hashtable.Add("Scheme2", "1");
                    hashtable.Add("Power", "48");
                    break;
                case "ДУ-М-У":
                    hashtable.Add("Scheme1", "1");
                    hashtable.Add("Scheme2", "1");
                    hashtable.Add("Power", "48");
                    break;
                case "ДУ-К-Д":
                    hashtable.Add("Scheme1", "1");
                    hashtable.Add("Scheme2", "1");
                    hashtable.Add("Power", "4,5");
                    break;
                case "ДУ-М-Д":
                    hashtable.Add("Scheme1", "1");
                    hashtable.Add("Scheme2", "1");
                    hashtable.Add("Power", "6,5");
                    break;
            }

            hashtable.Add("DUType", integraDUExcelLayout.DUType);
            DirectoryInfo saveDir = new DirectoryInfo(new Uri(new Uri(_rootdir.FullName), integraDUExcelLayout.UNIU).LocalPath);
            if (!saveDir.Exists) saveDir.Create();
            var newWordFileName = new FileInfo(Path.Combine(
                                        saveDir.FullName,
                                        Path.ChangeExtension(string.Join("_", integraDUExcelLayout.UNIU, "Акт_монтажа_заготовка"),
                                    "docx")));
            var saveFormats = new List<WdSaveFormat>();
            saveFormats.Add(WdSaveFormat.wdFormatPDF);
            CreateBookmarkedDocument(newWordFileName.FullName,
                _templateDir.GetFiles("прил_4_ЭЛЕКТРИКА.dotx").SingleOrDefault(), hashtable, saveFormats);
            flist.Add(newWordFileName);
        }

        public void Print(IEnumerable<PassportContent> akts)
        {
            foreach (var akt in akts)
            {
                Print(akt);
            }
        }

        private void Print(PassportContent akt)
        {
            throw new NotImplementedException();
        }

        public void Print(PassportContent document, short copies = 1)
        {
            throw new NotImplementedException();
        }

        public void Print(IEnumerable<PassportContent> document, short copies = 1)
        {
            throw new NotImplementedException();
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


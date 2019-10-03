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
using UNS.Common.Entities;

namespace UNS.Common
{
    public class QueryToHouseOwner_Word_Operator : Word_Operator<IntegraDUExcel>
    {
        protected DirectoryInfo _templateDir;
        
        protected string TemplateFileName = "Запрос1.dotx";
        protected DateTime DefaultDate_of_manufacture = DateTime.MinValue;
        public QueryToHouseOwner_Word_Operator(DirectoryInfo templateDir)
        {
            _templateDir = templateDir;
        }
        public QueryToHouseOwner_Word_Operator() : this(new DirectoryInfo("\\\\NAS-D4\\integra\\Шаблоны\\"))
        {        }

        public override IEnumerable<FileInfo> Create(IEnumerable<IntegraDUExcel> passportContents)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<FileInfo> Create(string baseFileName,string houseOwner, string directorPosition, string director, string outgoingDocumentNumber, DateTime? OutgoingDocumentDate)
        {    
            Hashtable hashtable = new Hashtable();
            if (directorPosition != null)
                hashtable.Add("ChiefPosition", directorPosition.ToString());
            if (director != null)
            {
                hashtable.Add("ChiefFullName", director.ToString());
                hashtable.Add("ChiefShortName", director.ToString());
            }
            if (houseOwner != null)
                hashtable.Add("Organization", houseOwner.ToString());
            if (outgoingDocumentNumber != null)
                hashtable.Add("LetterNumber", outgoingDocumentNumber);
                hashtable.Add("LetterDate", OutgoingDocumentDate!=null?((DateTime)OutgoingDocumentDate).ToShortDateString():null);
            DirectoryInfo saveDir = new FileInfo(baseFileName).Directory;
            if (!saveDir.Exists) saveDir.Create();           
            var saveFormats = new List<WdSaveFormat>
            {
                WdSaveFormat.wdFormatXMLDocument
            };
            return
                CreateBookmarkedDocument(
                    baseFileName,
                    _templateDir.GetFiles(TemplateFileName).SingleOrDefault(), 
                    hashtable, 
                    saveFormats);             
        }
        public override FileInfo Create(IntegraDUExcel passportContent)
        {
            throw new NotImplementedException();
        }

        public void Print(IntegraDUExcel passportContents)
        {
            throw new NotImplementedException();
        }

        public void Print(IEnumerable<IntegraDUExcel> passportContents)
        {
            foreach (IntegraDUExcel integraDUExcelLayout in passportContents)
                Print(integraDUExcelLayout);
        }

        public override void Print(IntegraDUExcel document, PrinterSettings printerSettings)
        {
            throw new NotImplementedException();
        }

        public override void Print(IEnumerable<IntegraDUExcel> document, PrinterSettings printerSettings)
        {
            throw new NotImplementedException();
        }

    }
}


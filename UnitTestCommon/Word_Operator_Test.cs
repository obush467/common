using UNS.Common;
using UNS.Common.Office;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.IO;
using Microsoft.Office.Interop.Word;
using UNS.Models.Entities;
using System.Collections.Generic;
using UNS.Models;
using System.Linq;
using UNS.Common.Operators;

namespace UnitTestCommon
{
    [TestClass]
    public class Word_Operator_Test
    {
        [TestMethod]
        public void CreatePassport()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("obj1", new InsertedObject()
            {
                FromFile = new FileInfo("X:\\ДУ-К-У\\1-й Иртышский проезд.pdf"),
                Height = 80,
                Wight = 150
            });
            hashtable.Add("obj2", new InsertedObject()
            {
                FromFile = new FileInfo("X:\\ДУ-К-Д\\105.pdf"),
                Height = 80,
                Wight = 150
            });
            hashtable.Add("UNIU", "45455554545");
            hashtable.Add("Okrug", "sfsddsfs");
            hashtable.Add("District", "dfsfsfsd");
            hashtable.Add("Address", "ssssssssssssssssssssssssssss");
            hashtable.Add("DUType", "ssssssssssssssssssssssssssss");
            hashtable.Add("tableDU", typeof(DUTypesTable_Creator));
            hashtable.Add("date_of_manufacture", DateTime.Now.ToLongDateString());
            (new Word_Operator<FileInfo>()).CreateBookmarkedDocument("X:\\eeeee.docx",
                new FileInfo("Z:\\Шаблоны\\Приложение5_Технический_паспорт1.dotx"), hashtable);

        }

        [TestMethod]
        public void CreateTable()
        {
            var doc = new Microsoft.Office.Interop.Word.Document();
            doc.Application.Visible = true;

            DUTypesTable_Creator.Create(doc.Range(), "ДУ-М-УД");
        }

    }
}

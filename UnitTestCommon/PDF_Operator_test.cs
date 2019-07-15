using common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
     

namespace UnitTestCommon
{
    [TestClass]
    public class PDF_Operator_test
    {
        [TestMethod]
        public void PrintAkts()

        {
            var dir = new DirectoryInfo("C:\\Паспорта1");
            var pdfop = new PDF_Operator();
            pdfop.Print(dir.GetFiles());
        }
    }
}
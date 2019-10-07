using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using UNS.Common;


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
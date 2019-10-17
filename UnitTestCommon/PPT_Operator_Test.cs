using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using UNS.Common;

namespace UnitTestCommon
{
    [TestClass]
    public class PPT_Operator_Test
    {
        [TestMethod]
        public void ExportToPDF()
        {
            PPT_Operator pptoperator = new PPT_Operator();
            var files = (new DirectoryInfo("C:\\Temp\\1")).GetFiles("*дислокация*", SearchOption.AllDirectories);
            foreach (var file in files) pptoperator.ExportToPDF(file);
        }
    }
}

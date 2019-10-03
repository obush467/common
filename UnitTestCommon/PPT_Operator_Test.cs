using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var files = (new DirectoryInfo("C:\\Temp\\Заявка №4 для подрядчика")).GetFiles("*дислокация*",SearchOption.AllDirectories);
            foreach (var file in files) pptoperator.ExportToPDF(file);
        }
    }
}

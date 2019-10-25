using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var ex = new List<string>() {".ppt",".pptx" };
            var files = (new DirectoryInfo("Z:\\DU_files")).EnumerateFiles("*дислокация*", SearchOption.AllDirectories).Where(w => ex.Contains(w.Extension));
            Parallel.ForEach (files, file=> pptoperator.ExportToPDF(file));
        }
    }
}

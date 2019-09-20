using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Common.Interfaces;

namespace UNS.Common.Operators
{
    public class Excel_Operator : IDocumentOperator
    {
        protected Workbook Workbook {get;set;}
        public void ExportToPDF(FileInfo fileInfo)
        {
            throw new NotImplementedException();
        }

        public void Open(FileInfo file)
        {
            Workbook = new Workbook() {};
        }

        public void Print(PrinterSettings printerSettings)
        {
            throw new NotImplementedException();
        }

        public void Save(FileInfo file)
        {
            throw new NotImplementedException();
        }
    }
}

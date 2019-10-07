using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing.Printing;
using System.IO;
using UNS.Common.Interfaces;

namespace UNS.Common.Operators
{
    public class Excel_Operator : IDocumentOperator
    {
        protected Workbook Workbook { get; set; }
        protected Application Application { get; set; }

        public Excel_Operator(Application application)
        { Application = application; }
        public Excel_Operator() : this(new Application())
        { }
        public void ExportToPDF(FileInfo fileInfo)
        {
            throw new NotImplementedException();
        }

        public void Open(FileInfo file)
        {
            Workbook = new Workbook() { };
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

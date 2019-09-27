using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;

namespace UNS.Common.Interfaces
{
    public interface IOutDocument<T>
    {
        FileInfo Create(T document);        
        void Print(T document, PrinterSettings printerSettings);
        IEnumerable<FileInfo> Create(IEnumerable<T> document);       
        void Print(IEnumerable<T> document, PrinterSettings printerSettings);
        void ExportToPDF(FileInfo fileInfo);
    }
}

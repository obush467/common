using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;

namespace common.Interfaces
{
    public interface IOutDocument<T>
    {
        void Create(T document);
        void Print(T document, short copies = 1);

        void Print(T document, PrinterSettings printerSettings);
        void Create(IEnumerable<T> document);
        void Print(IEnumerable<T> document, short copies = 1);
        void Print(IEnumerable<T> document, PrinterSettings printerSettings);
        void ExportToPDF(FileInfo fileInfo);
    }
}

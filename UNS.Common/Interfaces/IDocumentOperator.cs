using System.Drawing.Printing;
using System.IO;

namespace UNS.Common.Interfaces
{
    interface IDocumentOperator
    {
        void Open(FileInfo file);
        void Print(PrinterSettings printerSettings);
        void Save(FileInfo file);
        void ExportToPDF(FileInfo fileInfo);

    }
}

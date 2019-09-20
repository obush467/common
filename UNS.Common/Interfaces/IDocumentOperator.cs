using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common.Interfaces;
using System.Drawing.Printing;
using System.IO;

namespace common.Operators
{
    public abstract class Operator<T> : IOutDocument<T>
    {
        public abstract void Create(T document);
        public abstract void Create(IEnumerable<T> document);
        public abstract void ExportToPDF(FileInfo fileInfo);
        public abstract void Print(T document, short copies = 1);
        public abstract void Print(T document, PrinterSettings printerSettings);
        public abstract void Print(IEnumerable<T> document, short copies = 1);
        public abstract void Print(IEnumerable<T> document, PrinterSettings printerSettings);
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNSData.Entities;

namespace common
{
  interface IOutDocument<T>
    {
        void Create(T document);
        void Print(T document);
        void Create(IEnumerable<T> document);
        void Print(IEnumerable<T> document);
        void ExportToPDF(FileInfo fileInfo);
    }
}

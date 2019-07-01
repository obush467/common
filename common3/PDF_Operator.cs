using EO.Pdf;
using System.Collections.Generic;
using System.IO;

namespace common
{
    public class PDF_Operator
    {
        public void Print(FileInfo fileInfo)
        {
            PdfDocument doc = new PdfDocument(fileInfo.FullName);
            doc.Print();
        }
        public void Print(IEnumerable<FileInfo> fileInfos)
        {
            foreach (FileInfo fileInfo in fileInfos)
            { Print(fileInfo); }
        }
    }
}

using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using UNS.Common.Interfaces;

namespace UNS.Common
{
    public class PDF_Operator : IOutDocument<FileInfo>
    {
        public FileInfo Create(FileInfo document)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileInfo> Create(IEnumerable<FileInfo> document)
        {
            throw new NotImplementedException();
        }

        public void ExportToPDF(FileInfo fileInfo)
        {
            throw new NotImplementedException();
        }

        public void Print(FileInfo fileInfo, short copies = 1)
        {
            PrinterSettings printerSettings = new PrinterSettings
            {
                Copies = copies
            };
            Print(fileInfo, printerSettings);
        }
        public void Print(IEnumerable<FileInfo> fileInfos, short copies = 1)
        {
            foreach (FileInfo fileInfo in fileInfos)
            { Print(fileInfo, copies); }
        }

        public void Print(FileInfo document, PrinterSettings printerSettings)
        {
            try
            {
                PdfDocument doc = new PdfDocument(document.OpenRead());
                doc.PrintSettings.Copies = printerSettings.Copies;
                if (doc.PrintSettings.CanDuplex)
                {
                    doc.PrintSettings.Duplex = printerSettings.Duplex;
                }
                doc.PrintSettings.Color = printerSettings.SupportsColor;
                doc.PrintSettings.Collate = printerSettings.Collate;
                doc.Print();
            }
            catch (Exception printerror)
            {
#if DEBUG
                Logger.Logger.Debug(printerror.Message);
#else
                Logger.Logger.Error(printerror.Message);
#endif
            }
        }

        public void Print(IEnumerable<FileInfo> documents, PrinterSettings printerSettings)
        {
            foreach (FileInfo fileInfo in documents)
            { Print(fileInfo, printerSettings); }
        }
    }
}

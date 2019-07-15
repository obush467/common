﻿using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using Utility;

namespace common
{
    public class PDF_Operator : IOutDocument<FileInfo>
    {
        public void Create(FileInfo document)
        {
            throw new System.NotImplementedException();
        }

        public void Create(IEnumerable<FileInfo> document)
        {
            throw new System.NotImplementedException();
        }

        public void ExportToPDF(FileInfo fileInfo)
        {
            throw new System.NotImplementedException();
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
                Logger.Log.Debug(printerror.Message);
#else
                Logger.Log.Error(printerror.Message);
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

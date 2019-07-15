using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using Utility;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace common
{
    public class PPT_Operator : IOutDocument<FileInfo>
    {
        protected DirectoryInfo pdfPath = new DirectoryInfo("Z:\\Выборки_по_районам\\1");
        protected DirectoryInfo originalPptDir = new DirectoryInfo("Z:\\Выборки_по_районам\\1");
        protected PowerPoint.Application pptApplication = new PowerPoint.Application();
        public void Print(IEnumerable<FileInfo> files, short copies = 1)
        {
            foreach (FileInfo f in files)
            { Print(f, copies); }
        }
        public void Print(FileInfo file, short copies = 1)
        {
            PrinterSettings printerSettings = new PrinterSettings
            {
                Copies = copies
            };
            Print(file,printerSettings);
        }

        public void ExportToPDF(FileInfo file)
        {
            // Create COM Objects
            PowerPoint.Application pptApplication = null;
            PowerPoint.Presentation pptPresentation = null;
            try
            {
                object unknownType = Type.Missing;
                //start power point
                pptApplication = new PowerPoint.Application();
                //open powerpoint document
                pptPresentation = pptApplication.Presentations.Open(file.FullName,
                    MsoTriState.msoTrue, MsoTriState.msoTrue,
                    MsoTriState.msoFalse);
                // save PowerPoint as PDF
                FileInfo newname = new FileInfo(file.FullName.Replace(".pptx", ".pdf"));
                pptPresentation.ExportAsFixedFormat(newname.FullName,
                   PowerPoint.PpFixedFormatType.ppFixedFormatTypePDF,
                 PowerPoint.PpFixedFormatIntent.ppFixedFormatIntentPrint,
                MsoTriState.msoFalse, PowerPoint.PpPrintHandoutOrder.ppPrintHandoutVerticalFirst,
                PowerPoint.PpPrintOutputType.ppPrintOutputSlides, MsoTriState.msoFalse, null,
                PowerPoint.PpPrintRangeType.ppPrintAll, string.Empty, true, true, true,
                true, false, unknownType);
            }
            catch (Exception error)
            {
#if DEBUG
                Logger.Log.Debug(error.Message);
#else
                Logger.Log.Error(error.Message);
#endif
            }
            finally
            {
                // Close and release the Document object.
                if (pptPresentation != null)
                {
                    pptPresentation.Close();
                }

                // Quit PowerPoint and release the ApplicationClass object.
                if (pptApplication != null)
                {
                    pptApplication.Quit();
                }
            }
        }

        public void Create(FileInfo document)
        {
            throw new NotImplementedException();
        }

        public void Create(IEnumerable<FileInfo> document)
        {
            throw new NotImplementedException();
        }

        public void Print(FileInfo document, PrinterSettings printerSettings)
        {
            PowerPoint.Presentation pptPresentation = null;
            try
            {
                pptPresentation = pptApplication.Presentations.Open(document.FullName,
                   MsoTriState.msoTrue, MsoTriState.msoTrue,
                   MsoTriState.msoFalse);
                pptPresentation.PrintOptions.NumberOfCopies = printerSettings.Copies;
                pptPresentation.PrintOptions.ActivePrinter = printerSettings.PrinterName;
                //if(printerSettings.CanDuplex) pptPresentation.PrintOptions.can
                pptPresentation.PrintOut();
#if DEBUG
                Logger.Log.Debug("Отпечатано "+document.FullName);
#endif
            }
            catch (Exception printerror)
            {
#if DEBUG
                Logger.Log.Debug(printerror.Message);
#else
                Logger.Log.Error(printerror.Message);
#endif
            }
            finally
            {
                pptPresentation.Close();
            }
        }

        public void Print(IEnumerable<FileInfo> documents, PrinterSettings printerSettings)
        {
            foreach (var document in documents)
                Print(document, printerSettings);
        }
    }
}

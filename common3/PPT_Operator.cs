using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.IO;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace common
{
    public class PPT_Operator:IOutDocument<FileInfo>
    {
        protected DirectoryInfo pdfPath = new DirectoryInfo("Z:\\Выборки_по_районам\\1");
        protected DirectoryInfo originalPptDir = new DirectoryInfo("Z:\\Выборки_по_районам\\1");
        public void Print(IEnumerable<FileInfo> files)
        {
            foreach (FileInfo f in files)
            { Print(f); }
        }
        public void Print(FileInfo file)
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

                pptPresentation.PrintOut();
            }
            catch (Exception)
            { }
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
    }
}

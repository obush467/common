using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using PowerPoint=Microsoft.Office.Interop.PowerPoint;

namespace common
{
    public class PPT_Operator
    {
        static string pdfPath = "Z:\\Выборки_по_районам\\1";
        static DirectoryInfo originalPptDir = new DirectoryInfo("Z:\\Выборки_по_районам\\1");
        public static void PrintPPT(DirectoryInfo dir)
        { PrintPPT(dir.GetFiles("*.pptx")); }

        public static void PrintPPT(IEnumerable<FileInfo> files)
        {
            foreach (FileInfo f in files)
            { PrintPPT(f); }
        }
        public static void PrintPPT(FileInfo file)
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

        public static void ExportPPT(FileInfo file)
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
    }
}

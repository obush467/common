using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.ComponentModel.DataAnnotations;
using common;
using common.Interfaces;

namespace UNS.ViewsModels
{
    public class FileItem : PrintPattern, IOut
    {
        public string Pattern { get; set; }
        public FileInfo FileInfo { get; set; }
        public string Status { get { return FileInfo != null && FileInfo.Exists ? "есть" : "нет"; } }
        public PrintPattern PrintPattern { get; internal set; }
        public void Print()
        {
            if (FileInfo != null && FileInfo.Exists)
                switch (FileInfo.Extension)
                {
                    case ".pdf":
                        (new PDF_Operator()).Print(FileInfo, PrinterSettings);
                        break;
                    case ".ppt":
                        (new PPT_Operator()).Print(FileInfo, PrinterSettings);
                        break;
                    case ".pptx":
                        (new PPT_Operator()).Print(FileInfo, PrinterSettings);
                        break;
                    case ".doc":
                        (new Word_Operator()).Print(FileInfo, PrinterSettings);
                        break;
                    case ".docx":
                        (new Word_Operator()).Print(FileInfo, PrinterSettings);
                        break;
                }
        }

        public void Print(PrinterSettings printerSettings)
        {
            throw new NotImplementedException();
        }
    }

    [MetadataType(typeof(DislocationMD))]
    public partial class Dislocation : FileItem
    {
        public Dislocation()
        {
            PrintPattern = new PrintPattern()
            {
                Pattern = "*дислокация*",
                Copies = 1
            };
        }
        public string UNIU { get => Pattern; set => Pattern = value; }
        public class DislocationMD
        {
            public int N { get; set; }
            [Display(Name = "Price")]
            public string UNIU { get; set; }
            public string Status { get; set; }
        }
    }
}


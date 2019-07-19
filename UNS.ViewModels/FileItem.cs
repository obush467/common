using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.ComponentModel.DataAnnotations;

namespace UNS.ViewsModels
{
    public class FileItem
    {
        public string Pattern { get; set; }
        public FileInfo FileInfo { get; set; }
        public string Status { get { return FileInfo != null && FileInfo.Exists ? "есть" : "нет"; } }
        public PrinterSettings PrinterSettings { get; set; }
        public PrintPattern PrintPattern { get; internal set; }
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


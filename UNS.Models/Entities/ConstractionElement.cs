using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace UNS.Models.Entities
{
    public class ConstractionElement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ConstractionElementID { get; set; }
        public string ContentText { get; set; }
        public byte[] ContentImage { get; set; }
        public bool? PermanentContent {get;set;}
        public float Height { get; set; }
        public float Width { get; set; }
        public float SurfaceArea { get; set; }
    }
    public class TwoFieldElement
    {
        public string ContentText2 { get; set; }
        public byte[] ContentImage2 { get; set; }
    }
}

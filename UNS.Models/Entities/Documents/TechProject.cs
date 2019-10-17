using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNS.Models.Entities
{
    [Table("TechProjects")]
    public class TechProject:Document
    {
        public ICollection<Document> Content { get; set; }
        public DateTime? ProjectDate { get; set; }
        public string ProjectCode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Models.Entities.Fias;

namespace UNS.Models.Entities.Fias
{
    public partial class AddressRoom : AddressBase
    {

        [Required]
        [StringLength(50)]
        public string FLATNUMBER { get; set; }

        public int FLATTYPE { get; set; }

        [StringLength(50)]
        public string ROOMNUMBER { get; set; }

        public int? ROOMTYPE { get; set; }

        [StringLength(100)]
        public string ROOMCADNUM { get; set; }
    }
}

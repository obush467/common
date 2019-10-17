using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNS.Models.Entities.Fias
{
    public partial class AddressStatus
    {
        public Guid AddressStatusID { get; set; }
        public int? OPERSTATUS { get; set; }
        [StringLength(2)]
        public string REGIONCODE { get; set; }
        public bool LIVESTATUS { get; set; }
        public virtual AddressBase Base { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNS.Models.Entities.Fias
{
    public class AddressBase
    {
        public Guid ID { get; set; }
        public Guid GUID { get; set; }
        public Guid? PARENTGUID { get; set; }
        public Guid? NORMDOC { get; set; }
        public DateTime? UPDATEDATE { get; set; }
        public DateTime? STARTDATE { get; set; }
        public DateTime? ENDDATE { get; set; }
        [StringLength(6)]
        public string POSTALCODE { get; set; }
        [StringLength(100)]
        public string CADNUM { get; set; }
        public virtual AddressCode Code { get; set; }
        public ICollection<AddressBase> PREV { get; set; }
        public ICollection<AddressBase> NEXT { get; set; }
        //public virtual AddressStatus RootStatus { get; set; }
        public virtual AddressStatus RootStatus { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace UNS.Models.Entities
{
    public class RawAddress
    {
        public Guid ID { get; set; }
        [StringLength(6)]
        public string PostCode { get; set; }

        [MaxLength(4000)]
        public string DirtyAddress { get; set; }
        [MaxLength(4000)]
        public string Address { get; set; }

        [MaxLength(4000)]
        public string Source { get; set; }
        //public virtual OwnerRawAddress OwnerRawAddress { get; set; }
        public RawAddress() { }
    }
}

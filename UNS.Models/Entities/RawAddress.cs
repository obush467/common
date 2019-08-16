using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNS.Models.Entities
{
    public class RawAddress
    {
        public Guid ID { get; set; }
        [StringLength(6)]
        public string PostCode { get; set; }

        [MaxLength(4000)]
        public string Address { get; set; }
        public string Contacts { get; set; }
        [MaxLength(50)]
        public string TypeOwner { get; set; }
        [MaxLength(4000)]
        public string Source { get; set; }
    }
}

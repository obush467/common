using System;
using System.ComponentModel.DataAnnotations;

namespace UNS.Models.Entities
{
    public class OwnerRawAddress : RawAddress
    {
        public Guid Organization_Id { get; set; }
        public virtual Organization Organization { get; set; }
        [MaxLength(50)]
        public string TypeOwner { get; set; }

        public string Contacts { get; set; }
        // public virtual RawAddress RawAddress { get; set; }
    }

}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using UNS.Models.Entities;

namespace UNS.Models.Entities
{
    public class OwnerRawAddress : RawAddress
    {
        //[ForeignKey("Organization")]
        //public Guid Organization_ID { get; set; }
        
        public virtual Organization Organization { get; set; }
    }

}

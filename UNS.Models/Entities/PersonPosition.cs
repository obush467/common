using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNS.Models.Entities
{
    public class PersonPosition
    {
        public Guid Id { get; set; }
        public virtual PersonPositionType PositionType { get; set; }
        public virtual Person Human { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        //[ForeignKey("Organization")]
        //public Guid Organization_Id { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<PhoneItem> Phones {get;set;}

        public ICollection<EmailItem> Emails { get; set; }
        public virtual ICollection<FaxItem> Faxes { get; set; }

    }
}

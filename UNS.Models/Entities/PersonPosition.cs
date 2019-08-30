using System;
using System.Collections.Generic;

namespace UNS.Models.Entities
{
    public class PersonPosition
    {
        public Guid Id { get; set; }
        public Nullable<Guid> PositionType_Id { get; set; }
        public virtual PersonPositionType PositionType { get; set; }
        public virtual Person Person { get; set; }
        public Guid Person_Id { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid Organization_Id { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<PhoneItem> Phones { get; set; }

        public virtual ICollection<EmailItem> Emails { get; set; }
        public virtual ICollection<FaxItem> Faxes { get; set; }

    }
}

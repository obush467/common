using System;
using System.Collections.Generic;

namespace UNS.Models.Entities
{
    public class SimplifiedLetter : Document
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string RecipientDirectorPosition { get; set; }
        public string RecipientDirectorName { get; set; }
        public string IncomingNumber { get; set; }
        public string OutgoingNumber { get; set; }
        public DateTime? IncomingDate { get; set; }
        public DateTime? OutgoingDate { get; set; }
        public ICollection<IntegraDUStages> IntegraDUStages { get; set; }
    }
}

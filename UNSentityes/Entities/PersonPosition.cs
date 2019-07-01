using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNSData.Entities
{
    public class PersonPosition
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public virtual PersonPositionType PositionType { get; set; }
        public virtual Person Human { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        [ForeignKey("Organization")]
        public Guid Organization_Id { get; set; }
        public virtual Organization Organization { get; set; }

    }
}

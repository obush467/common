namespace UNSentityes.Entityes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Address")]
    public partial class Address
    {
        [Key]
        [Column(Order = 0)]
        public Guid ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid AdmAreaID { get; set; }

        [Column("Address")]
        [StringLength(10)]
        public string Address1 { get; set; }

        [StringLength(11)]
        public string UNOM { get; set; }
    }
}

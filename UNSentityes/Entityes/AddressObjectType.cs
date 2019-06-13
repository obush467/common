namespace UNSentityes.Entityes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fias.AddressObjectType")]
    public partial class AddressObjectType
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LEVEL { get; set; }

        [StringLength(10)]
        public string SCNAME { get; set; }

        [StringLength(50)]
        public string SOCRNAME { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string KOD_T_ST { get; set; }
    }
}

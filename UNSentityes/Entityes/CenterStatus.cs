namespace UNSentityes.Entityes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fias.CenterStatus")]
    public partial class CenterStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CENTERSTID { get; set; }

        [Required]
        [StringLength(100)]
        public string NAME { get; set; }
    }
}

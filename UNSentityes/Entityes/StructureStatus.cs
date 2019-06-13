namespace UNSentityes.Entityes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fias.StructureStatus")]
    public partial class StructureStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int STRSTATID { get; set; }

        [Required]
        [StringLength(50)]
        public string NAME { get; set; }

        [StringLength(50)]
        public string SHORTNAME { get; set; }
    }
}

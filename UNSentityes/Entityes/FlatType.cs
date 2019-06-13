namespace UNSentityes.Entityes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fias.FlatType")]
    public partial class FlatType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long FLTYPEID { get; set; }

        [StringLength(8000)]
        public string NAME { get; set; }

        [StringLength(8000)]
        public string SHORTNAME { get; set; }
    }
}

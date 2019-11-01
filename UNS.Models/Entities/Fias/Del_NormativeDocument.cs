namespace UNS.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("fias.Del_NormativeDocument")]
    public partial class Del_NormativeDocument
    {
        [Key]
        public Guid NORMDOCID { get; set; }

        [StringLength(500)]
        public string DOCNAME { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOCDATE { get; set; }

        [StringLength(20)]
        public string DOCNUM { get; set; }

        public long DOCTYPE { get; set; }

        public Guid? DOCIMGID { get; set; }
    }
}

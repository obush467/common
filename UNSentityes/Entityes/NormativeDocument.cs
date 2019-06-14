namespace UNSentityes.Entityes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fias.NormativeDocument")]
    public partial class NormativeDocument
    {
        [Key]
        public Guid NORMDOCID { get; set; }

        [StringLength(500)]
        public string DOCNAME { get; set; }

        public DateTime? DOCDATE { get; set; }

        [StringLength(20)]
        public string DOCNUM { get; set; }

        public long DOCTYPE { get; set; }

        public Guid? DOCIMGID { get; set; }

        public virtual NormativeDocument NormativeDocument1 { get; set; }

        public virtual NormativeDocument NormativeDocument2 { get; set; }

        public virtual NormativeDocumentType NormativeDocumentType { get; set; }
    }
}
namespace UNS.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("fias.Del_House")]
    public partial class Del_House
    {
        [StringLength(6)]
        public string POSTALCODE { get; set; }

        [StringLength(4)]
        public string IFNSFL { get; set; }

        [StringLength(4)]
        public string TERRIFNSFL { get; set; }

        [StringLength(4)]
        public string IFNSUL { get; set; }

        [StringLength(4)]
        public string TERRIFNSUL { get; set; }

        [StringLength(11)]
        public string OKATO { get; set; }

        [StringLength(11)]
        public string OKTMO { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? UPDATEDATE { get; set; }

        [StringLength(20)]
        public string HOUSENUM { get; set; }

        public int ESTSTATUS { get; set; }

        [StringLength(10)]
        public string BUILDNUM { get; set; }

        [StringLength(10)]
        public string STRUCNUM { get; set; }

        public int? STRSTATUS { get; set; }

        [Key]
        public Guid HOUSEID { get; set; }
        public Guid HOUSEGUID { get; set; }

        public Guid? AOGUID { get; set; }

        public DateTime STARTDATE { get; set; }

        public DateTime ENDDATE { get; set; }

        public int? STATSTATUS { get; set; }

        public Guid? NORMDOC { get; set; }

        public int? COUNTER { get; set; }

        [StringLength(100)]
        public string CADNUM { get; set; }

        public int? DIVTYPE { get; set; }
    }
}

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

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ESTSTATUS { get; set; }

        [StringLength(10)]
        public string BUILDNUM { get; set; }

        [StringLength(10)]
        public string STRUCNUM { get; set; }

        public int? STRSTATUS { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid HOUSEID { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid HOUSEGUID { get; set; }

        public Guid? AOGUID { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "smalldatetime")]
        public DateTime STARTDATE { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "smalldatetime")]
        public DateTime ENDDATE { get; set; }

        public int? STATSTATUS { get; set; }

        public Guid? NORMDOC { get; set; }

        public int? COUNTER { get; set; }

        [StringLength(100)]
        public string CADNUM { get; set; }

        public int? DIVTYPE { get; set; }
    }
}

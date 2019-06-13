namespace UNSentityes.Entityes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fias.Landmark")]
    public partial class Landmark
    {
        [StringLength(1000)]
        public string LOCATION { get; set; }

        [StringLength(2)]
        public string REGIONCODE { get; set; }

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
        public DateTime UPDATEDATE { get; set; }

        [Key]
        [StringLength(50)]
        public string LANDID { get; set; }

        [StringLength(50)]
        public string LANDGUID { get; set; }

        public Guid? AOGUID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime STARTDATE { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime ENDDATE { get; set; }

        public Guid? NORMDOC { get; set; }

        [StringLength(1000)]
        public string CADNUM { get; set; }
    }
}

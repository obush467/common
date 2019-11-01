namespace UNS.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Stead
    {
        public Guid? STEADGUID { get; set; }

        [StringLength(120)]
        public string NUMBER { get; set; }

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

        [Column(TypeName = "date")]
        public DateTime UPDATEDATE { get; set; }

        public Guid? PARENTGUID { get; set; }

        public Guid STEADID { get; set; }

        public Guid? PREVID { get; set; }

        public Guid? NEXTID { get; set; }

        public long OPERSTATUS { get; set; }

        [Column(TypeName = "date")]
        public DateTime STARTDATE { get; set; }

        [Column(TypeName = "date")]
        public DateTime ENDDATE { get; set; }

        public Guid? NORMDOC { get; set; }

        public int LIVESTATUS { get; set; }

        [StringLength(100)]
        public string CADNUM { get; set; }

        public int DIVTYPE { get; set; }

        public int? COUNTER { get; set; }
    }
}

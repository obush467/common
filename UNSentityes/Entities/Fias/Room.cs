namespace UNS.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("fias.Room")]
    public partial class Room
    {
        [StringLength(50)]
        public string ROOMGUID { get; set; }

        [Required]
        [StringLength(50)]
        public string FLATNUMBER { get; set; }

        public int FLATTYPE { get; set; }

        [StringLength(50)]
        public string ROOMNUMBER { get; set; }

        public int? ROOMTYPE { get; set; }

        [StringLength(2)]
        public string REGIONCODE { get; set; }

        [StringLength(6)]
        public string POSTALCODE { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime UPDATEDATE { get; set; }

        [StringLength(50)]
        public string HOUSEGUID { get; set; }

        [StringLength(50)]
        public string ROOMID { get; set; }

        [StringLength(50)]
        public string PREVID { get; set; }

        [StringLength(50)]
        public string NEXTID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime STARTDATE { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime ENDDATE { get; set; }

        public bool LIVESTATUS { get; set; }

        [StringLength(50)]
        public string NORMDOC { get; set; }

        public long OPERSTATUS { get; set; }

        [StringLength(100)]
        public string CADNUM { get; set; }

        [StringLength(100)]
        public string ROOMCADNUM { get; set; }
    }
}

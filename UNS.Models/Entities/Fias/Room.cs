namespace UNS.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Room
    {
        public Guid ROOMGUID { get; set; }

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

        public Guid HOUSEGUID { get; set; }

        public Guid ROOMID { get; set; }
        public Guid? PREVID { get; set; }

        public Guid? NEXTID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime STARTDATE { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime ENDDATE { get; set; }

        public bool LIVESTATUS { get; set; }

        public Guid? NORMDOC { get; set; }

        public long OPERSTATUS { get; set; }

        [StringLength(100)]
        public string CADNUM { get; set; }

        [StringLength(100)]
        public string ROOMCADNUM { get; set; }
    }
}

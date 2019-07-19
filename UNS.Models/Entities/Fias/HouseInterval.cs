namespace UNS.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("fias.HouseInterval")]
    public partial class HouseInterval
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
        public DateTime UPDATEDATE { get; set; }

        public int INTSTART { get; set; }

        public int INTEND { get; set; }

        [Key]
        public Guid HOUSEINTID { get; set; }

        public Guid? INTGUID { get; set; }

        public Guid? AOGUID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime STARTDATE { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime ENDDATE { get; set; }

        public int? INTSTATUS { get; set; }

        public Guid? NORMDOC { get; set; }

        public int COUNTER { get; set; }

        public virtual IntervalStatus IntervalStatus { get; set; }
    }
}

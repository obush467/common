namespace UNS.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("fias.Del_Object")]
    public partial class Del_Object
    {
        public Guid? AOGUID { get; set; }

        [StringLength(120)]
        public string FORMALNAME { get; set; }

        [StringLength(2)]
        public string REGIONCODE { get; set; }

        [StringLength(1)]
        public string AUTOCODE { get; set; }

        [StringLength(3)]
        public string AREACODE { get; set; }

        [StringLength(3)]
        public string CITYCODE { get; set; }

        [StringLength(3)]
        public string CTARCODE { get; set; }

        [StringLength(3)]
        public string PLACECODE { get; set; }

        [StringLength(4)]
        public string STREETCODE { get; set; }

        [StringLength(4)]
        public string EXTRCODE { get; set; }

        [StringLength(3)]
        public string SEXTCODE { get; set; }

        [StringLength(120)]
        public string OFFNAME { get; set; }

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

        public DateTime? UPDATEDATE { get; set; }

        [StringLength(10)]
        public string SHORTNAME { get; set; }

        public int? AOLEVEL { get; set; }

        public Guid? PARENTGUID { get; set; }

        [Key]
        public Guid AOID { get; set; }

        public Guid? PREVID { get; set; }

        public Guid? NEXTID { get; set; }

        [StringLength(17)]
        public string CODE { get; set; }

        [StringLength(15)]
        public string PLAINCODE { get; set; }

        public int? ACTSTATUS { get; set; }

        public int? CENTSTATUS { get; set; }

        public int? OPERSTATUS { get; set; }

        public int? CURRSTATUS { get; set; }

        public DateTime? STARTDATE { get; set; }

        public DateTime? ENDDATE { get; set; }

        public Guid? NORMDOC { get; set; }

        [StringLength(1)]
        public string LIVESTATUS { get; set; }

        [StringLength(100)]
        public string CADNUM { get; set; }

        public int? DIVTYPE { get; set; }

        public int? OFFNAME_NUM_TYPE { get; set; }

        public int? OFFNAME_NUM_NUMBER { get; set; }

        public int? OFFNAME_NUM_PREFIX { get; set; }

        [StringLength(20)]
        public string OFFNAME_NUMBER { get; set; }

        [StringLength(20)]
        public string OFFNAME_PREFIX { get; set; }

        [StringLength(80)]
        public string OFFNAME_NAME { get; set; }

        [StringLength(50)]
        public string CONVERTSTREET { get; set; }

        [StringLength(50)]
        public string PLANCODE { get; set; }
    }
}

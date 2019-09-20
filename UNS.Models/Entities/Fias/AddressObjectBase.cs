namespace UNS.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class AddressBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }
        public Guid GUID { get; set; }     
        public Guid? PARENTGUID { get; set; }
        public Guid? NORMDOC { get; set; }
        public DateTime? UPDATEDATE { get; set; }     
        public DateTime? STARTDATE { get; set; }
        public DateTime? ENDDATE { get; set; }
        [StringLength(6)]
        public string POSTALCODE { get; set; }

        [StringLength(100)]
        public string CADNUM { get; set; }
        public virtual AddressPrevNext PrevNext { get; set; }
        public virtual AddressCode AddressCode { get; set; }
    }
    public class AddressCode
    {
        public Guid AddressCode_ID { get; set; }
        public Guid AddressBase_ID { get; set; }
        [StringLength(4)]
        public string IFNSFL { get; set; }

        [StringLength(4)]
        public string TERRIFNSFL { get; set; }

        [StringLength(11)]
        public string OKATO { get; set; }

        [StringLength(11)]
        public string OKTMO { get; set; }

        public int DIVTYPE { get; set; }
        public virtual AddressBase AddressBase { get; set; }
    }

    public partial class AddressPrevNext
    {
        public Guid AddressBase_ID { get; set; }
        public Guid? PREVID { get; set; }
        public Guid? NEXTID { get; set; }
        public int? OPERSTATUS { get; set; }
        [StringLength(2)]
        public string REGIONCODE { get; set; }
        public bool LIVESTATUS { get; set; }
        public virtual AddressBase AddressBase { get; set; }
        public virtual AddressBase PREV { get; set; }
        public virtual AddressBase NEXT { get; set; }

    }
    public partial class Room1:AddressBase
    {

        [Required]
        [StringLength(50)]
        public string FLATNUMBER { get; set; }

        public int FLATTYPE { get; set; }

        [StringLength(50)]
        public string ROOMNUMBER { get; set; }

        public int? ROOMTYPE { get; set; }

        [StringLength(100)]
        public string ROOMCADNUM { get; set; }
}
    public partial class Stead1: AddressBase
    {

        [StringLength(120)]
        public string NUMBER { get; set; }
        public int? COUNTER { get; set; }
        //public virtual AddressPrevNext PrevNext { get; set; }

    }
}

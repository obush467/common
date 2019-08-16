namespace UNS.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("fias.AddressObjectType")]
    public partial class AddressObjectType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LEVEL { get; set; }

        [StringLength(10)]
        public string SCNAME { get; set; }

        [StringLength(50)]
        public string SOCRNAME { get; set; }

        [StringLength(4)]
        public string KOD_T_ST { get; set; }
    }
}

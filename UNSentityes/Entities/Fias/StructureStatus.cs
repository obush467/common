namespace UNSData.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("fias.StructureStatus")]
    public partial class StructureStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int STRSTATID { get; set; }

        [Required]
        [StringLength(50)]
        public string NAME { get; set; }

        [StringLength(50)]
        public string SHORTNAME { get; set; }
    }
}

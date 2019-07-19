namespace UNS.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("fias.ActualStatus")]
    public partial class ActualStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ACTSTATID { get; set; }

        [Required]
        [StringLength(100)]
        public string NAME { get; set; }
    }
}

namespace UNS.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("fias.CurrentStatus")]
    public partial class CurrentStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CURENTSTID { get; set; }

        [Required]
        [StringLength(100)]
        public string NAME { get; set; }
    }
}

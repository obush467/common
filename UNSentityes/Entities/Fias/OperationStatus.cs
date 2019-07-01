namespace UNSData.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("fias.OperationStatus")]
    public partial class OperationStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OPERSTATID { get; set; }

        [Required]
        [StringLength(100)]
        public string NAME { get; set; }
    }
}

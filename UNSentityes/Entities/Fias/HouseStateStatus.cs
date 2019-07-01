namespace UNSData.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("fias.HouseStateStatus")]
    public partial class HouseStateStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HOUSESTID { get; set; }

        [Required]
        [StringLength(60)]
        public string NAME { get; set; }
    }
}

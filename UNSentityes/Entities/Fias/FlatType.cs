namespace UNSData.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("fias.FlatType")]
    public partial class FlatType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long FLTYPEID { get; set; }

        [StringLength(4000)]
        public string NAME { get; set; }

        [StringLength(4000)]
        public string SHORTNAME { get; set; }
    }
}

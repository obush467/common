namespace UNSentityes.Entityes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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

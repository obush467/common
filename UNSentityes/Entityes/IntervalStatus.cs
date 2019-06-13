namespace UNSentityes.Entityes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fias.IntervalStatus")]
    public partial class IntervalStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IntervalStatus()
        {
            HouseInterval = new HashSet<HouseInterval>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int INTVSTATID { get; set; }

        [Required]
        [StringLength(60)]
        public string NAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HouseInterval> HouseInterval { get; set; }
    }
}

namespace UNSData.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class integraDUStages
    {
        public int? Number { get; set; }

        [Required]
        [StringLength(10)]
        public string DUType { get; set; }

        [Required]
        [StringLength(50)]
        public string Okrug { get; set; }

        [Required]
        [StringLength(50)]
        public string District { get; set; }

        [Required]
        [StringLength(255)]
        public string AddressObject { get; set; }

        [Required]
        [StringLength(50)]
        public string AddressHouse { get; set; }

        [StringLength(255)]
        public string ContentObject { get; set; }

        [StringLength(50)]
        public string ContentHouse { get; set; }

        [StringLength(255)]
        public string InstallationStatus { get; set; }

        public int UNOM { get; set; }

        public Guid ID { get; set; }

        [StringLength(50)]
        public string Stage { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime SysStartTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime SysEndTime { get; set; }

        [Required]
        [StringLength(13)]
        public string UNIU { get; set; }

        public virtual integraDUExcel integraDUExcel { get; set; }
    }
}

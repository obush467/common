using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace UNS.Models.Entities.Address
{
    [Table("HouseFullBTI",Schema = "address")]
    public class HouseFullBTI 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid HouseFullBTI_ID { get; set; }
        public HouseFull HouseFull { get; set; }
        public DbGeography GeoData { get; set; }
        [MaxLength(1000)]
        public string Address { get; set; }
        public int? UNOM { get; set; }
        [MaxLength(50)]
        public string KLADR { get; set; }

        [MaxLength(50)]
        public string ADR_TYPE { get; set; }
        public int? StoreysCount { get; set; }
        [MaxLength(50)]
        public string WallMaterial { get; set; }
        [MaxLength(50)]
        public string Purpose { get; set; }
        [MaxLength(50)]
        public string Class { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }

        [MaxLength(50)]
        public string Attribute { get; set; }

        public double? TotalArea { get; set; }

    }
}


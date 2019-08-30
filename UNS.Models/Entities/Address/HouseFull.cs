using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace UNS.Models.Entities.Address
{
    [Table("address.HouseFull")]
    public class HouseFull : House
    {
        public DbGeography GeoData { get; set; }
        [MaxLength(1000)]
        public string Address { get; set; }
        //public int? UNOM { get; set; }
        //[Required]
        [ForeignKey("AdmArea")]
        public Guid? AdmAreaId { get; set; }
        public AdmArea AdmArea { get; set; }
        [MaxLength(50)]
        public string KLADR { get; set; }
    }
}


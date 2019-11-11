using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNS.Models.Entities.Address
{
    public class AddressCachedObject:AddressCached
    {
        public DbGeography GeoData { get; set; }
        public Guid? AdmAreaId { get; set; }
        public AdmArea AdmArea { get; set; }
        //public int UNOM { get; set; }
        public string CADNUM { get; set; }
        public ICollection<AddressCachedObject_UNOM> UNOMs { get; set; }

    }
    public class AddressCachedObjectBuilding : AddressCachedObject
    {
        public int? StoreysCount { get; set; }
        [MaxLength(255)]
        public string WallMaterial { get; set; }
        [MaxLength(255)]
        public string Purpose { get; set; }
        [MaxLength(255)]
        public string Class { get; set; }
        [MaxLength(255)]
        public string Type { get; set; }

        [MaxLength(255)]
        public string Attribute { get; set; }
        public double? TotalArea { get; set; } 
    }
    public class AddressCachedObjectStead : AddressCachedObject 
    {
    
    }
    public class AddressCachedObjectConfiguration : EntityTypeConfiguration<AddressCachedObject>
    {
        public AddressCachedObjectConfiguration()
        {
            ToTable("AddressCachedObject","address");
            HasOptional(o => o.AdmArea).WithMany().HasForeignKey(fk => fk.AdmAreaId);
            Property(p => p.CADNUM).IsOptional().HasMaxLength(50);
            //Property(p => p.UNOM).IsOptional();
        }
    }
    public class AddressCachedObjectBuildingConfiguration : EntityTypeConfiguration<AddressCachedObjectBuilding>
    {
        public AddressCachedObjectBuildingConfiguration()
        {
            ToTable("AddressCachedObjectBuilding", "address");
        }
    }
    public class AddressCachedObjectSteadConfiguration : EntityTypeConfiguration<AddressCachedObjectStead>
    {
        public AddressCachedObjectSteadConfiguration()
        {
            ToTable("AddressCachedObjectStead", "address");
        }
    }
}

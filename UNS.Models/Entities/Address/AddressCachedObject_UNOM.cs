using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNS.Models.Entities.Address
{
    public class AddressCachedObject_UNOM
    {
        public Guid UNOM_ItemID { get; set; }
        public DbGeography GeoData { get; set; }
        public Guid? AdmAreaId { get; set; }
        public AdmArea AdmArea { get; set; }
        public int UNOM { get; set; }
    }
    public class UNOM_ItemConfiguration : EntityTypeConfiguration<AddressCachedObject_UNOM>
    {
        public UNOM_ItemConfiguration() : base()
        {
            ToTable("AddressCachedObject_UNOM", "address");
            HasKey(k => k.UNOM_ItemID).Property(p => p.UNOM_ItemID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasOptional<AdmArea>(o => o.AdmArea).WithMany().HasForeignKey(fk => fk.AdmAreaId);
            Property(p => p.UNOM).IsRequired();
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace UNS.Models.Entities
{
    public class LightingEquipment
    {
        public Guid LightingEquipmentID { get; set; }
    }
    public class LightingEquipmentConfiguration : EntityTypeConfiguration<LightingEquipment>
    {
        public LightingEquipmentConfiguration() : base()
        {
            ToTable("LightingEquipment");
            HasKey(k => k.LightingEquipmentID)
                .Property(p => p.LightingEquipmentID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
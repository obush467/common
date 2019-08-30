using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Models.Configuration
{
    public class RawAddresConfiguration : EntityTypeConfiguration<RawAddress>
    {
        public RawAddresConfiguration() : base()
        {
            ToTable("RawAddress");
            HasKey(p => p.ID)
            .Property(p => p.ID)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}

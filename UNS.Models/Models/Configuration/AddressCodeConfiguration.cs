using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Models.Configuration
{
    public class AddressCodeConfiguration : EntityTypeConfiguration<AddressCode>
    {
        public AddressCodeConfiguration() : base()
        {
            ToTable("AddressCodes", "fias");
            HasKey(s => s.ID).Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}


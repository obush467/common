using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities.Fias;

namespace UNS.Models.Models.Configuration
{
    public class AddressAOConfiguration : EntityTypeConfiguration<AddressAO>
    {
        public AddressAOConfiguration() : base()
        {
            ToTable("AddressAOs", "fias");
        }
    }
}


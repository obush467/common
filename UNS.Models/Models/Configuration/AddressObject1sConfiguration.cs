using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities.Fias;

namespace UNS.Models.Models.Configuration
{
    public class AddressObject1Configuration : EntityTypeConfiguration<AddressObject1>
    {
        public AddressObject1Configuration() : base()
        {
            ToTable("AddressObject1s", "fias");
        }
    }
}


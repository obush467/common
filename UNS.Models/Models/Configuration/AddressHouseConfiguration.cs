using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities.Fias;

namespace UNS.Models.Configuration
{
    internal class AddressHouseConfiguration : EntityTypeConfiguration<AddressHouse>
    {
        public AddressHouseConfiguration()
        {
            ToTable("AddressHouse", "fias");
        }
    }
}
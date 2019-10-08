using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Models.Configuration
{
    public class AddressRoomConfiguration : EntityTypeConfiguration<AddressRoom>
    {
        public AddressRoomConfiguration() : base()
        {
            ToTable("AddressRoom", "fias");
        }
    }
}


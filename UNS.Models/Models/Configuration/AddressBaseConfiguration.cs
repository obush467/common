using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Models.Configuration
{
    public class AddressBaseConfiguration : EntityTypeConfiguration<AddressBase>
    {
        public AddressBaseConfiguration() : base()
        {
            ToTable("AddressBases", "fias");
            /*HasMany<AddressBase>(m => m.PREV).WithMany()
        .Map(m =>
        {
            m.ToTable("AddressBase_PrevNext");
            m.MapLeftKey("PREVID");
            m.MapRightKey("NEXTID");
        });*/
        }
    }
}


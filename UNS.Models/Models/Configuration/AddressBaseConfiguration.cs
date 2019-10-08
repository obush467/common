using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;
using UNS.Models.Entities.Fias;

namespace UNS.Models.Models.Configuration
{
    public class AddressBaseConfiguration : EntityTypeConfiguration<AddressBase>
    {
        public AddressBaseConfiguration() : base()
        {
            ToTable("AddressBases", "fias");
            HasKey(h => h.ID).Property(p => p.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            HasMany<AddressBase>(m => m.NEXT).WithMany()
        .Map(m =>
        {
            m.ToTable("AddressBase_PrevNext","fias");
            m.MapLeftKey("PREVID");
            m.MapRightKey("NEXTID");
        });
            HasMany<AddressBase>(m => m.PREV).WithMany(w=>w.NEXT)
        .Map(m =>
        {
            m.ToTable("AddressBase_PrevNext", "fias");
            m.MapLeftKey("NEXTID");
            m.MapRightKey("PREVID");
        });
            HasOptional(o => o.AddressCode).WithOptionalDependent(o => o.AddressBase);
            HasOptional(o => o.AddressStatus).WithOptionalDependent(o => o.AddressBase);
        }
    }
    }



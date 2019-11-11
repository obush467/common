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
            HasMany(m => m.NEXT).WithMany()
        .Map(m =>
        {
            m.ToTable("AddressBase_PrevNext","fias");
            m.MapLeftKey("PREVID");
            m.MapRightKey("NEXTID");
        });
            HasMany(m => m.PREV).WithMany(w=>w.NEXT)
        .Map(m =>
        {
            m.ToTable("AddressBase_PrevNext", "fias");
            m.MapLeftKey("NEXTID");
            m.MapRightKey("PREVID");
        });           
            HasOptional(o => o.Code).WithRequired(o=>o.Address).WillCascadeOnDelete();
            HasOptional(o => o.RootStatus).WithRequired(o => o.Base).WillCascadeOnDelete();
        }
    }
    }



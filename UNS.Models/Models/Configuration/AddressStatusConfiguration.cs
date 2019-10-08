using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;
using UNS.Models.Entities.Fias;

namespace UNS.Models.Models.Configuration
{
    public class AddressStatusConfiguration : EntityTypeConfiguration<AddressStatus>
    {
        public AddressStatusConfiguration() : base()
        {
            ToTable("AddressStatuses", "fias");
            HasKey(s => s.ID).Property(p=>p.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            //HasRequired(s => s.AddressBase).WithRequiredDependent();
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;
using UNS.Models.Entities.Fias;

namespace UNS.Models.Models.Configuration
{
    public class AddressSteadConfiguration : EntityTypeConfiguration<AddressStead>
    {
        public AddressSteadConfiguration() : base()
        {
            ToTable("AddressStead", "fias")
                .HasKey(e => e.ID)
                .Property(e => e.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //HasOptional(s => s.AddressCode).WithOptionalPrincipal(s=>(Stead1)s.AddressBase);
        }
    }
}

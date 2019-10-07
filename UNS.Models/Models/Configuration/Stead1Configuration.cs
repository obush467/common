using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Models.Configuration
{
    public class Stead1Configuration : EntityTypeConfiguration<Stead1>
    {
        public Stead1Configuration() : base()
        {
            ToTable("Stead1", "fias")
                .HasKey(e => e.ID)
                .Property(e => e.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //HasOptional(s => s.AddressCode).WithOptionalPrincipal(s=>(Stead1)s.AddressBase);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Models.Entities.Address;

namespace UNS.Models.Models.Configuration
{
    public class LocationBaseConfiguration : EntityTypeConfiguration<LocationBase>
    {
        public LocationBaseConfiguration() : base()
        {
            ToTable("LocationBase", "address");
            HasKey(k => k.LocationBaseID)
                .Property(p => p.LocationBaseID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasOptional(r => r.AdministrativeArea).WithMany().HasForeignKey(fk => fk.AdmAreaID);
            Property(p => p.ClarificationOfLocation)
                .HasMaxLength(4000)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(new IndexAttribute("IX_Name") { IsUnique = false }));
            Property(p => p.TS).IsRowVersion().IsConcurrencyToken();
        }
    }

    public class LocationOneAddressConfiguration : EntityTypeConfiguration<LocationOneAddress>
    {
        public LocationOneAddressConfiguration() : base()
        {
            ToTable("LocationOneAddress", "address");
            HasRequired(r => r.Address).WithMany().HasForeignKey(fk => fk.AddressID);
        }
    }
    public class LocationManyAddressConfiguration : EntityTypeConfiguration<LocationManyAddress>
    {
        public LocationManyAddressConfiguration() : base()
        {
            ToTable("LocationManyAddress", "address");
            HasRequired(r => r.Addresses).WithMany();


        }
    }
}

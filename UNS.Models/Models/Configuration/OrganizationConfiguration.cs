using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Configuration
{
    public class OrganizationConfiguration : EntityTypeConfiguration<Organization>
    {
        public OrganizationConfiguration() : base()
        {
            ToTable("Organizations");
            HasKey(p => p.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasOptional(p => p.OrganizationType);
            HasMany(m => m.PhoneItems).WithMany()
            .Map(m =>
            {
                m.ToTable("Organizations_Phones");
                m.MapLeftKey("Organization_ID");
                m.MapRightKey("PhoneItem_ID");
            });

            HasMany(m => m.FaxItems).WithMany()
                    .Map(m =>
                    {
                        m.ToTable("Organizations_Faxes");
                        m.MapLeftKey("Organization_ID");
                        m.MapRightKey("FaxItem_ID");
                    });
            HasMany(m => m.EmailItems).WithMany()
                    .Map(m =>
                    {
                        m.ToTable("Organizations_Emails");
                        m.MapLeftKey("Organization_ID");
                        m.MapRightKey("EmailItem_ID");
                    });

        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Configuration
{
    internal class PersonPositionConfiguration : EntityTypeConfiguration<PersonPosition>
    {
        public PersonPositionConfiguration() : base()
        {
            ToTable("PersonPositions").HasKey(h => h.Id).Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(h => h.Organization).WithMany(m => m.PersonPositions).HasForeignKey(f => f.Organization_Id);
            HasRequired(h => h.Person).WithMany(t => t.PersonPositions).HasForeignKey(h => h.Person_Id);
            Property(p => p.PositionType_Id).IsOptional();
            HasOptional(p => p.PositionType).WithMany(m => m.PersonPositions).HasForeignKey(f => f.PositionType_Id).WillCascadeOnDelete();
            //HasOptional(p => p.Phones);
            //HasOptional(p => p.Faxes);
            //HasOptional(p => p.Emails);
            HasMany<PhoneItem>(m => m.Phones).WithMany()
                .Map(m =>
                {
                    m.ToTable("PersonPositions_Phones");
                    m.MapLeftKey("PersonPosition_ID");
                    m.MapRightKey("PhoneItem_ID");
                });
            HasMany<FaxItem>(m => m.Faxes).WithMany()
                .Map(m =>
                {
                    m.ToTable("PersonPositions_Faxes");
                    m.MapLeftKey("PersonPosition_ID");
                    m.MapRightKey("FaxItem_ID");
                });
            HasMany<EmailItem>(m => m.Emails).WithMany()
                .Map(m =>
                {
                    m.ToTable("PersonPositions_EmailItems");
                    m.MapLeftKey("PersonPosition_ID");
                    m.MapRightKey("EmailItem_ID");
                });
        }
    }
}
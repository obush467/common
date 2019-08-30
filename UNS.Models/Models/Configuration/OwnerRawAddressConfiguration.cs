using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Models.Configuration
{
    public class OwnerRawAddressConfiguration : EntityTypeConfiguration<OwnerRawAddress>
    {
        public OwnerRawAddressConfiguration() : base()
        {
            ToTable("OwnerRawAddress");
            //HasKey(p => p.ID).HasRequired(p=>p.RawAddress).WithRequiredDependent(p=>p.OwnerRawAddress);//.WithRequiredDependent().WillCascadeOnDelete();
            HasRequired<Organization>(r => r.Organization)
                .WithMany(k => k.OwnerRawAddresses)
                .HasForeignKey(p => p.Organization_Id).WillCascadeOnDelete();
        }
    }
}

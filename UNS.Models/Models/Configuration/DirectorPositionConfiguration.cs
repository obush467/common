using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Models.Configuration
{
    public class DirectorPositionConfiguration : EntityTypeConfiguration<DirectorPosition>
    {
        public DirectorPositionConfiguration() : base()
        {
            ToTable("DirectorPositions");
            //HasKey(p => p.ID).HasRequired(p=>p.RawAddress).WithRequiredDependent(p=>p.OwnerRawAddress);//.WithRequiredDependent().WillCascadeOnDelete();
        }
    }
}
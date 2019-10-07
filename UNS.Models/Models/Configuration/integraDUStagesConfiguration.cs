using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Models.Configuration
{
    public class integraDUStagesConfiguration : EntityTypeConfiguration<IntegraDUStages>
    {
        public integraDUStagesConfiguration() : base()
        {
            ToTable("integraDUStages");
            HasKey(t => t.ID).Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }

}

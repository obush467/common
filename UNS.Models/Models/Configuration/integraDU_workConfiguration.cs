using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Models.Configuration
{
    public class integraDU_workConfiguration : EntityTypeConfiguration<IntegraDU_work>
    {
        public integraDU_workConfiguration() : base()
        {
            ToTable("integraDU_works");
            HasKey(s => s.integraDU_workID).Property(p => p.integraDU_workID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasOptional(s => s.Checker).WithOptionalDependent();
            HasOptional(s => s.Worker).WithOptionalDependent();
            //HasRequired<IntegraDU>().WithMany(s=>s.IntegraDU_Works).HasForeignKey(s=>s.IntegraDU_ID);
        }
    }

}

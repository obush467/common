using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Configuration
{
    internal class SimplifiedLetterConfiguration : EntityTypeConfiguration<SimplifiedLetter>
    {
        public SimplifiedLetterConfiguration() : base()
        {
            ToTable("SimplifiedLetter");
            HasMany<IntegraDUStages>(m => m.IntegraDUStages).WithMany()
                .Map(m =>
                {
                    m.ToTable("SimplifiedLetter_IntegraDUStages");
                    m.MapLeftKey("SimplifiedLetter_ID");
                    m.MapRightKey("IntegraDUStages_ID");
                });
        }
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Models.Configuration
{
    public class SteadConfiguration : EntityTypeConfiguration<Stead>
    {
        public SteadConfiguration() : base()
        {
            ToTable("Stead", "fias")
                .HasKey(e => e.STEADID)
                .Property(e => e.STEADID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(e => e.NUMBER)
                .IsUnicode(false);
            Property(e => e.REGIONCODE)
                .IsUnicode(false);
            Property(e => e.POSTALCODE)
                .IsUnicode(false);
            Property(e => e.IFNSFL)
                .IsUnicode(false);
            Property(e => e.TERRIFNSFL)
                .IsUnicode(false);
            Property(e => e.IFNSUL)
                .IsUnicode(false);
            Property(e => e.TERRIFNSUL)
                .IsUnicode(false);
            Property(e => e.OKATO)
                .IsUnicode(false);
            Property(e => e.OKTMO)
                .IsUnicode(false);
            Property(e => e.CADNUM)
                .IsUnicode(false);
        }
    }
}

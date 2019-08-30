using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Models.Configuration
{
    class HouseConfiguration : EntityTypeConfiguration<House>
    {
        public HouseConfiguration() : base()
        {
            ToTable("House", "fias")
                .HasKey(h => h.HOUSEID)
                .Property(p => p.HOUSEID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(e => e.POSTALCODE).IsUnicode(false);
            Property(e => e.IFNSFL).IsUnicode(false);
            Property(e => e.TERRIFNSFL).IsUnicode(false);
            Property(e => e.IFNSUL).IsUnicode(false);
            Property(e => e.TERRIFNSUL).IsUnicode(false);
            Property(e => e.OKATO).IsUnicode(false);
            Property(e => e.OKTMO).IsUnicode(false);
            Property(e => e.HOUSENUM).IsUnicode(false);
            Property(e => e.BUILDNUM).IsUnicode(false);
            Property(e => e.STRUCNUM).IsUnicode(false);
            Property(e => e.CADNUM).IsUnicode(false);
        }
    }
}

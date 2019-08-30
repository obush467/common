using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Models.Configuration
{
    public class RoomConfiguration : EntityTypeConfiguration<Room>
    {
        public RoomConfiguration() : base()
        {
            ToTable("Room", "fias")
                .HasKey(p => p.ROOMID)
                .Property(p => p.ROOMID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(e => e.FLATNUMBER).IsUnicode(false);
            Property(e => e.ROOMNUMBER).IsUnicode(false);
            Property(e => e.REGIONCODE).IsUnicode(false);
            Property(e => e.POSTALCODE).IsUnicode(false);
            Property(e => e.CADNUM).IsUnicode(false);
            Property(e => e.ROOMCADNUM).IsUnicode(false);
        }
    }
}

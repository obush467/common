using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Models.Configuration
{
    public class Room1Configuration : EntityTypeConfiguration<Room1>
    {
        public Room1Configuration() : base()
        {
            ToTable("Room1", "fias");
        }
    }
}


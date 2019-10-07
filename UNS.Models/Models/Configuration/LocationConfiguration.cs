using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Models.Entities.Address;

namespace UNS.Models.Models.Configuration
{
    public class LocationConfiguration: EntityTypeConfiguration<Location>
    {
        public LocationConfiguration() : base()
        {
            ToTable("Location", "address");
        }
    }
}

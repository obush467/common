using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Models.Configuration
{
    public class AddressCodeConfiguration : EntityTypeConfiguration<AddressCode>
    {
        public AddressCodeConfiguration() : base()
        {
            ToTable("AddressCodes", "fias");
            HasKey(s => s.AddressCodeID).Property(p=>p.AddressCodeID);
            //HasRequired(d => d.Address).WithOptional();
        }
    }
}


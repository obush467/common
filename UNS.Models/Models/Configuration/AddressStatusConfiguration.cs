using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;
using UNS.Models.Entities.Fias;

namespace UNS.Models.Models.Configuration
{
  
    public class AddressStatusConfiguration : EntityTypeConfiguration<AddressStatus>
    {
        public AddressStatusConfiguration() : base()
        {
            ToTable("AddressStatuses", "fias");
            HasKey(s => s.AddressStatusID).Property(p => p.AddressStatusID);
            //HasRequired(s => s.AddressBase).WithRequiredDependent();
        }
    }
}

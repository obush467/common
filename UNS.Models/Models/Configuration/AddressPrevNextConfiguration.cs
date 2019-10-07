using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Models.Configuration
{
    public class AddressPrevNextConfiguration : EntityTypeConfiguration<AddressPrevNext>
    {
        public AddressPrevNextConfiguration() : base()
        {
            ToTable("AddressPrevNext", "fias");
            HasKey(s => s.AddressBase_ID);
            HasRequired(s => s.AddressBase).WithRequiredDependent();
        }
    }
}

using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Models.Configuration
{
    public class AccountantGeneralPositionConfiguration : EntityTypeConfiguration<AccountantGeneralPosition>
    {
        public AccountantGeneralPositionConfiguration() : base()
        {
            ToTable("AccountantGeneralPositions");
        }
    }
}
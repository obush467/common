using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Configuration
{
    internal class DUTechnicalCertificateConfiguration : EntityTypeConfiguration<DUTechnicalCertificate>
    {
        public DUTechnicalCertificateConfiguration()
        {
            ToTable("DUTechnicalCertificates");
        }
    }
}
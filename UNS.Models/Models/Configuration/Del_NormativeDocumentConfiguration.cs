using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models
{
    internal class Del_NormativeDocumentConfiguration : EntityTypeConfiguration<Del_NormativeDocument>
    {
        public Del_NormativeDocumentConfiguration()
        {
            ToTable("Del_NormativeDocument", "fias");
            HasKey(h => h.NORMDOCID).Property(p => p.NORMDOCID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(e => e.DOCNAME)
                .IsUnicode(false);
            Property(e => e.DOCNUM)
                .IsUnicode(false);
        }
    }
}
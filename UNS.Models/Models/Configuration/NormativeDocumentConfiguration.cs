using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models
{
    public class NormativeDocumentConfiguration : EntityTypeConfiguration<NormativeDocument>
    {
        public NormativeDocumentConfiguration()
        {
            ToTable("NormativeDocument", "fias");
            HasKey(h => h.NORMDOCID).Property(p => p.NORMDOCID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(e => e.DOCNAME)
                .IsUnicode(false);
            Property(e => e.DOCNUM)
                .IsUnicode(false);
            HasOptional(e => e.NormativeDocument1)
                .WithRequired(e => e.NormativeDocument2);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Models.Entities;

namespace UNS.Models.Models.Configuration
{
    public class integraDUConfiguration : EntityTypeConfiguration<IntegraDU>
    {
        public integraDUConfiguration() : base()
        {
            ToTable("integraDU");
            //HasKey(s => s.ID).Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            HasMany(s => s.IntegraDU_Works).WithOptional().HasForeignKey(s=>s.IntegraDU_ID);
        }
    }
    
}

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
    public class integraDUStagesConfiguration : EntityTypeConfiguration<IntegraDUStages>
    {
        public integraDUStagesConfiguration() : base()
        {
            ToTable("integraDUStages");
            HasKey(t => t.ID).Property(p=>p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
    
}

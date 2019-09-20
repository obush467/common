using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UNS.Models.Entities;

namespace UNS.Models.Models.Configuration
    {
        public class AddressCodeConfiguration: EntityTypeConfiguration<AddressCode>
        {
            public AddressCodeConfiguration() : base()
            {
                ToTable("AddressCodes", "fias");            
                HasKey(s=>s.AddressCode_ID).Property(s=>s.AddressCode_ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                HasRequired(s => s.AddressBase).WithRequiredDependent();
            }
        }
    }


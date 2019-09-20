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
        public class AddressBaseConfiguration: EntityTypeConfiguration<AddressBase>
        {
            public AddressBaseConfiguration() : base()
            {
                ToTable("AddressBases", "fias");
                //HasOptional(s => s.PrevNext).WithOptionalPrincipal(s=>s.AddressBase);            
        }
        }
    }


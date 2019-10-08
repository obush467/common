using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNS.Models.Entities.Fias
{
        public partial class AddressStead : AddressBase
        {

            [StringLength(120)]
            public string NUMBER { get; set; }
            public int? COUNTER { get; set; }
            //public virtual AddressPrevNext PrevNext { get; set; }

        }
    }


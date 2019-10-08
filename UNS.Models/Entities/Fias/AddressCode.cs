namespace UNS.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using UNS.Models.Entities.Fias;

    public class AddressCode
    {
        public Guid ID { get; set; }
        [StringLength(4)]
        public string IFNSFL { get; set; }

        [StringLength(4)]
        public string TERRIFNSFL { get; set; }

        [StringLength(11)]
        public string OKATO { get; set; }

        [StringLength(11)]
        public string OKTMO { get; set; }

        public int DIVTYPE { get; set; }
        public virtual AddressBase AddressBase { get; set; }
    }
}

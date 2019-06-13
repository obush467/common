namespace UNSentityes.Entityes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fias.AllAdress")]
    public partial class AllAdress
    {
        public Guid ID { get; set; }

        public Guid? PARENTGUID { get; set; }

        [StringLength(500)]
        public string itemAddress { get; set; }

        [StringLength(300)]
        public string fullAddress { get; set; }
    }
}

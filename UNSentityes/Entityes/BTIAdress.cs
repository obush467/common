namespace UNSentityes.Entityes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BTIAdress")]
    public partial class BTIAdress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UNOM { get; set; }

        [StringLength(300)]
        public string Adress { get; set; }

        public Guid? HOUSEGUID { get; set; }
    }
}

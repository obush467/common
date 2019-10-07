using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNS.Models.Entities
{
    [Table("ConstractionBase")]
    public class ConstractionBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID {get; set;}
    }
    [Table("ConstractionBase1")]
    public class DU_U: ConstractionBase
    {

    }
}
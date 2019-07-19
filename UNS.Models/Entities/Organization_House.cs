using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNS.Models.Entities
{
    public class Organization_House
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Organization Organization { get; set; }
        public Guid HouseGUID { get; set; }
        public string Source { get; set; }
        public string Contacts { get; set; }
    }
}

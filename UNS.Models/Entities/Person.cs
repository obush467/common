using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UNS.Models.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Patronymic { get; set; }
        [MaxLength(50)]
        public string Family { get; set; }
        public virtual ICollection<PersonPosition> PersonPositions { get; set; }
    }
}

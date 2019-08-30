using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNS.Models.Entities
{
    public class PersonPositionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [MaxLength(200)]
        public string PositionType_Nominative { get; set; }
        [NotMapped]
        public string PositionType { get { return PositionType_Nominative; } set { PositionType_Nominative = value; } }
        [MaxLength(200)]
        public string PositionType_Genitive { get; set; }
        [MaxLength(200)]
        public string PositionType_Dative { get; set; }
        [MaxLength(200)]
        public string PositionType_Accusative { get; set; }
        [MaxLength(200)]
        public string PositionType_Ablative { get; set; }
        [MaxLength(200)]
        public string PositionType_Prepositional { get; set; }

        public virtual ICollection<PersonPosition> PersonPositions { get; set; }
    }
}

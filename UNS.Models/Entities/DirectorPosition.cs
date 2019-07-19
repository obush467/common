using System.ComponentModel.DataAnnotations.Schema;

namespace UNS.Models.Entities
{
    [Table("DirectorPositions")]
    public class DirectorPosition : PersonPosition
    {
        public bool Director { get; set; }
        public virtual Document InstDocument { get; set; }
    }
}

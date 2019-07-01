using System.ComponentModel.DataAnnotations.Schema;

namespace UNSData.Entities
{
    [Table("DirectorPositions")]
    public class DirectorPosition : PersonPosition
    {
        public bool Director { get; set; }
        public virtual Document InstDocument { get; set; }
    }
}

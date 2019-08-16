using System.ComponentModel.DataAnnotations.Schema;

namespace UNS.Models.Entities
{
    public class DirectorPosition : PersonPosition
    {
        public bool Director { get; set; }
        public virtual Document InstDocument { get; set; }
    }
}

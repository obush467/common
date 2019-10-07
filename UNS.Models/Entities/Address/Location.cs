using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNS.Models.Entities.Address
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LocationID { get; set; }
        public DbGeography WGS84 { get; set; }
        public DbGeometry EGKO { get; set; }
        public DbGeometry MGGT { get; set; }
        //public AdmArea AdmArea { get; set; }
        //public AddressBase Address { get; set; }
    }
}

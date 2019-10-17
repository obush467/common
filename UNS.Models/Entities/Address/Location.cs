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
    public class LocationBase
    {
        public Guid LocationBaseID { get; set; }
        public DbGeography WGS84 { get; set; }
        public DbGeography PZ90 { get; set; }
        public DbGeometry EGKO { get; set; }
        public DbGeometry MGGT { get; set; }
        public string ClarificationOfLocation { get; set; }
        public Nullable<Guid> AdmAreaID { get; set; }
        public virtual AdmArea AdministrativeArea { get; set; }
        public byte[] TS { get; set; }
    }
    public class LocationOneAddress:LocationBase
    {
        public Guid AddressID { get; set; }
        public virtual AddressCached Address { get; set; }
    }
    public class LocationManyAddress : LocationBase
    {
        public virtual ICollection<AddressCached> Addresses { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Models.Entities.Address;

namespace UNS.Models.Entities
{
    [Table("InstallationPlace")]
    public class InstallationPlace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public Location Location { get; set; }
        public string RegistrationNumber { get; set; }
        public string InstallationPlaceType { get; set; }
    }
    [Table("DuU")]
    public class DuU:InstallationPlace
    {
        public virtual ConstractionElement AddressObject { get; set; }        
    }
    [Table("DuUD")]
    public class DuUD : DuU
    {
        public virtual ConstractionElement AddressHouse { get; set; }
    }
    [Table("DuLB_U")]
    public class DuLB_U : DuU
    {
        public new LightBoxElement AddressObject { get; set; }
    }
    [Table("DuLB_UD")]
    public class DuLB_UD : DuUD
    {
        public new LightBoxElement AddressHouse { get; set; }
    }
    [Table("DuS")]
    public class DuS : DuU
    {
        public new TwoFieldElement U { get; set; }
    }
    [Table("DU_K_UD")]
    public class DU_K_UD : DuLB_UD
    {
        public DU_K_UD()
        {
            AddressObject = new LightBoxElement()
            {
                Width = 1300,
                Height = 325
            };
            AddressHouse = new LightBoxElement()
            {
                Width = 325,
                Height = 325
            };
            InstallationPlaceType = "ДУ-К-УД";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNS.Models.Entities
{
    [Table("LightBoxElements")]
    public class LightBoxElement:ConstructionElement
    {
        public LightingEquipment LightingEquipment { get; set; }
        public float MaxPower { get; set; }
        public float MaxBrightness { get; set; }
        public float MinPower { get; set; }
        public float MinBrightness { get; set; }
    }
    [Table("LightBoxTwoFieldElements")]
    public class LightBoxTwoFieldElement : TwoFieldElement
    {
        public LightingEquipment LightingEquipment { get; set; }
        public float MaxPower { get; set; }
        public float MaxBrightness { get; set; }
        public float MinPower { get; set; }
        public float MinBrightness { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNS.Models.Entities
{
    public class LightBoxElement:ConstractionElement
    {
        public LightingEquipment LightingEquipment { get; set; }
        public float MaxPower { get; set; }
        public float MaxBrightness { get; set; }
        public float MinPower { get; set; }
        public float MinBrightness { get; set; }
    }
}

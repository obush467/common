using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNS.Models.Entities
{
    public class IntegraDU_work
    {
        public Guid integraDU_workID { get; set; }
        public Guid IntegraDU_ID { get; set; }
        public Nullable<DateTime> DateIssue { get; set; }
        public Nullable<DateTime> DateСompletion { get; set; }
        public Nullable<DateTime> DateReceiptFoto  { get; set; }
        public Nullable<DateTime> DateVerificationFoto { get; set; }
        public Person Worker { get; set; }
        public Person Checker { get; set; }
        [MaxLength(100)]
        public string Rollback { get; set; }

    }
    public class IntegraDU_work_Installation : IntegraDU_work
    { }
    public class IntegraDU_work_Repaint : IntegraDU_work //ремонт
    { }
    public class IntegraDU_work_Connection : IntegraDU_work
    {
        public Nullable<DateTime> DateLightCheck { get; set; }
        public Nullable<DateTime> DateLightCheckReceiptFoto { get; set; }
        public Nullable<DateTime> DateLightCheckVerificationFoto { get; set; }
    }
}

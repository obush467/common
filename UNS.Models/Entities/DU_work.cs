﻿using System;
using System.ComponentModel.DataAnnotations;

namespace UNS.Models.Entities
{
    public class IntegraDU_work
    {
        public Guid integraDU_workID { get; set; }
        public Guid IntegraDU_ID { get; set; }
        public DateTime? DateIssue { get; set; }
        public DateTime? DateСompletion { get; set; }
        public DateTime? DateReceiptFoto { get; set; }
        public DateTime? DateVerificationFoto { get; set; }
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
        public DateTime? DateLightCheck { get; set; }
        public DateTime? DateLightCheckReceiptFoto { get; set; }
        public DateTime? DateLightCheckVerificationFoto { get; set; }
    }
}

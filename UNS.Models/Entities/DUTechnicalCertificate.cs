using System;

namespace UNS.Models.Entities
{
    public class DUTechnicalCertificate:Document
    {
        public Guid HOUSEGUID;

        public string UNIU { get; set; }
        public DateTime OutDate { get; set; }
        public string DUType { get; set; }
        public string Okrug { get; set; }
        public string District { get; set; }
        public string AddressObject { get; set; }
        public string AddressHouse { get; set; }
        public DateTime DateManufacture { get; set; }
        public string ContentObjectFullPath { get; set; }
        public string ContentHouseFullPath { get; set; }
        public string Number { get; set; }
        public string Stage { get; set; }
    }
}

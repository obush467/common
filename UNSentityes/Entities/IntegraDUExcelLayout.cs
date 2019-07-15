using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNSData.Entities
{
    public class IntegraDUExcelLayout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }
        public string Stage { get; set; }
        public int? Number { get; set; }
        public string UNIU { get; set; }
        public string DUType { get; set; }
        public string Okrug { get; set; }
        public string District { get; set; }
        public string AddressObject { get; set; }
        public string AddressHouse { get; set; }
        public string ContentObject { get; set; }
        public string ContentHouse { get; set; }
        public string ContentObjectFullPath { get; set; }
        public string ContentHouseFullPath { get; set; }
    }
}

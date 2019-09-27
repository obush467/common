using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNS.Models.Entities
{
    public class PassportContent:IntegraDUStages
    {
        public string ContentObjectFullPath {get; set;}
        public string ContentHouseFullPath { get; set;}
        public DateTime DateManufacture { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNS.Models.Entities.Address
{
    [Table("AO_Named", Schema = "address")]
    public class AO_Named : AddressObject
    {
        public int? OFFNAME_NUM_TYPE { get; set; }

        public int? OFFNAME_NUM_NUMBER { get; set; }

        public int? OFFNAME_NUM_PREFIX { get; set; }

        [StringLength(20)]
        public string OFFNAME_NUMBER { get; set; }

        [StringLength(20)]
        public string OFFNAME_PREFIX { get; set; }

        [StringLength(80)]
        public string OFFNAME_NAME { get; set; }

        [StringLength(300)]
        public string CONVERTSTREET { get; set; }

        public int? OFFNAME_NUM_NAME { get; set; }

        [StringLength(300)]
        public string OMK_2013 { get; set; }
    }
}

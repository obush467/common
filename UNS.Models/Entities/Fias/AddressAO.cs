using System.ComponentModel.DataAnnotations;

namespace UNS.Models.Entities.Fias
{
    public class AddressAO: AddressBase
    {
        [StringLength(120)]
        public string FORMALNAME { get; set; }
        [StringLength(1)]
        public string AUTOCODE { get; set; }

        [StringLength(3)]
        public string AREACODE { get; set; }

        [StringLength(3)]
        public string CITYCODE { get; set; }

        [StringLength(3)]
        public string CTARCODE { get; set; }

        [StringLength(3)]
        public string PLACECODE { get; set; }

        [StringLength(4)]
        public string STREETCODE { get; set; }
        [StringLength(4)]
        public string EXTRCODE { get; set; }

        [StringLength(3)]
        public string SEXTCODE { get; set; }

        [StringLength(120)]
        public string OFFNAME { get; set; }

        [StringLength(10)]
        public string SHORTNAME { get; set; }

        public int AOLEVEL { get; set; }
        [StringLength(17)]
        public string CODE { get; set; }

        [StringLength(15)]
        public string PLAINCODE { get; set; }

        public int? ACTSTATUS { get; set; }
        public int? CENTSTATUS { get; set; }
        public int? CURRSTATUS { get; set; }

    }
}

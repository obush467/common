using System.ComponentModel.DataAnnotations.Schema;

namespace UNSData.Entities
{
    [Table("AccountantGeneralPositions")]
    public class AccountantGeneralPosition : PersonPosition
    {
        public bool AccountantGeneral { get; set; }
        public Document InstDocument { get; set; }


    }
}

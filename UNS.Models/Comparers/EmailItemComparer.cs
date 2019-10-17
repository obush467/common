using System.Collections.Generic;
using UNS.Models.Entities;

namespace data_mos_ru.Comparers
{
    public class EmailItemComparer : IEqualityComparer<EmailItem>
    {
        public bool Equals(EmailItem x, EmailItem y)
        {
            return (x != null && y != null && !string.IsNullOrEmpty(x.Email) && !string.IsNullOrEmpty(y.Email) && x.Email.ToLower().Trim() == y.Email.ToLower().Trim()) ? true : false;
        }

        public int GetHashCode(EmailItem obj)
        {
            return 0;
        }
    }
}
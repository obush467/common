using System.Collections.Generic;
using UNS.Models.Entities;

namespace data_mos_ru.Comparers
{
    public class PersonPositionComparer : IEqualityComparer<PersonPosition>
    {
        public bool Equals(PersonPosition x, PersonPosition y)
        {
            return (x != null
                && y != null
                && x.PositionType == y.PositionType
                && x.Person.Family.ToLower() == y.Person.Family.ToLower()
                && x.Person.Name.ToLower() == y.Person.Name.ToLower()
                && x.Person.Patronymic.ToLower() == y.Person.Patronymic.ToLower())
                ? true : false;
        }
        public int GetHashCode(PersonPosition obj)
        {
            return 0;
        }
    }
}
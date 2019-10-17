using System.Collections.Generic;
using UNS.Models.Entities;

namespace data_mos_ru.Mappers
{
    public class AddressesComparer : IEqualityComparer<Organization_House>
    {
        public bool Equals(Organization_House x, Organization_House y)
        {
            return (x != null && y != null && x.Organization==y.Organization && x.HouseGUID == y.HouseGUID && x.TypeRelation==y.TypeRelation) ? true : false;
        }

        public int GetHashCode(Organization_House obj)
        {
            return 0;
        }
    }
}
using System.Collections.Generic;
using UNS.Models.Entities;

namespace data_mos_ru.Comparers
{
    public class OwnerRawAddressComparer : IEqualityComparer<OwnerRawAddress>
    {
        public bool Equals(OwnerRawAddress x, OwnerRawAddress y)
        {
            return (x != null
                && y != null
                && x.Organization !=null
                && y.Organization!=null
                & x.Organization == y.Organization
                && x.Address!=null
                && y.Address!=null
                && x.Address.ToLower() == y.Address.ToLower()
                && x.TypeOwner!=null
                && y.TypeOwner!=null
                && x.TypeOwner.ToLower() == y.TypeOwner.ToLower()

                ) ? true : false;
        }

        public int GetHashCode(OwnerRawAddress obj)
        {
            return 0;
        }
    }
}
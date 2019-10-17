using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using UNS.Models.Entities;
using UNS.Models.Entities.Fias;

namespace UNS.Models.Mappers
{
    public class Fias_MapProfile : Profile
    {
        public IMapper Mapper { private get; set; } = new MapperConfiguration(cfg => cfg.AddProfile<Inner_MapProfile>()).CreateMapper();
        public Fias_MapProfile()
        {
            CreateMap<AddressObject, AddressStatus>();
            CreateMap<AddressObject, AddressBase>()
                .ForMember(s => s.ID, d => d.MapFrom(m => m.AOID))
                .ForMember(s => s.GUID, d => d.MapFrom(m => m.AOGUID))
                .ForMember(s => s.Code, d => d.MapFrom((s,dest,m) =>
                {
                    var res = Mapper.Map<AddressObject, AddressCode>(s);
                    res.Address = dest;
                    return res;
                }))
                .ForMember(s => s.RootStatus, d => d.MapFrom((s, dest, m) =>
                {
                    var res = Mapper.Map<AddressObject, AddressStatus>(s);
                    res.Base = dest;
                    return res;
                }))
                //.ForMember(s=>s.NEXT,d=>d.MapFrom((s, dest, m) =>new List<AddressBase>() { s.NEXTID }))
                ;
            CreateMap<AddressObject, AddressAO>()
                .IncludeBase<AddressObject, AddressBase>()
                .IncludeMembers()
                .IncludeAllDerived()
                ;
            CreateMap<Stead, AddressStead>()
                .ForMember(s => s.ID, d => d.MapFrom(m => m.STEADID))
                .ForMember(s => s.GUID, d => d.MapFrom(m => m.PARENTGUID));
            CreateMap<Room, AddressRoom>()
                .ForMember(s => s.ID, d => d.MapFrom(m => m.ROOMID))
                .ForMember(s => s.GUID, d => d.MapFrom(m => m.HOUSEGUID));
        }
    }

    public class Inner_MapProfile : Profile
    {
        public Inner_MapProfile()
        {
            CreateMap<AddressObject, AddressCode>();
            //.ForMember(s => s.AddressBase_ID, d => d.MapFrom(m => m.AOID));
            CreateMap<AddressObject, AddressStatus>();
        }
    }
}

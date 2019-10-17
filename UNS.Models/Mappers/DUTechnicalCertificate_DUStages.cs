using AutoMapper;
using UNS.Models.Entities;

namespace UNS.Models.Mappers
{
    public class DUTechnicalCertificate_DUStages : Profile
    {
        public DUTechnicalCertificate_DUStages()
        {
            CreateMap<IntegraDUStages, DUTechnicalCertificate>();
            CreateMap<DUTechnicalCertificate, IntegraDUStages>();
        }
    }
}

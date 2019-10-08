using AutoMapper;
using UNS.Models.Entities;

namespace UNS.Models.Mappers
{
    public class PassportContent_DUStages : Profile
    {
        public PassportContent_DUStages()
        {
            CreateMap<IntegraDUStages, DUTechnicalCertificate>();
            CreateMap<DUTechnicalCertificate, IntegraDUStages>();

        }
    }
}

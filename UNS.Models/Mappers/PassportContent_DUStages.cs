using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Models.Entities;

namespace UNS.Models.Mappers
{
    public class PassportContent_DUStages:Profile
    {
        public PassportContent_DUStages()
        {
            CreateMap<IntegraDUStages, PassportContent>();
            CreateMap<PassportContent,IntegraDUStages > ();

        }
    }
}

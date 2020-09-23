using AutoMapper;
using PerfumeSale.Core.Entities;
using PerfumeSale.WepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfumeSale.WepAPI.AutoMapper
{
    public class MapProfile : Profile
    {
       public MapProfile()
        {
            CreateMap<Perfume, PerfumeAddModel>();
            CreateMap<PerfumeAddModel, Perfume>();

            CreateMap<Perfume, PerfumeUpdateModel>();
            CreateMap<PerfumeUpdateModel, Perfume>();
        }
    }
}

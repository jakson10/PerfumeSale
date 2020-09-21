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
            //CreateMap<Order, OrderDto>();
            //CreateMap<OrderDto, Order>();

            //CreateMap<Brand, BrandDto>();
            //CreateMap<BrandDto, Brand>();

            //CreateMap<Perfume, PerfumeDto>();
            //CreateMap<PerfumeDto, Perfume>();

            //CreateMap<OrderDetail, OrderDetailDto>();
            //CreateMap<OrderDetailDto, OrderDetail>();

            //CreateMap<UserDetail, UserDetailDto>();
            //CreateMap<UserDetailDto, UserDetail>();

            CreateMap<Perfume, PerfumeAddModel>();
            CreateMap<PerfumeAddModel, Perfume>();

            CreateMap<Perfume, PerfumeUpdateModel>();
            CreateMap<PerfumeUpdateModel, Perfume>();
        }
    }
}

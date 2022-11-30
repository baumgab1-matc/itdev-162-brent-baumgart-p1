using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOModels;
using Domain.DTOModels.Grad;
using Domain.DTOModels.Item;

namespace Domain
{
    public class MapperConfig : Profile
    {
        public MapperConfig() {
            // GRAD MAPPINGS
            CreateMap<Grad, CreateGradDTO>().ReverseMap();
            CreateMap<Grad, GetGradDTO>().ReverseMap();
            CreateMap<Grad, UpdateGradDTO>().ReverseMap();

            // ITEM MAPPINGS
            CreateMap<Item, CreateItemDTO>().ReverseMap();
            CreateMap<Item, GetItemDTO>().ReverseMap();
            CreateMap<Item, UpdateItemDTO>().ReverseMap();
        }
    }
}
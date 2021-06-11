using AutoMapper;
using NetNLayerApp.API.DTOs;
using NetNLayerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetNLayerApp.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //karsilikli donusturme
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}

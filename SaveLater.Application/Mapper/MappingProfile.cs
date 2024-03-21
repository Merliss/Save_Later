using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SaveLater.Application.Functions.Posts;
using SaveLater.Domain.Entities;

namespace SaveLater.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<Post,PostInListViewModel>()
                .ReverseMap();
           CreateMap<Post,PostDetalViewModel>() 
                .ReverseMap();
            CreateMap<Category, CategoryDto>();
        }
    }
}

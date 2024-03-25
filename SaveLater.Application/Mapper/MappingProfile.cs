﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SaveLater.Application.Functions.Categories.Queries;
using SaveLater.Application.Functions.Categories.Queries.GetCategoryListWithPosts;
using SaveLater.Application.Functions.Posts.Queries.GetPostDetail;
using SaveLater.Application.Functions.Posts.Queries.GetPostsList;
using SaveLater.Domain.Entities;

namespace SaveLater.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<Post,PostInListViewModel>()
                .ReverseMap();
           CreateMap<Post,PostDetailViewModel>() 
                .ReverseMap();
            CreateMap<Category, CategoryDto>();

            CreateMap<Category, CategoryInListViewModel>();
            CreateMap<Category, CategoryPostDto>();
            CreateMap<Category, CategoryPostListViewModel>();
        }
    }
}

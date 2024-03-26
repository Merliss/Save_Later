using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SaveLater.Application.Functions.Categories.Commands;
using SaveLater.Application.Functions.Categories.Queries;
using SaveLater.Application.Functions.Categories.Queries.GetCategoryListWithPosts;
using SaveLater.Application.Functions.Events.Queries.GetEventListByDate;
using SaveLater.Application.Functions.Posts.Commands.CreatePost;
using SaveLater.Application.Functions.Posts.Commands.DeletePost;
using SaveLater.Application.Functions.Posts.Commands.UpdatePost;
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

            CreateMap<Post,CreatePostCommand>().ReverseMap();
            CreateMap<Post, UpdatePostCommand>().ReverseMap();
            CreateMap<Post, DeletePostCommand>().ReverseMap();


            CreateMap<Category,CreateCategoryCommand>().ReverseMap();

            CreateMap<Event,EventsByDateViewModel>().ReverseMap();

            CreateMap<Event, CreateCategoryCommand>().ReverseMap();


        }
    }
}

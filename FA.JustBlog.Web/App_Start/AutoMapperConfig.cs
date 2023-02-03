
using AutoMapper;
using FA.JustBlog.Model;
using FA.JustBlog.ViewModels.Category;
using FA.JustBlog.ViewModels.Post;
using FA.JustBlog.ViewModels.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.JustBlog.Core.App_Start
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //CreateMap<Post, PostViewModel>().ReverseMap();
            CreateMap<Post, CreatePostViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Tag, TagViewModel>().ReverseMap();
        }
    }
}
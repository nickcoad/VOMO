using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpressMapper;
using VOMO.Api.Models.Resources;
using VOMO.Context.Entities;
using VOMO.Web.Models;

namespace VOMO.Web
{
    public static class MapperConfig
    {
        public static void Configure()
        {
            Mapper.Register<Post, PostViewModel>()
                .Member(dest => dest.Content, src => src.Content)
                .Member(dest => dest.Title, src => src.Title)
                .Member(dest => dest.CreatedAt, src => src.CreatedAt)
                .Member(dest => dest.UpdatedAt, src => src.UpdatedAt);

            Mapper.Register<Post, PostResource>()
                .Member(dest => dest.Id, src => src.Id)
                .Member(dest => dest.Content, src => src.Content)
                .Member(dest => dest.Title, src => src.Title)
                .Member(dest => dest.CreatedAt, src => src.CreatedAt)
                .Member(dest => dest.UpdatedAt, src => src.UpdatedAt)
                .Ignore(dest => dest.Tags)
                .Ignore(dest => dest.Author);

            Mapper.Register<Tag, TagResource>()
                .Member(dest => dest.Id, src => src.Id)
                .Member(dest => dest.Name, src => src.Name)
                .Member(dest => dest.Slug, src => src.Slug)
                .Member(dest => dest.CreatedAt, src => src.CreatedAt)
                .Member(dest => dest.UpdatedAt, src => src.UpdatedAt);

            Mapper.Register<User, AuthorResource>()
                .Member(dest => dest.Id, src => src.Id)
                .Member(dest => dest.GivenName, src => src.GivenName)
                .Member(dest => dest.Surname, src => src.Surname)
                .Member(dest => dest.UserName, src => src.UserName)
                .Member(dest => dest.CreatedAt, src => src.CreatedAt)
                .Member(dest => dest.UpdatedAt, src => src.UpdatedAt)
                .Ignore(dest => dest.Posts);
        }
    }
}
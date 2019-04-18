using System;
using AutoMapper;
using EwuConnect.Domain.Models.Profile;
using EwuConnect.Api.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using EwuConnect.Domain.Models.Forum;

namespace EwuConnect.Api.Models
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {


            CreateMap<User, UserViewModel>();
            CreateMap<UserInputViewModel, User>();
            CreateMap<UserUpdateViewModel, UserViewModel>();

            CreateMap<EducationInputViewModel, Education>();
            CreateMap<Education, EducationViewModel>();

            CreateMap<Post, PostViewModel>();
            CreateMap<PostInputViewModel, Post>();

            CreateMap<Response, ResponseViewModel>();
            CreateMap<ResponseInputViewModel, Response>();

        }
    }
}

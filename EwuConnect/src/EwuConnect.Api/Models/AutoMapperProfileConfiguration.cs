using System;
using AutoMapper;
using EwuConnect.Domain.Models.Profile;
using EwuConnect.Api.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace EwuConnect.Api.Models
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {


            CreateMap<User, UserViewModel>();
            CreateMap<UserInputViewModel, User>();

            CreateMap<EducationInputViewModel, Education>();
            CreateMap<Education, EducationViewModel>();
        }
    }
}

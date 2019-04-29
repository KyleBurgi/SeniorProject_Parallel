using System;
using AutoMapper;
using EwuConnect.Domain.Models.Profile;
using EwuConnect.Api.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using EwuConnect.Domain.Models.Forum;
using EwuConnect.Domain.Models.Chat;

namespace EwuConnect.Api.Models
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {

            //Profile
            CreateMap<User, UserViewModel>();
            CreateMap<UserInputViewModel, User>();
            CreateMap<UserUpdateViewModel, UserViewModel>();

            CreateMap<EducationInputViewModel, Education>();
            CreateMap<Education, EducationViewModel>();

            CreateMap<WorkExperience, WorkExperienceViewModel>();
            CreateMap<WorkExperienceInputViewModel, WorkExperience>();

            //Forum
            CreateMap<Post, PostViewModel>();
            CreateMap<PostInputViewModel, Post>();

            CreateMap<Response, ResponseViewModel>();
            CreateMap<ResponseInputViewModel, Response>();

            //Chat
            CreateMap<Conversation, ConversationViewModel>();
            CreateMap<ConversationInputViewModel, Conversation>();

            CreateMap<Message, MessageViewModel>();
            CreateMap<MessageInputViewModel, Message>();
        }
    }
}

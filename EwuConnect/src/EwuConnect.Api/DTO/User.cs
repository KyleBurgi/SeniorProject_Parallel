using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EwuConnect.Domain.Models.Profile.SkillKeywords;

namespace EwuConnect.Api.DTO
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameTitle { get; set; }


        //REMOVED FOR THE SAKE OF TESTING AND DEVELOPMENT
        //TODO

        public User() { }
        public User(EwuConnect.Domain.Models.Profile.User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            NameTitle = user.NameTitle;
        }
    }
}
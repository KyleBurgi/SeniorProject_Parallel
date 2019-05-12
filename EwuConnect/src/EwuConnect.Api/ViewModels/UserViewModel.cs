using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EwuConnect.Domain.Models.Profile;
using EwuConnect.Domain.Models.Profile.SkillKeywords;

namespace EwuConnect.Api.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        //Name
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameTitle { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
        public ContactInformation ContactInformation { get; set; }
        public bool Mentor { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EwuConnect.Domain.Models.Profile.SkillKeywords;

namespace EwuConnect.Domain.Models.Profile
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameTitle { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
        public ContactInformation ContactInformation { get; set; }
        bool Mentor { get; set; }
    }
}
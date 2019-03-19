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

        //Name
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string NameTitle { get; set; } //Mrs., Mr., Dr., etc...

        //Personal Biography
        public string PersonalBio { get; set; }

        //Education
        public List<Education> EducationHistory { get; set; }

        //ContactInfo
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
        public string City { get; set; }

    }

    public class Mentor : User
    {
        //Mentor Tags
        private List<SkillKeyword> SkillKeywords { get; set; }

        //Work History - only for mentors
        public List<WorkExperience> WorkHistory { get; set; }

    }

    public class Mentee : User
    {

    }
}
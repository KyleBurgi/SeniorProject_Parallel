using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EwuConnect.Domain.Models.Profile;

namespace EwuConnect.Api.ViewModels
{
    public class UserInputViewModel
    {

        //Name
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameTitle { get; set; }


        //Personal Biography
        public string PersonalBio { get; set; }

        //Education
        //public List<Education> EducationHistory { get; set; }
        //public List<WorkExperience> WorkExperience { get; set; }

        //ContactInfo
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
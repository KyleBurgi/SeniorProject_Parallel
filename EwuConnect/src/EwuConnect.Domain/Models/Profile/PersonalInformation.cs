using System;
using System.Collections.Generic;

namespace EwuConnect.Domain.Models.Profile
{
    public class PersonalInformation
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public string PersonalBio { get; set; }
        public List<Education> EducationHistory { get; set; }
        public List<WorkExperience> WorkExperience { get; set; }
    }
}

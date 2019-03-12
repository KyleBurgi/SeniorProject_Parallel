using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EwuConnect.Domain.Models.Profile
{
    public class User
    {
        public int Id { get; set; }

        //Name
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameTitle { get; set; } //Mrs., Mr., Dr., etc...

        //Personal Biography
        public string PersonalBio { get; set; }

        //Education
        public List<Education> Education { get; set; }

        //Work History - only for mentors
        public string CurrentJob { get; set; }
        //public List<string> WorkHistory { get; set; }

        //ContactInfo
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
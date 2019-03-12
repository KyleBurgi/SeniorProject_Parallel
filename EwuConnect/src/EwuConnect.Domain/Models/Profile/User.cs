using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EwuConnect.Domain.Models.Profile
{
    public class User : Entity
    {
        //public int UserId { get; set; }

        //Name
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        public string NameTitle { get; set; } //Mrs., Mr., Dr., etc...

        //Personal Biography
        public string PersonalBio { get; set; }

        //Education
        //public List<Education> EducationHistory { get; set; }

        //Work History - only for mentors
        public string CurrentJob { get; set; }
        //public List<string> WorkHistory { get; set; }

        //ContactInfo
        [Required]
        public string Email { get; set; }
        [Required] //Not displayed but required for contact
        public string PhoneNumber { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
    }

    //CREATE TABLE [User] [Id] as PrimaryKey, [FirstName] as String, [LastName] as String
}

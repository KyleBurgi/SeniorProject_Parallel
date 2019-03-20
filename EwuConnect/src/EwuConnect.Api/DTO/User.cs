using System;
using System.Collections.Generic;

namespace EwuConnect.Api.DTO
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
        public List<Education> EducationHistory { get; set; }

        //ContactInfo
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public User() {}

        public User(EwuConnect.Domain.Models.Profile.User user) 
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            NameTitle = user.NameTitle;
            PersonalBio = user.PersonalBio;

            //TODO
            //FIGURE THIS OUT
            /*
            foreach (var item in EducationHistory)
            {
                EducationHistory = (DTO.Education) item;
            }
            */
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            State = user.State;
            City = user.City;
        }
    }
}

using System;
using EwuConnect.Domain.Models.Profile;

namespace EwuConnect.Api.ViewModels
{
    public class UserUpdateViewModel
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

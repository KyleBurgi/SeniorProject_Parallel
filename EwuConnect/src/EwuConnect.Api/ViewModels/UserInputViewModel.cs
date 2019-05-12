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
        public PersonalInformation PersonalInformation { get; set; }
        public ContactInformation ContactInformation { get; set; }
        public bool Mentor { get; set; }
    }
}
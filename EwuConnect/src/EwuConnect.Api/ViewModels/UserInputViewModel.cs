using System.ComponentModel.DataAnnotations;

namespace EwuConnect.Api.ViewModels
{
    public class UserInputViewModel
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameTitle { get; set; }
    }
}
using System;
namespace EwuConnect.Domain.Models.Profile
{
    public class UserEducation
    {
        public int EducationId { get; set; }
        public Education Education { get; set; }
        public int UserId { get; set; } 
        public User User { get; set; }
    }
}

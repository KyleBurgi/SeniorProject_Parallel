using System;
namespace EwuConnect.Domain.Models.Profile
{
    public class UserWorkExperience
    {
        public int WorkExperienceId { get; set; }
        public WorkExperience WorkExperience { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

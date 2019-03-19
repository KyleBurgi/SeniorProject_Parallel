using System;
using System.ComponentModel.DataAnnotations;

namespace EwuConnect.Domain.Models.Profile
{
    public class WorkExperience
    {
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string StartMonth { get; set; }
        public int StartYear { get; set; }
        public string EndMonth { get; set; }
        public int EndYear { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}

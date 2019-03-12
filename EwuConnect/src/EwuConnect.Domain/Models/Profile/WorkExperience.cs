using System;
namespace EwuConnect.Domain.Models.Profile
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string StartMonth { get; set; }
        public int StartYear { get; set; }
        public string EndMonth { get; set; }
        public int EndYear { get; set; }

    }
}

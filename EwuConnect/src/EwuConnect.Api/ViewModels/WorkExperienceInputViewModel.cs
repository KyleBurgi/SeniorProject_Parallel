using System;
using System.ComponentModel.DataAnnotations;

namespace EwuConnect.Api.ViewModels
{
    public class WorkExperienceInputViewModel
    {
        [Required]
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string StartMonth { get; set; }
        public int StartYear { get; set; }
        public string EndMonth { get; set; }
        public int EndYear { get; set; }
    }
}

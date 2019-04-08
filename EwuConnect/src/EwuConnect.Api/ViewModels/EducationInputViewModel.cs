using System;
using System.ComponentModel.DataAnnotations;

namespace EwuConnect.Api.ViewModels
{
    public class EducationInputViewModel
    {
        [Required]
        public string CollegeName { get; set; }
        public string FieldOfStudy { get; set; }
        public string LevelOfDegree { get; set; }
        public int YearGraduated { get; set; }
    }
}

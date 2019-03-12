using System;
using System.ComponentModel.DataAnnotations;

namespace EwuConnect.Domain.Models.Profile
{
    public class Education
    {
        public int Id { get; set; }
        [Required]
        public string CollegeName { get; set; }
        [Required]
        public string FieldOfStudy { get; set; }
        public string LevelOfDegree { get; set; } //Associates, Bachelors, Masters, Doctorate
        public int YearGraduated { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace EwuConnect.Api.ViewModels
{
    public class EducationViewModel
    {
        public int Id { get; set; }
        public string CollegeName { get; set; }
        public string FieldOfStudy { get; set; }
        public string LevelOfDegree { get; set; } 
        public int YearGraduated { get; set; }

    }
}

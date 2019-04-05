using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EwuConnect.Domain.Models.Profile
{
    public class Education
    {
        public int Id { get; set; }
        public string CollegeName { get; set; }
        public string FieldOfStudy { get; set; }
        public string LevelOfDegree { get; set; }
        public int YearGraduated { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}



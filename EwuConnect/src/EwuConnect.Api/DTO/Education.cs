using System;
using System.Collections.Generic;

namespace EwuConnect.Api.DTO
{
    public class Education
    {
        //ALL PROPERTIES MUST BE SERIALIZABLE AND SETTABLE TO BE SERIALIZABLE
        public int Id { get; set; }
        public string CollegeName { get; set; }
        public string FieldOfStudy { get; set; }
        public string LevelOfDegree { get; set; } 
        public int YearGraduated { get; set; }

        //Don't need these as to not expose the backend
        //public int UserId { get; set; }   
        //public User User { get; set; }    

        public Education() { } //EACH DTO MUST HAVE EMPTY CONSTRUCTOR FOR SERIALIZBLE TO WORK

        public Education(EwuConnect.Domain.Models.Profile.Education education)
        {
            if (education == null)
            {
                throw new ArgumentNullException(nameof(education));
            }

            Id = education.Id;
            CollegeName = education.CollegeName;
            FieldOfStudy = education.FieldOfStudy;
            LevelOfDegree = education.LevelOfDegree;
            YearGraduated = education.YearGraduated;
        }
    }
}

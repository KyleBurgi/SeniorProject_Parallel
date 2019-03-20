using System;
namespace EwuConnect.Api.DTO
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

        public WorkExperience() { }

        public WorkExperience(EwuConnect.Domain.Models.Profile.WorkExperience workExperience)
        {

            if (workExperience == null)
            {
                throw new ArgumentNullException(nameof(workExperience));
            }

            Id = workExperience.Id;
            CompanyName = workExperience.CompanyName;
            JobTitle = workExperience.JobTitle;
            JobDescription = workExperience.JobDescription;
            StartMonth = workExperience.StartMonth;
            StartYear = workExperience.StartYear;
            EndMonth = workExperience.EndMonth;
            EndYear = workExperience.EndYear;
        }
    }
}

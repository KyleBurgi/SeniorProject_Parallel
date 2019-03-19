using System;
using System.Collections.Generic;
using EwuConnect.Domain.Models.Profile;

namespace EwuConnect.Domain.Services.Interfaces
{
    public interface IWorkExperienceService
    {
        /*CRUD*/
        void AddWorkExperience(WorkExperience workExperience);
        void UpdateWorkExperience(WorkExperience workExperience);
        WorkExperience GetWorkExperience(int workExperienceId);
        bool DeleteWorkExperience(int workExperienceId);
        List<WorkExperience> GetWorkExperienceForUser(int userId);
    }
}

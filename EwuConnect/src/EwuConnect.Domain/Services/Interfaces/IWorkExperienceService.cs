using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EwuConnect.Domain.Models.Profile;

namespace EwuConnect.Domain.Services.Interfaces
{
    public interface IWorkExperienceService
    {
        /*CRUD*/
        Task<WorkExperience> AddWorkExperience(WorkExperience workExperience);
        Task<WorkExperience> UpdateWorkExperience(WorkExperience workExperience);
        Task<WorkExperience> GetWorkExperience(int workExperienceId);
        Task<bool> DeleteWorkExperience(int workExperienceId);
        Task<List<WorkExperience>> GetWorkExperienceForUser(int userId);
    }
}

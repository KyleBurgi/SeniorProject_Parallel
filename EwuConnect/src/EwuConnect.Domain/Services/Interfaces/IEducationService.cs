using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EwuConnect.Domain.Models.Profile;

namespace EwuConnect.Domain.Services.Interfaces
{
    public interface IEducationService
    {
        /*CRUD*/
        Task<Education> AddEducation(Education education);
        Task<Education> UpdateEducation(Education education);
        Task<Education> GetEducation(int educationId);
        Task<bool> DeleteEducation(int educationId);
        Task<List<Education>> GetEducationForUser(int userId);

    }
}

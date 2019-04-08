using System;
using System.Collections.Generic;
using EwuConnect.Domain.Models.Profile;

namespace EwuConnect.Domain.Services.Interfaces
{
    public interface IEducationService
    {
        /*CRUD*/
        Education AddEducation(Education education);
        void UpdateEducation(Education education);
        Education GetEducation(int educationId);
        bool DeleteEducation(int educationId);
        List<Education> GetEducationForUser(int userId);

    }
}

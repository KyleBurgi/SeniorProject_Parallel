using System;
using System.Collections.Generic;
using EwuConnect.Domain.Models.Profile;
using EwuConnect.Domain.Services.Interfaces;

namespace EwuConnect.Api.Tests.TestableServices
{
    public class TestableEducationService : IEducationService
    {
        public List<Education> ToReturn { get; set; }
        public int GetEducationForUser_UserId { get; set; }

        public void AddEducation(Education education)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEducation(int educationId)
        {
            throw new NotImplementedException();
        }

        public Education GetEducation(int educationId)
        {
            throw new NotImplementedException();
        }

        public List<Education> GetEducationForUser(int userId)
        {
            GetEducationForUser_UserId = userId;
            return ToReturn;
        }

        public void UpdateEducation(Education education)
        {
            throw new NotImplementedException();
        }
    }
}

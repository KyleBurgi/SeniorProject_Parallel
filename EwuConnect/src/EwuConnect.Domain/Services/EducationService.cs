using System;
using System.Collections.Generic;
using System.Linq;
using EwuConnect.Domain.Models;
using EwuConnect.Domain.Models.Profile;
using EwuConnect.Domain.Services.Interfaces;

namespace EwuConnect.Domain.Services
{
    //TODO
    //* 
    //* Should be made Async
    //* Exceptions
    //* 

    public class EducationService : IEducationService
    {
        private ApplicationDbContext DbContext { get; }

        public EducationService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddEducation(Education education) 
        {
            DbContext.Education.Add(education);
            DbContext.SaveChanges();
        }

        public Education GetEducation(int educationId)
        {
            return DbContext.Education.SingleOrDefault(e => e.Id == educationId);
        }

        public void UpdateEducation(Education education)
        {
            DbContext.Education.Update(education);
            DbContext.SaveChanges();
        }

        public bool DeleteEducation(int educationId)
        {
            Education grabbedEducation = GetEducation(educationId);
            if(grabbedEducation != null)
            {
                DbContext.Education.Remove(grabbedEducation);
                DbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Education> GetEducationForUser(int userId)
        {
            return DbContext.Education.Where(e => e.UserId == userId).ToList();
        }
    }
}

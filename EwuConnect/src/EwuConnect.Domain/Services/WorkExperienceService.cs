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
    //* 

    public class WorkExperienceService : IWorkExperienceService
    {
        private ApplicationDbContext DbContext { get; }

        public WorkExperienceService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void AddWorkExperience(WorkExperience workExperience)
        {
            DbContext.WorkExperience.Add(workExperience);
            DbContext.SaveChanges();
        }

        public WorkExperience GetWorkExperience(int id)
        {
            return DbContext.WorkExperience.SingleOrDefault(e => e.Id == id);
        }

        public void UpdateWorkExperience(WorkExperience workExperience)
        {
            DbContext.WorkExperience.Update(workExperience);
            DbContext.SaveChanges();
        }

        public bool DeleteWorkExperience(int id)
        {
            WorkExperience grabbedWorkExperience = GetWorkExperience(id);
            if (grabbedWorkExperience != null)
            {
                DbContext.WorkExperience.Remove(grabbedWorkExperience);
                DbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<WorkExperience> GetWorkExperienceForUser(int userId)
        {
            return DbContext.WorkExperience.Where(e => e.UserId == userId).ToList();
        }
    }
}

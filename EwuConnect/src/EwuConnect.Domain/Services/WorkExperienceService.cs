using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EwuConnect.Domain.Models;
using EwuConnect.Domain.Models.Profile;
using EwuConnect.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<WorkExperience> AddWorkExperience(WorkExperience workExperience)
        {
            DbContext.WorkExperience.Add(workExperience);
            await DbContext.SaveChangesAsync();
            return workExperience;
        }

        public async Task<WorkExperience> GetWorkExperience(int id)
        {
            return await DbContext.WorkExperience.FindAsync(id);
                
        }

        public async Task<WorkExperience> UpdateWorkExperience(WorkExperience workExperience)
        {
            DbContext.WorkExperience.Update(workExperience);
            await DbContext.SaveChangesAsync();

            return workExperience;
        }

        public async Task<bool> DeleteWorkExperience(int id)
        {
            WorkExperience grabbedWorkExperience = await DbContext.WorkExperience.FindAsync(id);
            if (grabbedWorkExperience != null)
            {
                DbContext.WorkExperience.Remove(grabbedWorkExperience);
                await DbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<WorkExperience>> GetWorkExperienceForUser(int userId)
        {
            return await DbContext.WorkExperience
                .Where(e => e.UserId == userId).ToListAsync();
        }
    }
}

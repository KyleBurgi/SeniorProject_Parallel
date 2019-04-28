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
    //* Exceptions
    //* 

    public class EducationService : IEducationService
    {
        private ApplicationDbContext DbContext { get; }

        public EducationService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Education> AddEducation(Education education) 
        {
            DbContext.Education.Add(education);
            await DbContext.SaveChangesAsync();

            return education;
        }

        public async Task<Education> GetEducation(int educationId)
        {
            return await DbContext.Education.FindAsync(educationId);
        }

        public async Task<Education> UpdateEducation(Education education)
        {
            DbContext.Education.Update(education);
            await DbContext.SaveChangesAsync();
            return education;
        }

        public async Task<bool> DeleteEducation(int educationId)
        {
            Education grabbedEducation = await DbContext.Education.FindAsync(educationId);
            if(grabbedEducation != null)
            {
                DbContext.Education.Remove(grabbedEducation);
                await DbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Education>> GetEducationForUser(int userId)
        {
            return await DbContext.Education.Where(e => e.UserId == userId).ToListAsync();
        }
    }
}

using System;
using System.Linq;
using EwuConnect.Domain.Models;
using EwuConnect.Domain.Models.Profile;

namespace EwuConnect.Domain.Services
{
    /*
        TODO:
            Async
    */
    public class EducationService
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

        public Education GetEducation(int id)
        {
            return DbContext.Education.SingleOrDefault(e => e.Id == id);
        }

        public void UpdateEducation(Education education)
        {
            DbContext.Education.Update(education);
            DbContext.SaveChanges();
        }

        public bool DeleteEducation(int id)
        {
            Education grabbedEducation = GetEducation(id);
            if(grabbedEducation != null)
            {
                DbContext.Education.Remove(grabbedEducation);
                DbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

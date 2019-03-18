using System;
using EwuConnect.Domain.Models;
using EwuConnect.Domain.Models.Profile;
using EwuConnect.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EwuConnect.Domain.Tests.Services.Profile
{
    [TestClass]
    public class EducationServiceTests : DatabaseServiceTests
    {
        [TestMethod]
        public void InitCreate_AddGift_Pass()
        {
            using (ApplicationDbContext context = new ApplicationDbContext(Options))
            {
                EducationService eService = new EducationService(context);
                UserService uService = new UserService(context);

                User user = new User
                {
                    FirstName = "Kyle",
                    LastName = "Burgi"
                };

                Education edu = new Education
                {
                    CollegeName = "Eastern Washington University",
                    YearGraduated = 2020,
                    FieldOfStudy = "Computer Science"
                };

                uService.AddUser(user);
                eService.AddEducation(edu);

                Assert.AreNotEqual(0, edu.Id);

                Education fetchEducation = eService.GetEducation(1);
                Assert.AreEqual(1, fetchEducation.Id);
            }

        }
    }
}

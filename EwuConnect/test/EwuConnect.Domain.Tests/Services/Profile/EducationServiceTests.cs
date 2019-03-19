using System;
using System.Collections.Generic;
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
        public void InitCreate_AddEducation_Pass()
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

                uService.AddUser(user);

                Education edu = new Education
                {
                    CollegeName = "Eastern Washington University",
                    FieldOfStudy = "Computer Science",
                    UserId = user.Id
                };

                eService.AddEducation(edu);

                Assert.AreNotEqual(0, edu.Id);

                Education fetchEducation = eService.GetEducation(1);
                Assert.AreEqual(1, fetchEducation.Id);
                Assert.AreEqual(1, fetchEducation.UserId);
                Assert.AreEqual("Kyle", fetchEducation.User.FirstName);
            }
        }

        [TestMethod]
        public void GetEducation_Pass()
        {
            using (ApplicationDbContext context = new ApplicationDbContext(Options))
            {
                EducationService educationService = new EducationService(context);
                UserService userService = new UserService(context);

                User user = new User
                {
                    FirstName = "Kyle",
                    LastName = "Burgi"
                };

                userService.AddUser(user);

                Education edu = new Education
                {
                    CollegeName = "Eastern Washington University",
                    FieldOfStudy = "Computer Science",
                    UserId = user.Id
                };

                educationService.AddEducation(edu);
            }

            using (ApplicationDbContext context = new ApplicationDbContext(Options))
            {
                EducationService educationService = new EducationService(context);
                Education fetchedEducation = educationService.GetEducation(1);

                Assert.AreEqual("Eastern Washington University", fetchedEducation.CollegeName);
                Assert.AreEqual(1, fetchedEducation.UserId);
            }
        }

        [TestMethod]
        public void UpdateEducation_Pass()
        {
            using (ApplicationDbContext context = new ApplicationDbContext(Options))
            {
                EducationService educationService = new EducationService(context);
                UserService userService = new UserService(context);

                User user = new User
                {
                    FirstName = "Kyle",
                    LastName = "Burgi"
                };

                userService.AddUser(user);

                Education edu = new Education
                {
                    CollegeName = "Eastern Washington University",
                    FieldOfStudy = "Computer Science",
                    UserId = user.Id
                };

                educationService.AddEducation(edu);
            }

            using (ApplicationDbContext context = new ApplicationDbContext(Options))
            {
                EducationService educationService = new EducationService(context);
                UserService userService = new UserService(context);

                List<User> users = userService.GetBatchUsers();
                List<Education> userEdcuation = educationService.GetEducationForUser(users[0].Id);

                Assert.IsTrue(userEdcuation.Count > 0);

                userEdcuation[0].CollegeName = "Gonzaga University";
                educationService.UpdateEducation(userEdcuation[0]);
            }

            using (ApplicationDbContext context = new ApplicationDbContext(Options))
            {
                EducationService educationService = new EducationService(context);
                UserService userService = new UserService(context);

                List<User> users = userService.GetBatchUsers();
                List<Education> userEdcuation = educationService.GetEducationForUser(users[0].Id);

                Assert.AreEqual("Gonzaga University", userEdcuation[0].CollegeName);
            }
        }

        [TestMethod]
        public void DeleteEducation_Pass()
        {
            using (ApplicationDbContext context = new ApplicationDbContext(Options))
            {
                EducationService educationService = new EducationService(context);
                UserService userService = new UserService(context);

                User user = new User
                {
                    FirstName = "Kyle",
                    LastName = "Burgi"
                };

                userService.AddUser(user);

                Education edu = new Education
                {
                    CollegeName = "Eastern Washington University",
                    FieldOfStudy = "Computer Science",
                    UserId = user.Id
                };

                educationService.AddEducation(edu);
            }

            using (ApplicationDbContext context = new ApplicationDbContext(Options))
            {
                EducationService educationService = new EducationService(context);
                educationService.DeleteEducation(1);
            }

            using (ApplicationDbContext context = new ApplicationDbContext(Options))
            {
                EducationService educationService = new EducationService(context);
                UserService userService = new UserService(context);

                List<User> users = userService.GetBatchUsers();
                List<Education> userEdcuation = educationService.GetEducationForUser(users[0].Id);

                Assert.IsTrue(userEdcuation.Count == 0);
            }
        }

    }
}

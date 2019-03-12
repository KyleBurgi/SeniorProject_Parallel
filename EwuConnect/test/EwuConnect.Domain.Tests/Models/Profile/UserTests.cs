using System;
using System.Collections.Generic;
using EwuConnect.Domain.Models.Profile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EwuConnect.Domain.Tests.Models.Profile
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void UserTests_1_Pass()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void User_CreateUser_Pass()
        {
            User user = new User { FirstName = "Kyle", LastName = "Burgi" };
            Assert.AreEqual("Kyle", user.FirstName);
            Assert.AreEqual("Burgi", user.LastName);
        }

        [TestMethod]
        public void AddUser()
        {
            User u = new User 
            { 
               FirstName = "Kyle", 
               LastName = "Burgi",
               Email = "FakeEmail@FakeService.Com",
               PhoneNumber = "(123)456-7890",
               State = "WA",
               City = "Spokane"
            };

            List<User> users = new List<User>();
            users.Add(u);

            Assert.AreEqual("Kyle", users[0].FirstName);
            Assert.AreEqual("Burgi", users[0].LastName);
        }
    }
}

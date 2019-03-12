using System;
using EwuConnect.Domain.Models;
using EwuConnect.Domain.Models.Profile;
using EwuConnect.Domain.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EwuConnect.Domain.Tests.Services.Profile
{
    [TestClass]
    public class UserServiceTests
    {
        private SqliteConnection SqliteConnection { get; set; }
        private DbContextOptions<ApplicationDbContext> Options { get; set; }

        [TestInitialize]
        public void OpenConnect()
        {
            SqliteConnection = new SqliteConnection("DataSource=:memory:");
            SqliteConnection.Open();

            Options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(SqliteConnection)
                .Options;
                
            using(var context = new ApplicationDbContext(Options))
            {
                context.Database.EnsureCreated();
            }
        }

        [TestCleanup]
        public void CloseConnection()
        {
            SqliteConnection.Close();
        }

        [TestMethod]
        public void AddUser_Pass()
        {
            using (var context = new ApplicationDbContext(Options))
            {
                UserService service = new UserService(context);

                User u = new User
                {
                    FirstName = "Kyle",
                    LastName = "Burgi",
                    Email = "FakeEmail@FakeService.Com",
                    PhoneNumber = "(123) 456-7890",
                    State = "WA",
                    City = "Spokane"
                };

                service.AddUser(u);

                User fetchedUser = service.FetchUser(1);
                Assert.AreEqual("Kyle", fetchedUser.FirstName);
            }
        }
    }
}

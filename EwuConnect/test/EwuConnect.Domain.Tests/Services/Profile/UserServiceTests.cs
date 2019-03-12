using System;
using System.Data;
using EwuConnect.Domain.Models;
using EwuConnect.Domain.Models.Profile;
using EwuConnect.Domain.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EwuConnect.Domain.Tests.Services.Profile
{
    [TestClass]
    public class UserServiceTests
    {
        ILoggerFactory GetLoggerFactory() {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
            {
                builder.AddConsole()
                    .AddFilter(DbLoggerCategory.Database.Command.Name,
                                LogLevel.Information);
            });

            return serviceCollection.BuildServiceProvider()
                .GetService<ILoggerFactory>();
        }
        private SqliteConnection SqliteConnection { get; set; }
        private DbContextOptions<ApplicationDbContext> Options { get; set; }

        [TestInitialize]
        public void OpenConnect()
        {
            SqliteConnection = new SqliteConnection("DataSource=:memory:");
            SqliteConnection.Open();

            Options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(SqliteConnection)
                .UseLoggerFactory(GetLoggerFactory())
                .EnableSensitiveDataLogging()
                .Options;

            using (var context = new ApplicationDbContext(Options))
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
        public void AddUser_RequiredInfo_Pass()
        {
            User fetchedUser2 = null;
            using (var context = new ApplicationDbContext(Options))
            {
                UserService service = new UserService(context);

                User u = new Mentee
                {
                    FirstName = "Kyle",
                    LastName = "Burgi",
                    Email = "FakeEmail@FakeService.com",
                    PhoneNumber = "(123) 456-7890",
                    State = "WA",
                    City = "Spokane"
                };

                User u2 = new Mentee
                {
                    FirstName = "Kyle2",
                    LastName = "Burgi2",
                    Email = "FakeEmail@FakeService.com2",
                    PhoneNumber = "(123) 456-78902",
                    State = "WA2",
                    City = "Spokane2"
                };

                service.AddUser(u);
                service.AddUser(u2);

                User fetchedUser = service.GetUser(1);
                Assert.AreEqual("Kyle", fetchedUser.FirstName);
                Assert.AreEqual("Burgi", fetchedUser.LastName);
                Assert.AreEqual("FakeEmail@FakeService.com", fetchedUser.Email);
                Assert.AreEqual("WA", fetchedUser.State);

                fetchedUser2 = service.GetUser(2);

            }
            Assert.AreEqual("Kyle2", fetchedUser2.FirstName);
            Assert.AreEqual("Burgi2", fetchedUser2.LastName);
            Assert.AreEqual("FakeEmail@FakeService.com2", fetchedUser2.Email);
            Assert.AreEqual("WA2", fetchedUser2.State);
        }

        [TestMethod]
        public void UpdateUser_RequiredInfo_Pass()
        {
            User fetchedUser = null;
            User fetchedUser2 = null;
            User secondFetch = null;

            using (var context = new ApplicationDbContext(Options))
            {
                UserService service = new UserService(context);

                User u = new Mentee
                {
                    FirstName = "Kyle",
                    LastName = "Burgi",
                    Email = "FakeEmail@FakeService.com",
                    PhoneNumber = "(123) 456-7890",
                    State = "WA",
                    City = "Spokane"
                };

                User u2 = new Mentee
                {
                    FirstName = "Kyle2",
                    LastName = "Burgi2",
                    Email = "FakeEmail@FakeService.com2",
                    PhoneNumber = "(123) 456-78902",
                    State = "WA2",
                    City = "Spokane2"
                };

                service.AddUser(u);
                service.AddUser(u2);

                fetchedUser = service.GetUser(1);
                fetchedUser2 = service.GetUser(2);

            }

            fetchedUser.FirstName = "Jess";
            fetchedUser.LastName = "Jahn";
            fetchedUser.Email = "AnotherFakeEmail@FS.com";
            fetchedUser.PhoneNumber = "(098) 765-4321";

            using (var context = new ApplicationDbContext(Options))
            {
                UserService service = new UserService(context);

                service.UpdateUser(fetchedUser);


                secondFetch = service.GetUser(1);
                Assert.AreEqual("Jess", fetchedUser.FirstName);
                Assert.AreEqual("Jahn", fetchedUser.LastName);
                Assert.AreEqual("AnotherFakeEmail@FS.com", fetchedUser.Email);
                Assert.AreEqual("(098) 765-4321", fetchedUser.PhoneNumber);
                Assert.AreEqual("WA", fetchedUser.State);
            }
        }
        
    }
}

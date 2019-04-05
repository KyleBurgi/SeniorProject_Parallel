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

    public class UserService : IUserService
    {

        private ApplicationDbContext DbContext { get; }

        public UserService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));


        }

        public void AddUser(User user)
        {
            DbContext.Users.Add(user);
            DbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            DbContext.Users.Update(user);
            DbContext.SaveChanges();
        }

        public User GetUser(int id) 
        {
            return DbContext.Users
                .SingleOrDefault(u => u.Id == id);
        }

        public List<User> GetBatchUsers()
        {
            return DbContext.Users.ToList();
        }

        public bool DeleteUser(int id)
        {
            User foundUser = DbContext.Users.Find(id);

            if(foundUser != null)
            {
                DbContext.Users.Remove(foundUser);
                DbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}


using System;
using EwuConnect.Domain.Models;
using EwuConnect.Domain.Models.Profile;

namespace EwuConnect.Domain.Services
{
    public class UserService
    {
        //TODO
        //* Should be made Async
        //* Add HTML Tags for Get/set/etc.
        //* CRUD
            //Create
            //Read
            //Update
            //Delete
        //* 
        private ApplicationDbContext DbContext { get; }

        public UserService(ApplicationDbContext context)
        {
            DbContext = context;
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

        public void RemoveUser(User user)
        {
            DbContext.Users.Remove(user);
            DbContext.SaveChanges();
        }

        public User GetUser(int id) 
        {
            return DbContext.Users.Find(id);
        }
        

    }
}


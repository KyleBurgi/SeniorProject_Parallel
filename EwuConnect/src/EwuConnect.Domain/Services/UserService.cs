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

    public class UserService : IUserService
    {

        private ApplicationDbContext DbContext { get; }

        public UserService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<User> AddUser(User user)
        {
            DbContext.Users.Add(user);
            await DbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            DbContext.Users.Update(user);
            await DbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUser(int id) 
        {
            return await DbContext.Users.FindAsync(id);
        }

        public async Task<List<User>> FetchAllUsers()
        {
            return await DbContext.Users.ToListAsync();
        }

        public async Task<bool> DeleteUser(int id)
        {
            User foundUser = DbContext.Users.Find(id);

            if(foundUser != null)
            {
                DbContext.Users.Remove(foundUser);
                await DbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}


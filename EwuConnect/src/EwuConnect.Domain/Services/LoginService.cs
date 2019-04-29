using EwuConnect.Domain.Models;
using EwuConnect.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwuConnect.Domain.Services
{
    public class LoginService : ILoginService
    {
        private ApplicationDbContext DbContext { get; }

        public LoginService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<Login> AddLogin(Login userLogin)
        {
            DbContext.Logins.Add(userLogin);
            await DbContext.SaveChangesAsync();
            return userLogin;
        }
        public async Task<int> CheckLogin(string email)
        {
            Login foundLogin = await DbContext.Logins.FindAsync(email);
            if (foundLogin == null)
            {
                return -1;
            }
            else
            {
                return foundLogin.Id;
            }
        }

        public async Task<bool> DeleteLogin(int loginId)
        {
            Login foundLogin = await DbContext.Logins.FindAsync(loginId);

            if (foundLogin != null)
            {
                DbContext.Logins.Remove(foundLogin);
                await DbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Login> UpdateLogin(Login userLogin)
        {
            DbContext.Logins.Update(userLogin);
            await DbContext.SaveChangesAsync();
            return userLogin;
        }
    }
}


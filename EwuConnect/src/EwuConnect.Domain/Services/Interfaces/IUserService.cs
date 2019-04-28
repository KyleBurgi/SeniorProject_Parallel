using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EwuConnect.Domain.Models.Profile;

namespace EwuConnect.Domain.Services.Interfaces
{
    public interface IUserService
    {
        /*CRUD*/

        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> GetUser(int userId);
        Task<bool> DeleteUser(int userId);
        Task<List<User>> FetchAllUsers();
    }
}

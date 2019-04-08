using System;
using System.Collections.Generic;
using EwuConnect.Domain.Models.Profile;

namespace EwuConnect.Domain.Services.Interfaces
{
    public interface IUserService
    {
/*CRUD*/
        User AddUser(User user);
        void UpdateUser(User user);
        User GetUser(int userId);
        bool DeleteUser(int userId);
        List<User> FetchAllUsers();
    }
}

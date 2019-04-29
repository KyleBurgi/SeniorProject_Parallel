using EwuConnect.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwuConnect.Domain.Services.Interfaces
{
    public interface ILoginService
    {
        Task<Login> AddLogin(Login userLogin);
        Task<int> CheckLogin(string email);
        Task<Login> UpdateLogin(Login userLogin);
        Task<bool> DeleteLogin(int loginId);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwuConnect.Domain.Services.Interfaces
{
    public interface IMessageService
    {
        Task<string> AddMessage(String content);
    }
}

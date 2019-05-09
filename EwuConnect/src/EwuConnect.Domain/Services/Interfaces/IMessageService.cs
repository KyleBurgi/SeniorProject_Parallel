using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EwuConnect.Domain.Models.Chat;

namespace EwuConnect.Domain.Services.Interfaces
{
    public interface IMessageService
    {
        Task<Message> AddMessage(Message message);
        Task<Message> GetMessage(int id); 
    }
}

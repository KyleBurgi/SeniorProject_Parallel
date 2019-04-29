using EwuConnect.Domain.Models.Chat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwuConnect.Domain.Services.Interfaces
{
    public interface IConversationService
    {
        Task<Conversation> GetConversation(int id);
    }
}

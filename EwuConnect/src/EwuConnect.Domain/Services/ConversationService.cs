using EwuConnect.Domain.Models.Chat;
using EwuConnect.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwuConnect.Domain.Services
{
    public class ConversationService : IConversationService
    {
        public Task<Conversation> GetConversation(int id)
        {
            throw new NotImplementedException();
        }
    }
}

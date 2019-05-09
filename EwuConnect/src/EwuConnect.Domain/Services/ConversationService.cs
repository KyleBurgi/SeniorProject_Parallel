using EwuConnect.Domain.Models;
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
        private ApplicationDbContext DbContext { get; }

        public ConversationService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<Conversation> AddConversation(Conversation conversation)
        {
            DbContext.Conversations.Add(conversation);
            await DbContext.SaveChangesAsync();
            return conversation;
        }

        public async Task<Conversation> GetConversation(int id)
        {
            return await DbContext.Conversations.FindAsync(id);
        }
    }
}

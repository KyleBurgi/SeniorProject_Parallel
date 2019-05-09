using EwuConnect.Domain.Models;
using EwuConnect.Domain.Models.Chat;
using EwuConnect.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EwuConnect.Domain.Services
{
    public class MessageService : IMessageService
    {
        private ApplicationDbContext DbContext { get; }

        public MessageService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<Message> AddMessage(Message message)
        {
            DbContext.Messages.Add(message);
            await DbContext.SaveChangesAsync();
            return message;
        }

        public async Task<Message> GetMessage(int id)
        {
            return await DbContext.Messages.FindAsync(id);
        }
    }
}

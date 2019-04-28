using EwuConnect.Domain.Models;
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
        public Task<string> AddMessage(string content)
        {
            throw new NotImplementedException();
        }
    }
}

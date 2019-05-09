using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EwuConnect.Domain.Models.Chat;
using EwuConnect.Domain.Models.Profile;

namespace EwuConnect.Api.ViewModels
{
    public class MessageInputViewModel
    {

        public int ConversationId { get; set; }
        public Conversation Conversation { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public string MessageContent { get; set; }
    }
}

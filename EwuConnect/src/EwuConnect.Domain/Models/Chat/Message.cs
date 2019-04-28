using System;
using System.Collections.Generic;
using System.Text;

namespace EwuConnect.Domain.Models.Chat
{
    public class Message
    {
        public int Id { get; set; }
        public int ConversationId { get; set; }
        public Conversation Conversation { get; set; }
        public string MessageContent { get; set; }
    }
}

using EwuConnect.Domain.Models.Profile;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwuConnect.Domain.Models.Chat
{
    public class Conversation
    {
        public int Id { get; set; }
        public int MentorId { get; set; }
        public User Mentor { get; set; }
        public int MenteeId { get; set; }
        public User Mentee { get; set; }
        public ICollection<Message> ConversationMessages { get; set; }


    }
}

using EwuConnect.Domain.Models.Chat;
using EwuConnect.Domain.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EwuConnect.Api.ViewModels
{
    public class ConversationInputViewModel
    {
        public int MentorId { get; set; }
        public User Mentor { get; set; }
        public int MenteeId { get; set; }
        public User Mentee { get; set; }
        public ICollection<Message> ConversationMessages { get; set; }
    }
}

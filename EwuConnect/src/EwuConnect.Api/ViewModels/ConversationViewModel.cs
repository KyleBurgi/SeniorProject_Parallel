using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EwuConnect.Api.ViewModels
{
    public class ConversationViewModel
    {
        public UserViewModel Mentor { get; set; }
        public UserViewModel Mentee { get; set; }
        public ICollection<MessageViewModel> ConversationMessages { get; set; }
    }
}

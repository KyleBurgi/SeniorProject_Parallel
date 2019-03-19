using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EwuConnect.Domain.Models.Profile
{
    public class Message
    {
        public int Id { get; set; }
        [ForeignKey("SenderId")]
        public int SenderId { get; set; }
        public User Sender { get; set; }
        [ForeignKey("RecipientId")]
        public int RecipientId { get; set; }
        public User Recipient { get; set; }
        public string ChatMessage { get; set; }
    }
}

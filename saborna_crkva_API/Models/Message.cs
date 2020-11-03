using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Models
{
    public class Message
    {
        public int Id { get; set; }
        public Conversation Conversation { get; set; }
        public int ConversationId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Dtos
{
    public class MessageToSend
    {
        public int senderId { get; set; }
        public int receiverId { get; set; }
        public string text { get; set; }
        public int conversationId { get; set; }
    }
}

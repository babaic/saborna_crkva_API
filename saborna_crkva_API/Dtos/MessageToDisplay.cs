using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Dtos
{
    public class MessageToDisplay
    {
        public int MessageId { get; set; }
        public int ConversationId { get; set; }
        public int UserOneId { get; set; }
        public int UserTwoId { get; set; }
        public int SenderId { get; set; }
        public DateTime DateTime { get; set; }
        public string UserOneName { get; set; }
        public string UserTwoName { get; set; }
    }
}

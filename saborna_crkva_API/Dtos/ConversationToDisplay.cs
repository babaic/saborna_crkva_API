using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Dtos
{
    public class ConversationToDisplay
    {
        public int Id { get; set; }
        public int UserOneId { get; set; }
        public int UserTwoId { get; set; }
        public int NumberOfMessages { get; set; }
        public bool UserOneRead { get; set; }
        public bool UserTwoRead { get; set; }
        public LastMsgInfo LastMsgInfo { get; set; }

    }
    public class LastMsgInfo
    {
        public string LastMsg { get; set; }
        public string Sender { get; set; }
        public int SenderId { get; set; }
    }
}

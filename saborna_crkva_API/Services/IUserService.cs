using saborna_crkva_API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Services
{
    public interface IUserService
    {
        List<UsertoDisplay> getAllUsers(string role = null);
        List<ConversationToDisplay> getConversations(int userId);
        List<MessageToDisplay> getMessages(int conversationId);
        Task sendMessage(int senderId, int receiverId, string text, int conversationId = 0);
    }
}

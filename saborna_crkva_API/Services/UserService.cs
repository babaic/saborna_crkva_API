using Microsoft.EntityFrameworkCore;
using saborna_crkva_API.Dtos;
using saborna_crkva_API.EF;
using saborna_crkva_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Services
{
    public class UserService : IUserService
    {
        private readonly MyContext _context;

        public UserService(MyContext context)
        {
            _context = context;
        }

        public List<UsertoDisplay> getAllUsers(string role = null)
        {
            var query = _context.Users.Select(x => new UsertoDisplay
            {
                Id = x.Id,
                Ime = x.Ime,
                Prezime = x.Prezime,
                Username = x.UserName,
                Email = x.Email,
                Adresa = x.Adresa,
                Role = x.UserRoles.Where(c => c.UserId == x.Id).Select(c => c.Role.Name).FirstOrDefault()
            }).AsQueryable();

            if (role != null)
            {
                query = query.Where(x => x.Role == role);
            }

            var result = query.ToList();

            return result;
        }

        public List<ConversationToDisplay> getConversations(int userId)
        {
            var conversations = _context.Conversation.Where(x => x.UserOneId == userId || x.UserTwoId == userId).Select(c => new ConversationToDisplay
            {
                Id = c.Id,
                UserOneId = c.UserOneId,
                UserTwoId = c.UserTwoId,
                NumberOfMessages = _context.Message.Where(x => x.ConversationId == c.Id).Count(),
                UserOneRead = c.UserOneRead,
                UserTwoRead = c.UserTwoRead,
                LastMsgInfo = _context.Message.Where(x => x.ConversationId == c.Id).OrderByDescending(x => x.Id).Select(x=> new LastMsgInfo
                {
                    LastMsg = x.Text,
                    Sender = x.User.Ime + " "+ x.User.Prezime,
                    SenderId = x.UserId
                }).FirstOrDefault()
            }).ToList();

            return conversations;
        }

        public List<MessageToDisplay> getMessages(int conversationId)
        {
            var messages = _context.Message.Include(x => x.Conversation).Where(x => x.ConversationId == conversationId).Select(c => new MessageToDisplay
            {
                ConversationId = c.ConversationId,
                DateTime = c.DateTime,
                MessageId = c.Id,
                SenderId = c.UserId,
                UserOneId = c.Conversation.UserOneId,
                UserTwoId = c.Conversation.UserTwoId,
                UserOneName = c.Conversation.UserOne.Ime + " " + c.Conversation.UserOne.Prezime,
                UserTwoName = c.Conversation.UserTwo.Ime + " " + c.Conversation.UserTwo.Prezime,
            }).ToList();


            return messages;
        }

        public async Task sendMessage(int senderId, int receiverId, string text, int conversationId = 0)
        {
            int convId = conversationId;

            if (conversationId == 0)
            {
                var conversation = new Conversation
                {
                    UserOneId = senderId,
                    UserTwoId = receiverId,
                };
                await _context.AddAsync(conversation);
                await _context.SaveChangesAsync();
                convId = conversation.Id;
            }

            var msg = new Message
            {
                ConversationId = convId,
                DateTime = DateTime.Now,
                UserId = senderId,
                Text = text
            };
            await _context.AddAsync(msg);

            var conversationUpdate = await _context.Conversation.FirstOrDefaultAsync(x => x.Id == convId);
            conversationUpdate.UserTwoRead = msg.UserId == conversationUpdate.UserTwoId ? true : false;
            conversationUpdate.UserOneRead = msg.UserId == conversationUpdate.UserOneId ? true : false;
            await _context.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using saborna_crkva_API.Dtos;
using saborna_crkva_API.Services;

namespace saborna_crkva_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet("getallusers")]
        public ActionResult<List<UsertoDisplay>> getAllUsers([FromQuery] string role)
        {
            var result = _userService.getAllUsers(role);
            if(result == null)
            {
                return BadRequest("Users not found");
            }
            return result;
        }

        [AllowAnonymous]
        [HttpGet("getconversations")]
        public ActionResult<List<ConversationToDisplay>> getConversations([FromQuery] int userid)
        {
            var result = _userService.getConversations(userid);
            if (result == null)
            {
                return BadRequest("No conversations found");
            }
            return result;
        }

        [AllowAnonymous]
        [HttpGet("getmessages")]
        public ActionResult<List<MessageToDisplay>> getMessages([FromQuery] int conversationid)
        {
            var result = _userService.getMessages(conversationid);
            if (result == null)
            {
                return BadRequest("No messages found");
            }
            return result;
        }

        [AllowAnonymous]
        [HttpPost("sendmessage")]
        public async Task<ActionResult> sendMessageAsync(MessageToSend msgToSend)
        {
            await _userService.sendMessage(msgToSend.senderId, msgToSend.receiverId, msgToSend.text, msgToSend.conversationId);

            return Ok();
        }

    }
}
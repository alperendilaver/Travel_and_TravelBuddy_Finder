using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.MessageCommands;
using Application.Features.Queries.MessageQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{senderUserId}/{receiverUserId}")]
        public async Task<IActionResult> GetMessages(string senderUserId, string receiverUserId)
        {
            var messages = await _mediator.Send(new GetMessagesQuery(senderUserId, receiverUserId));
            return Ok(messages);
        }
        [HttpGet("unread/{userId}")]
        public async Task<IActionResult> GetUnread(string userId)
        {
            var count = await _mediator.Send(new GetUnreadMessagesCountQuery(userId));
            return Ok(count);
        }
        [HttpGet("conversations/{userId}")]
        public async Task<IActionResult> GetConversations(string userId)
        {
            var conversations = await _mediator.Send(new GetConversationQuery(userId));
            return Ok(conversations);
        }
        [HttpDelete("deleteconversation/{firstUserId}/{secondUserId}")]
        public async Task<IActionResult> DeleteConversation(string firstUserId, string secondUserId)
        {
            var res = await _mediator.Send(new DeleteConversationCommand(firstUserId, secondUserId));
            return Ok(res);
        }

        [HttpDelete("deletemessages")]
        public async Task<IActionResult> DeleteMessages(DeleteMessagesCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.NotificationCommands;
using Application.Features.Queries.NotificationQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotifiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotifiesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserNotifies(string userId)
        {
            var entities = await _mediator.Send(new GetNotificationByUserIdQuery(userId));
            return Ok(entities);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotify(MatchNotificationCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("MarkAsRead/{notifyId}")]
        public async Task<IActionResult> MarkAsReadNotify(int notifyId)
        {
            var response = await _mediator.Send(new NotifyMarkAsReadQuery(notifyId));
            return Ok(response);
        }
        [HttpDelete("RemoveNotify/{notifyId}")]
        public async Task<IActionResult> RemoveNotify(int notifyId)
        {
            var response = await _mediator.Send(new RemoveNotificationCommand(notifyId));
            return Ok(response);
        }
    }

}
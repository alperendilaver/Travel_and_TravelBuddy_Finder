using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.SuggestedUserCommands;
using Application.Features.Handlers.SuggestedUserHandlers;
using Application.Features.Queries.SuggestedUserQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuggestedUsersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public SuggestedUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetSuggestedUsers(string userId)
        {
            var entities = await _mediator.Send(new GetSuggestedUsersQuery(userId));
            return Ok(entities);
        }
        [HttpDelete("{SuggestId}")]
        public async Task<IActionResult> RemoveSuggest(int SuggestId)
        {
            var response = await _mediator.Send(new RemoveSuggestedUserCommand(SuggestId));
            return Ok(response);
        }
    }
}
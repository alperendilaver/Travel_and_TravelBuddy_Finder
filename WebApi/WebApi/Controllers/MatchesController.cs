using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.MatchCommands;
using Application.Features.Queries.MatchQueries;
using Application.Features.Queries.CountryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MatchesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("LikeUser")]
        public async Task<IActionResult> LikeUser(LikeUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> MatchList()
        {
            var values = await _mediator.Send(new GetMatchesByUserQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatch(int id)
        {
            var value = await _mediator.Send(new GetMatchQuery(id));
            return Ok(value);
        }
        [HttpGet("matches/{userId}")]
        public async Task<IActionResult> GetMatches(string userId)
        {
            var users = await _mediator.Send(new GetMatchesForUserQuery(userId));
            return Ok(users);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMatch(CreateMatchCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMatch(UpdateMatchCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("deleteMatch")]
        public async Task<IActionResult> DeleteMatch(DeleteMatchCommand matchCommand)
        {
            var result = await _mediator.Send(matchCommand);
            return Ok(result);
        }
        [HttpGet("getlikes/{userId}")]
        public async Task<IActionResult> GetLikes(string userId)
        {
            var users = await _mediator.Send(new GetLikesForUserQuery(userId));
            return Ok(users);
        }
    }
}
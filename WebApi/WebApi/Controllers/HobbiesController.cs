using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.HobbyCommands;
using Application.Features.Queries.HobbyQueries;
using Application.Features.Queries.CountryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HobbiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HobbiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> HobbyList()
        {
            var values = await _mediator.Send(new GetAllHobbiesQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHobby(int id)
        {
            var value = await _mediator.Send(new GetHobbyQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateHobby(CreateHobbyCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateHobby(UpdateHobbyCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHobby(int id)
        {
            var result = await _mediator.Send(new DeleteHobbyCommand(id));
            return Ok(result);
        }
    }
}
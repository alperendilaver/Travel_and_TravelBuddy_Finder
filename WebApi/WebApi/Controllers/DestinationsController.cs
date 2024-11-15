using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.TravelDestinationCommands;
using Application.Features.Queries.TravelDestinationQueries;
using Application.Features.Queries.CountryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DestinationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TravelDestinationList()
        {
            var values = await _mediator.Send(new GetTravelDestinationsByCityQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTravelDestination(int id)
        {
            var value = await _mediator.Send(new GetTravelDestinationQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTravelDestination(CreateTravelDestinationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTravelDestination(UpdateTravelDestinationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelDestination(int id)
        {
            var result = await _mediator.Send(new DeleteTravelDestinationCommand(id));
            return Ok(result);
        }
    }
}
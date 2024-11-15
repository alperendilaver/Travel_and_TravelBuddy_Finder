using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.TravelRouteCommands;
using Application.Features.Queries.TravelRouteQueries;
using Application.Features.Queries.CountryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoutesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TravelRoutesList()
        {
            var values = await _mediator.Send(new GetTravelRoutesBySuggestionQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTravelRoutes(int id)
        {
            var value = await _mediator.Send(new GetTravelRouteQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTravelRoutes(CreateTravelRouteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTravelRoutes(UpdateTravelRouteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelRoutes(int id)
        {
            var result = await _mediator.Send(new DeleteTravelRouteCommand(id));
            return Ok(result);
        }
    }
}
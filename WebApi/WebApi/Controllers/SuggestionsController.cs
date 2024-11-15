using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.TravelSuggastionCommands;
using Application.Features.Queries.TravelSuggastionQueries;
using Application.Features.Queries.CountryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuggestionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SuggestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TravelSuggestionList()
        {
            var values = await _mediator.Send(new GetUserTravelSuggestionsQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTravelSuggestion(int id)
        {
            var value = await _mediator.Send(new GetTravelSuggestionQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTravelSuggestion(CreateTravelSuggestionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTravelSuggestion(UpdateTravelSuggestionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelSuggestion(int id)
        {
            var result = await _mediator.Send(new DeleteTravelSuggestionCommand(id));
            return Ok(result);
        }
    }
}
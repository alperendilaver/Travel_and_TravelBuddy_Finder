using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.CountryCommands;
using Application.Features.Queries.CountryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CountryList()
        {
            var values = await _mediator.Send(new GetAllCountriesQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            var value = await _mediator.Send(new GetCountryQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCountry(CreateCountryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCountry(UpdateCountryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var result = await _mediator.Send(new DeleteCountryCommand(id));
            return Ok(result);
        }
    }
}
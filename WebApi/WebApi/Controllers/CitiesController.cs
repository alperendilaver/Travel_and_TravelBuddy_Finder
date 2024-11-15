using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.CityCommands;
using Application.Features.Queries.CityQueries;
using Application.Features.Queries.CountryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CityList()
        {
            var values = await _mediator.Send(new GetCitiesByCountryQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id)
        {
            var value = await _mediator.Send(new GetCityQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCity(CreateCityCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCity(UpdateCityCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var result = await _mediator.Send(new DeleteCityCommand(id));
            return Ok(result);
        }
    }
}
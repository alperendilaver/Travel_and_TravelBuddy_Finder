using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.HotelCommands;
using Application.Features.Queries.HotelQueries;
using Application.Features.Queries.CountryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HotelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> HotelList()
        {
            var values = await _mediator.Send(new GetHotelsByCityQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotel(int id)
        {
            var value = await _mediator.Send(new GetHotelQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateHotel(CreateHotelCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateHotel(UpdateHotelCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var result = await _mediator.Send(new DeleteHotelCommand(id));
            return Ok(result);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.FoodCommands;
using Application.Features.Queries.FoodQueries;
using Application.Features.Queries.CountryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FoodsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FoodList()
        {
            var values = await _mediator.Send(new GetAllFoodsQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFood(int id)
        {
            var value = await _mediator.Send(new GetFoodQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFood(CreateFoodCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFood(UpdateFoodCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            var result = await _mediator.Send(new DeleteFoodCommand(id));
            return Ok(result);
        }
    }
}
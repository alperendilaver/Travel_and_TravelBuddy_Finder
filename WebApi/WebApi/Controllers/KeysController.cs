using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.KeyCommands;
using Application.Features.Queries.KeyQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeysController : ControllerBase
    {
        private readonly IMediator _mediator;

    public KeysController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetPublicKey(string userId)
    {
        var query = new GetUserPublicKeyQuery(userId);
        var publicKey = await _mediator.Send(query);

        if (publicKey == null)
            return NotFound();

        return Ok(new { publicKey });
    }
    [HttpGet("getEncryptedPrivateKey/{userId}")]
    public async Task<IActionResult> GetEncryptedPrivateKey(string userId){
        var key = await _mediator.Send(new GetUserPrivateKeyQuery(userId));
        return Ok(key);
    }

    [HttpPost]
    public async Task<IActionResult> SaveKeys([FromBody] SaveKeysCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    }
}
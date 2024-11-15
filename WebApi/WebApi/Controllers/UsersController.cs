using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.UserCommands;
using Application.Features.Handlers.UserHandlers;
using Application.Features.Queries.UserQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CheckAuthHandler _chechkAuthHandler;
        private readonly LogoutUserHandler _logoutUserHandler;

        public UsersController(IMediator mediator, CheckAuthHandler chechkAuthHandler, LogoutUserHandler logoutUserHandler)
        {
            _mediator = mediator;
            _chechkAuthHandler = chechkAuthHandler;
            _logoutUserHandler = logoutUserHandler;
        }

        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            var values = await _mediator.Send(new GetAllUsersQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var value = await _mediator.Send(new GetUserQuery(id));
            return Ok(value);
        }
        [HttpGet("checkauth")]
        public async Task<IActionResult> CheckAuth()
        {
            var result = _chechkAuthHandler.Handle(User);
            if (!string.IsNullOrEmpty(result.Id) && !string.IsNullOrEmpty(result.FullName))
            {
                return Ok(new { isAuthenticated = true, fullName = result.FullName, id = result.Id, role = result.Role });
            }
            return Ok(new { isAuthenticated = false });
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));
            return Ok(result);
        }
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            var resp = _logoutUserHandler.Handle();
            return Ok(resp);
        }
        [HttpGet("getrole/{userId}")]
        public async Task<IActionResult> GetRoleName(string userId)
        {
            var result = await _mediator.Send(new GetRoleNameQuery(userId));
            if (!string.IsNullOrEmpty(result.RoleName))
            {
                return Ok(new { roleName = result.RoleName });
            }
            return Ok(new { roleName = "Unknown" });
        }
        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(ConfirmMailCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("reset-password-request/{email}")]
        public async Task<IActionResult> ResetPasswordRequest(string email)
        {
            var result = await _mediator.Send(new ResetPasswordRequestCommand { Email = email });
            return result.IsSucceded ? Ok("Şifre sıfırlama bağlantısı gönderildi.") : BadRequest("Kullanıcı bulunamadı.");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok("Şifre başarıyla sıfırlandı.") : BadRequest(result.Errors);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.UserCommands
{
    public class ResetPasswordCommand : IRequest<IdentityResult>
    {

        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
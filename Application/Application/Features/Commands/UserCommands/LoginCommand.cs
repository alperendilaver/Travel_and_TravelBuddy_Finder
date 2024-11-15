using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using Application.Features.Results.UserResults;
using MediatR;

namespace Application.Features.Commands.UserCommands
{
    public class LoginCommand : IRequest<LoginResponse>
    {

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
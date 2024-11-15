using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.UserCommands
{
    public class RegisterUserCommand : IRequest<GeneralResponse>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string GovernmentId { get; set; }
        public bool Visa { get; set; }
        public int Budget { get; set; }
        public bool Passport { get; set; }
        public bool Gender { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.UserCommands
{
    public class UpdateUserCommand : IRequest<GeneralResponse>
    {
        public string UserId { get; set; }
        public string GovernmentId { get; set; }
        public bool Visa { get; set; }
        public int Budget { get; set; }
        public bool Passport { get; set; }
        public bool Gender { get; set; }
    }
}
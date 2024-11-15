using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.UserHobbyCommands
{
    public class CreateUserHobbyCommand : IRequest<GeneralResponse>
    {
        public string UserId { get; set; }
        public int HobbyId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.UserHobbyCommands
{
    public class UpdateUserHobbyCommand : IRequest<GeneralResponse>
    {
        public int UserHobbyId { get; set; }
        public int HobbyId { get; set; }
    }
}
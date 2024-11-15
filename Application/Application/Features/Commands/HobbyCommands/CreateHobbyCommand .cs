using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.HobbyCommands
{
    public class CreateHobbyCommand : IRequest<GeneralResponse>
    {
        public string HobbyName { get; set; }
    }
}
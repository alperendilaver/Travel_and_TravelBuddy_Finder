using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.DestinationCommands
{
    public class UpdateDestinationCommand : IRequest<GeneralResponse>
    {
        public int DestinationId { get; set; }
        public string DestinationName { get; set; }

    }
}
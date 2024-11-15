using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.DestinationCommands
{
    public class DeleteDestinationCommand : IRequest<GeneralResponse>
    {
        public int DestinationId { get; set; }

    }
}
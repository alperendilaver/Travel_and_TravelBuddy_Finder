using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.TravelDestinationCommands
{
    public class DeleteTravelDestinationCommand : IRequest<GeneralResponse>
    {
        public DeleteTravelDestinationCommand(int travelDestinationId)
        {
            this.TravelDestinationId = travelDestinationId;

        }
        public int TravelDestinationId { get; set; }
    }
}
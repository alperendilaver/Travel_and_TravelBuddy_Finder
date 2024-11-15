using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.TravelDestinationCommands
{
    public class UpdateTravelDestinationCommand : IRequest<GeneralResponse>
    {
        public int TravelDestinationId { get; set; }
        public int PopularityValue { get; set; }

    }
}
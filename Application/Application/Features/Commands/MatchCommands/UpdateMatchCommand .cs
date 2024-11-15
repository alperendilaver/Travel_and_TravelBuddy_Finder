using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.MatchCommands
{
    public class UpdateMatchCommand : IRequest<GeneralResponse>
    {
        public int MatchId { get; set; }
        public int TravelDestinationId { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.MatchCommands
{
    public class CreateMatchCommand : IRequest<GeneralResponse>
    {
        public string FirstUserId { get; set; }
        public string SecondUserId { get; set; }
        public int TravelDestinationId { get; set; }
    }
}
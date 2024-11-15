using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.TravelSuggastionCommands
{
    public class CreateTravelSuggestionCommand : IRequest<GeneralResponse>
    {
        public string UserId { get; set; }
        public int RouteId { get; set; }
    }
}
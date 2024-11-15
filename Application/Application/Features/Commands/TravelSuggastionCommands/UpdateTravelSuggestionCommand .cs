using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.TravelSuggastionCommands
{
    public class UpdateTravelSuggestionCommand : IRequest<GeneralResponse>
    {
        public int SuggestionId { get; set; }
        public int RouteId { get; set; }
    }
}
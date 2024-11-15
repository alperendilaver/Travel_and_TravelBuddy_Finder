using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.TravelRouteCommands
{
    public class CreateTravelRouteCommand : IRequest<GeneralResponse>
    {
        public int SuggestionId { get; set; }
        public List<int> DestinationIds { get; set; }
        public List<int> HotelIds { get; set; }
        public List<int> FoodIds { get; set; }
    }
}
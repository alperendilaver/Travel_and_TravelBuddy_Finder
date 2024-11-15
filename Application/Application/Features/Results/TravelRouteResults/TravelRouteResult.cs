using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Results.TravelRouteResults
{
    public class TravelRouteResult
    {
        public int RouteId { get; set; }
        public int SuggestionId { get; set; }
        public List<int> DestinationIds { get; set; }
        public List<int> HotelIds { get; set; }
        public List<int> FoodIds { get; set; }
    }
}
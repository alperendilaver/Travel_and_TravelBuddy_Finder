using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Results.TravelSuggastionResults
{
    public class TravelSuggestionResult
    {
        public int SuggestionId { get; set; }
        public string UserId { get; set; }
        public int RouteId { get; set; }
    }
}
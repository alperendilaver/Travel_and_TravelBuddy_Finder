using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.TravelSuggastionResults;
using MediatR;

namespace Application.Features.Queries.TravelSuggastionQueries
{
    public class GetUserTravelSuggestionsQuery : IRequest<List<TravelSuggestionResult>>
    {
        public string UserId { get; set; }
    }
}
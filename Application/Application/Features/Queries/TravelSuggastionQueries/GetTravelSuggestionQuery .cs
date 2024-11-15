using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.TravelSuggastionResults;
using MediatR;

namespace Application.Features.Queries.TravelSuggastionQueries
{
    public class GetTravelSuggestionQuery : IRequest<TravelSuggestionResult>
    {
        public GetTravelSuggestionQuery(int suggestionId)
        {
            this.SuggestionId = suggestionId;

        }
        public int SuggestionId { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.TravelSuggastionQueries;
using Application.Features.Results.TravelSuggastionResults;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.TravelSuggestionHandlers
{
    public class GetTravelSuggestionsHandler : IRequestHandler<GetUserTravelSuggestionsQuery, List<TravelSuggestionResult>>
    {
        private readonly IRepository<TravelSuggestion> _repository;

        public GetTravelSuggestionsHandler(IRepository<TravelSuggestion> repository)
        {
            _repository = repository;
        }
        public async Task<List<TravelSuggestionResult>> Handle(GetUserTravelSuggestionsQuery request, CancellationToken cancellationToken)
        {
            var TravelSuggestions = await _repository.GetAllAsync();
            return TravelSuggestions
                .Select(c => new TravelSuggestionResult
                {
                    SuggestionId = c.SuggestionId,
                    RouteId = c.RouteId,
                    UserId = c.UserId,
                })
                .ToList();
        }
    }
}
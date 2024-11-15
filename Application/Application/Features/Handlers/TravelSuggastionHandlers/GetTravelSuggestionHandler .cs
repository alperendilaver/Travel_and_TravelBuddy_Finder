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
    public class GetTravelSuggestionHandler : IRequestHandler<GetTravelSuggestionQuery, TravelSuggestionResult>
    {
        private readonly IRepository<TravelSuggestion> _repository;

        public GetTravelSuggestionHandler(IRepository<TravelSuggestion> repository)
        {
            _repository = repository;
        }

        public async Task<TravelSuggestionResult> Handle(GetTravelSuggestionQuery request, CancellationToken cancellationToken)
        {
            var TravelSuggestion = await _repository.GetByIdAsync(request.SuggestionId);

            return new TravelSuggestionResult
            {
                SuggestionId = TravelSuggestion.SuggestionId,
                RouteId = TravelSuggestion.RouteId,
                UserId = TravelSuggestion.UserId,
            };

        }
    }
}

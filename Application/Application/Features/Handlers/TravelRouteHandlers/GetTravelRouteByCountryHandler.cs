using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.TravelRouteQueries;
using Application.Features.Queries.TravelSuggastionQueries;
using Application.Features.Results.TravelRouteResults;
using Application.Features.Results.TravelSuggastionResults;
using Application.Interfaces.IGeneralRepository;
using Application.Interfaces.RouteRep;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.TravelRouteHandlers
{
    public class GetTravelRoutesHandler : IRequestHandler<GetTravelRoutesBySuggestionQuery, List<TravelRouteResult>>
    {
        private readonly IRouteRepository _repository;

        public GetTravelRoutesHandler(IRouteRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TravelRouteResult>> Handle(GetTravelRoutesBySuggestionQuery request, CancellationToken cancellationToken)
        {
            var TravelRoutes = await _repository.GetTravelRoutes();
            return TravelRoutes
                .Select(c => new TravelRouteResult
                {
                    SuggestionId = c.SuggestionId,
                    RouteId = c.RouteId,
                    DestinationIds = c.Destinations.Select(x => x.TravelDestinationId).ToList(),
                    FoodIds = c.Foods.Select(f => f.FoodId).ToList(),
                    HotelIds = c.Hotels.Select(h => h.HotelId).ToList()
                })
                .ToList();
        }
    }
}
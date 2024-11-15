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
    public class GetTravelRouteHandler : IRequestHandler<GetTravelRouteQuery, TravelRouteResult>
    {
        private readonly IRouteRepository _repository;

        public GetTravelRouteHandler(IRouteRepository repository)
        {
            _repository = repository;
        }

        public async Task<TravelRouteResult> Handle(GetTravelRouteQuery request, CancellationToken cancellationToken)
        {
            var TravelRoute = await _repository.GetTravelRoute(request.RouteId);

            return new TravelRouteResult
            {
                SuggestionId = TravelRoute.SuggestionId,
                RouteId = TravelRoute.RouteId,
                DestinationIds = TravelRoute.Destinations.Select(x => x.TravelDestinationId).ToList(),
                FoodIds = TravelRoute.Foods.Select(f => f.FoodId).ToList(),
                HotelIds = TravelRoute.Hotels.Select(h => h.HotelId).ToList()
            };

        }
    }
}

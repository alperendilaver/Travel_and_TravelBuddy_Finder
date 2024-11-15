using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.TravelDestinationQueries;
using Application.Features.Queries.TravelSuggastionQueries;
using Application.Features.Results.TravelDestinationResults;
using Application.Features.Results.TravelSuggastionResults;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.TravelDestinationHandlers
{
    public class GetTravelDestinationsHandler : IRequestHandler<GetTravelDestinationsByCityQuery, List<TravelDestinationResult>>
    {
        private readonly IRepository<TravelDestination> _repository;

        public GetTravelDestinationsHandler(IRepository<TravelDestination> repository)
        {
            _repository = repository;
        }
        public async Task<List<TravelDestinationResult>> Handle(GetTravelDestinationsByCityQuery request, CancellationToken cancellationToken)
        {
            var TravelDestinations = await _repository.GetAllAsync();
            return TravelDestinations
                .Select(c => new TravelDestinationResult
                {
                    CityId = c.CityId,
                    CountryId = c.CountryId,
                    PopularityValue = c.PopularityValue,
                    TravelDestinationId = c.TravelDestinationId
                })
                .ToList();
        }
    }
}
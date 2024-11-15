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
    public class GetTravelDestinationHandler : IRequestHandler<GetTravelDestinationQuery, TravelDestinationResult>
    {
        private readonly IRepository<TravelDestination> _repository;

        public GetTravelDestinationHandler(IRepository<TravelDestination> repository)
        {
            _repository = repository;
        }

        public async Task<TravelDestinationResult> Handle(GetTravelDestinationQuery request, CancellationToken cancellationToken)
        {
            var TravelDestination = await _repository.GetByIdAsync(request.TravelDestinationId);

            return new TravelDestinationResult
            {
                CityId = TravelDestination.CityId,
                CountryId = TravelDestination.CountryId,
                PopularityValue = TravelDestination.PopularityValue,
                TravelDestinationId = TravelDestination.TravelDestinationId
            };

        }
    }
}

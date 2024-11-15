using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.CityQueries;
using Application.Features.Results.CityResults;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.CityHandlers
{
    public class GetCityHandler : IRequestHandler<GetCityQuery, CityResult>
    {
        private readonly IRepository<City> _repository;

        public GetCityHandler(IRepository<City> repository)
        {
            _repository = repository;
        }

        public async Task<CityResult> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            var city = await _repository.GetByIdAsync(request.CityId);

            return new CityResult
            {
                CityId = city.CityId,
                CityName = city.CityName,
                CountryId = city.CountryId,
                TravelDestinationIds = city.TravelDestinations?.Select(td => td.TravelDestinationId).ToList() ?? new List<int>()
            };

        }
    }
}

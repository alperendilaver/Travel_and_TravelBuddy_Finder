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
    public class GetCitiesByCountryHandler : IRequestHandler<GetCitiesByCountryQuery, List<CityResult>>
    {
        private readonly IRepository<City> _repository;

        public GetCitiesByCountryHandler(IRepository<City> repository)
        {
            _repository = repository;
        }
        public async Task<List<CityResult>> Handle(GetCitiesByCountryQuery request, CancellationToken cancellationToken)
        {
            var cities = await _repository.GetAllAsync();
            return cities
                .Select(c => new CityResult
                {
                    CityId = c.CityId,
                    CityName = c.CityName,
                    CountryId = c.CountryId,
                    TravelDestinationIds = c.TravelDestinations?.Select(td => td.TravelDestinationId).ToList() ?? new List<int>()
                })
                .ToList();
        }
    }
}
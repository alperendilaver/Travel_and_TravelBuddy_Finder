using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.CityQueries;
using Application.Features.Queries.CountryQueries;
using Application.Features.Results.CountryResults;
using Application.Interfaces.CountryRep;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.CountryHandlers
{
    public class GetCountryByCountryHandler : IRequestHandler<GetAllCountriesQuery, List<CountryResult>>
    {
        private readonly ICountryRepository _repository;

        public GetCountryByCountryHandler(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CountryResult>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await _repository.GetCountriesWithCitiesAsync();
            return countries
                .Select(c => new CountryResult
                {
                    CountryId = c.CountryId,
                    CountryName = c.CountryName,
                    CityName = c.Cities.Select(c => c.CityName).ToList(),
                })
                .ToList();
        }
    }
}
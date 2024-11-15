using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.CountryQueries;
using Application.Features.Results.CountryResults;
using Application.Interfaces.CountryRep;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.CountryHandlers
{
    public class GetCountryHandler : IRequestHandler<GetCountryQuery, CountryResult>
    {
        private readonly ICountryRepository _repository;

        public GetCountryHandler(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CountryResult> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            var country = await _repository.GetCountryWithCitiesAsync(request.CountryId);

            return new CountryResult
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName,
                CityName = country.Cities.Select(x => x.CityName).ToList()
            };

        }
    }
}

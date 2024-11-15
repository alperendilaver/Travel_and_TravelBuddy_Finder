using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.HotelQueries;
using Application.Features.Results.HotelResults;
using Application.Interfaces.HotelRep;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.HotelHandlers
{
    public class GetCitiesByCountryHandler : IRequestHandler<GetHotelsByCityQuery, List<HotelResult>>
    {
        private readonly IHotelRepository _repository;

        public GetCitiesByCountryHandler(IHotelRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<HotelResult>> Handle(GetHotelsByCityQuery request, CancellationToken cancellationToken)
        {
            var cities = await _repository.GetAllHotelsWithCityAsync();
            return cities
                .Select(c => new HotelResult
                {
                    HotelId = c.HotelId,
                    HotelName = c.HotelName,
                    CityId = c.CityId,
                    CityName = c.City.CityName
                })
                .ToList();
        }
    }
}
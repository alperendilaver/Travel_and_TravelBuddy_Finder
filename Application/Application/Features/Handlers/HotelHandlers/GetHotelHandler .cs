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
    public class GetHotelHandler : IRequestHandler<GetHotelQuery, HotelResult>
    {
        private readonly IHotelRepository _repository;

        public GetHotelHandler(IHotelRepository repository)
        {
            _repository = repository;
        }

        public async Task<HotelResult> Handle(GetHotelQuery request, CancellationToken cancellationToken)
        {
            var Hotel = await _repository.GetHotelWithCityAsync(request.HotelId);

            return new HotelResult
            {
                HotelId = Hotel.HotelId,
                HotelName = Hotel.HotelName,
                CityId = Hotel.CityId,
                CityName = Hotel.City.CityName
            };

        }
    }
}

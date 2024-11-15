using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.CityCommands;
using Application.Features.Results.General;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.CityHandlers
{
    public class CreateCityHandler : IRequestHandler<CreateCityCommand, GeneralResponse>
    {
        private readonly IRepository<City> _repository;

        public CreateCityHandler(IRepository<City> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var city = new City
            {
                CityName = request.CityName,
                CountryId = request.CountryId
            };
            try
            {

                await _repository.CreateAsync(city);
                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{city.CityName} başarılı şekilde oluşturuldu"
                };
            }
            catch (System.Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }


    }

}
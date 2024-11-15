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
    public class DeleteCityHandler : IRequestHandler<DeleteCityCommand, GeneralResponse>
    {
        private readonly IRepository<City> _repository;

        public DeleteCityHandler(IRepository<City> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var city = await _repository.GetByIdAsync(request.CityId);
                if (city == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Şehir bulunamadı" };
                }

                await _repository.RemoveAsync(city);

                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{city.CityName} başarılı şekilde silindi"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }
}
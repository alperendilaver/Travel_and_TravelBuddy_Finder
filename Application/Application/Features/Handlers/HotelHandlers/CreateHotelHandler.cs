using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.HotelCommands;
using Application.Features.Results.General;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.HotelHandlers
{
    public class CreateHotelHandler : IRequestHandler<CreateHotelCommand, GeneralResponse>
    {
        private readonly IRepository<Hotel> _repository;

        public CreateHotelHandler(IRepository<Hotel> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            var Hotel = new Hotel
            {
                HotelName = request.HotelName,
                CityId = request.CityId
            };
            try
            {

                await _repository.CreateAsync(Hotel);
                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{Hotel.HotelName} başarılı şekilde oluşturuldu"
                };
            }
            catch (System.Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }


    }

}
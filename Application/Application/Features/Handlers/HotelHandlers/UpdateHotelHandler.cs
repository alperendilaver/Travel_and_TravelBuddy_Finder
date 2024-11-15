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
    public class UpdateHotelHandler : IRequestHandler<UpdateHotelCommand, GeneralResponse>
    {
        private readonly IRepository<Hotel> _repository;

        public UpdateHotelHandler(IRepository<Hotel> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Hotel = await _repository.GetByIdAsync(request.HotelId);
                if (Hotel == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Şehir bulunamadı" };
                }

                Hotel.HotelName = request.HotelName;

                await _repository.UpdateAsync(Hotel);

                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{Hotel.HotelName} başarılı şekilde güncellendi"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }

}
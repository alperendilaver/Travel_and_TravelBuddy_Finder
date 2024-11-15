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
    public class DeleteHotelHandler : IRequestHandler<DeleteHotelCommand, GeneralResponse>
    {
        private readonly IRepository<Hotel> _repository;

        public DeleteHotelHandler(IRepository<Hotel> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Hotel = await _repository.GetByIdAsync(request.HotelId);
                if (Hotel == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Hotel bulunamadı" };
                }

                await _repository.RemoveAsync(Hotel);

                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{Hotel.HotelName} başarılı şekilde silindi"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }
}
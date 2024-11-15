using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.TravelDestinationCommands;
using Application.Features.Commands.TravelSuggastionCommands;
using Application.Features.Results.General;
using Application.Interfaces;
using Application.Interfaces.FoodRep;
using Application.Interfaces.HotelRep;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.TravelDestinationHandlers
{
    public class UpdateTravelDestinationHandler : IRequestHandler<UpdateTravelDestinationCommand, GeneralResponse>
    {
        private readonly IRepository<TravelDestination> _repository;

        public UpdateTravelDestinationHandler(IRepository<TravelDestination> repository)
        {
            _repository = repository;

        }

        public async Task<GeneralResponse> Handle(UpdateTravelDestinationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var TravelDestination = await _repository.GetByIdAsync(request.TravelDestinationId);
                if (TravelDestination == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Rota Bulunamadı" };
                }
                TravelDestination.PopularityValue = request.PopularityValue;

                await _repository.UpdateAsync(TravelDestination);

                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = "başarılı şekilde güncellendi"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }

}
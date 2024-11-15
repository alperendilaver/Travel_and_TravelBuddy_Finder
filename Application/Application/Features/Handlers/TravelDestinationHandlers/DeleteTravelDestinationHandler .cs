using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.TravelDestinationCommands;
using Application.Features.Commands.TravelSuggastionCommands;
using Application.Features.Results.General;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.TravelDestinationHandlers
{
    public class DeleteTravelDestinationHandler : IRequestHandler<DeleteTravelDestinationCommand, GeneralResponse>
    {
        private readonly IRepository<TravelDestination> _repository;

        public DeleteTravelDestinationHandler(IRepository<TravelDestination> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(DeleteTravelDestinationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var TravelDestination = await _repository.GetByIdAsync(request.TravelDestinationId);
                if (TravelDestination == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Destination bulunamadı" };
                }

                await _repository.RemoveAsync(TravelDestination);

                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = "başarılı şekilde silindi"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }
}
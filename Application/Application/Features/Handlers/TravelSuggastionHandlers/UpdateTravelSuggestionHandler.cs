using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.TravelSuggastionCommands;
using Application.Features.Results.General;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.TravelSuggestionHandlers
{
    public class UpdateTravelSuggestionHandler : IRequestHandler<UpdateTravelSuggestionCommand, GeneralResponse>
    {
        private readonly IRepository<TravelSuggestion> _repository;

        public UpdateTravelSuggestionHandler(IRepository<TravelSuggestion> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(UpdateTravelSuggestionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var travelSuggestion = await _repository.GetByIdAsync(request.SuggestionId);
                if (travelSuggestion == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Şehir bulunamadı" };
                }

                travelSuggestion.RouteId = request.RouteId;
                await _repository.UpdateAsync(travelSuggestion);

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
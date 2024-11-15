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
    public class DeleteTravelSuggestionHandler : IRequestHandler<DeleteTravelSuggestionCommand, GeneralResponse>
    {
        private readonly IRepository<TravelSuggestion> _repository;

        public DeleteTravelSuggestionHandler(IRepository<TravelSuggestion> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(DeleteTravelSuggestionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var TravelSuggestion = await _repository.GetByIdAsync(request.SuggestionId);
                if (TravelSuggestion == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Şehir bulunamadı" };
                }

                await _repository.RemoveAsync(TravelSuggestion);

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
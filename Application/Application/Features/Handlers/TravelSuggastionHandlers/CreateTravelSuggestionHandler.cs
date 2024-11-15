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
    public class CreateTravelSuggestionHandler : IRequestHandler<CreateTravelSuggestionCommand, GeneralResponse>
    {
        private readonly IRepository<TravelSuggestion> _repository;

        public CreateTravelSuggestionHandler(IRepository<TravelSuggestion> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(CreateTravelSuggestionCommand request, CancellationToken cancellationToken)
        {
            var TravelSuggestion = new TravelSuggestion
            {
                RouteId = request.RouteId,
                UserId = request.UserId,
            };
            try
            {

                await _repository.CreateAsync(TravelSuggestion);
                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = "başarılı şekilde oluşturuldu"
                };
            }
            catch (System.Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }


    }

}
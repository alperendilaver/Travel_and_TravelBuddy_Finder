using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.TravelRouteCommands;
using Application.Features.Commands.TravelSuggastionCommands;
using Application.Features.Results.General;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.TravelRouteHandlers
{
    public class DeleteTravelRouteHandler : IRequestHandler<DeleteTravelRouteCommand, GeneralResponse>
    {
        private readonly IRepository<TravelRoute> _repository;

        public DeleteTravelRouteHandler(IRepository<TravelRoute> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(DeleteTravelRouteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var TravelRoute = await _repository.GetByIdAsync(request.RouteId);
                if (TravelRoute == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Şehir bulunamadı" };
                }

                await _repository.RemoveAsync(TravelRoute);

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
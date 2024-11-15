using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.TravelRouteCommands;
using Application.Features.Commands.TravelSuggastionCommands;
using Application.Features.Results.General;
using Application.Interfaces;
using Application.Interfaces.FoodRep;
using Application.Interfaces.HotelRep;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.TravelRouteHandlers
{
    public class UpdateTravelRouteHandler : IRequestHandler<UpdateTravelRouteCommand, GeneralResponse>
    {
        private readonly IRepository<TravelRoute> _repository;
        private readonly IFoodRepository _foodRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IDestinationRepository _destinationRepository;
        public UpdateTravelRouteHandler(IRepository<TravelRoute> repository, IFoodRepository foodRepository, IHotelRepository hotelRepository, IDestinationRepository destinationRepository)
        {
            _repository = repository;
            _foodRepository = foodRepository;
            _hotelRepository = hotelRepository;
            _destinationRepository = destinationRepository;
        }

        public async Task<GeneralResponse> Handle(UpdateTravelRouteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var TravelRoute = await _repository.GetByIdAsync(request.RouteId);
                if (TravelRoute == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Rota Bulunamadı" };
                }
                var foods = await _foodRepository.GetFoodsByIds(request.FoodIds);
                var hotels = await _hotelRepository.GetHotelsByIdAsync(request.HotelIds);
                var dests = await _destinationRepository.GetTravelDestinationsById(request.DestinationIds);
                TravelRoute.Destinations = dests;
                TravelRoute.Foods = foods;
                TravelRoute.Hotels = hotels;
                TravelRoute.RouteId = request.RouteId;
                await _repository.UpdateAsync(TravelRoute);

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
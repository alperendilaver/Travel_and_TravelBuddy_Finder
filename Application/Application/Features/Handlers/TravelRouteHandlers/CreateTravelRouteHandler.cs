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
    public class CreateTravelRouteHandler : IRequestHandler<CreateTravelRouteCommand, GeneralResponse>
    {
        private readonly IRepository<TravelRoute> _repository;
        private readonly IFoodRepository _foodRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IDestinationRepository _destinationRepository;

        public CreateTravelRouteHandler(IRepository<TravelRoute> repository, IFoodRepository foodRepository, IHotelRepository hotelRepository, IDestinationRepository destinationRepository)
        {
            _repository = repository;
            _foodRepository = foodRepository;
            _hotelRepository = hotelRepository;
            _destinationRepository = destinationRepository;
        }

        public async Task<GeneralResponse> Handle(CreateTravelRouteCommand request, CancellationToken cancellationToken)
        {
            var foods = await _foodRepository.GetFoodsByIds(request.FoodIds);
            var hotels = await _hotelRepository.GetHotelsByIdAsync(request.HotelIds);
            var dests = await _destinationRepository.GetTravelDestinationsById(request.DestinationIds);
            var TravelRoute = new TravelRoute
            {
                SuggestionId = request.SuggestionId,
                Foods = foods,
                Hotels = hotels,
                Destinations = dests,
            };
            try
            {

                await _repository.CreateAsync(TravelRoute);
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
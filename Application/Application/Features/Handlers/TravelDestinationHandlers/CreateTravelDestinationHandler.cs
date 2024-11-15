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
    public class CreateTravelDestinationHandler : IRequestHandler<CreateTravelDestinationCommand, GeneralResponse>
    {
        private readonly IRepository<TravelDestination> _repository;


        public CreateTravelDestinationHandler(IRepository<TravelDestination> repository)
        {
            _repository = repository;

        }

        public async Task<GeneralResponse> Handle(CreateTravelDestinationCommand request, CancellationToken cancellationToken)
        {

            var TravelDestination = new TravelDestination
            {
                CityId = request.CityId,
                CountryId = request.CountryId,
                PopularityValue = request.PopularityValue,

            };
            try
            {

                await _repository.CreateAsync(TravelDestination);
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
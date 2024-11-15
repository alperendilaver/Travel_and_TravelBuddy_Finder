using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.FoodCommands;
using Application.Features.Results.General;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.FoodHandlers
{
    public class CreateFoodHandler : IRequestHandler<CreateFoodCommand, GeneralResponse>
    {
        private readonly IRepository<Food> _repository;

        public CreateFoodHandler(IRepository<Food> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            var food = new Food
            {
                FoodName = request.FoodName,

            };
            try
            {

                await _repository.CreateAsync(food);
                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{food.FoodName} başarılı şekilde oluşturuldu"
                };
            }
            catch (System.Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }


    }

}
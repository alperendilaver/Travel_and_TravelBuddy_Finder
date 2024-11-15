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
    public class UpdateFoodHandler : IRequestHandler<UpdateFoodCommand, GeneralResponse>
    {
        private readonly IRepository<Food> _repository;

        public UpdateFoodHandler(IRepository<Food> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var food = await _repository.GetByIdAsync(request.FoodId);
                if (food == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Şehir bulunamadı" };
                }

                food.FoodName = request.FoodName;

                await _repository.UpdateAsync(food);

                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{food.FoodName} başarılı şekilde güncellendi"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }

}
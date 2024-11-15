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
    public class DeleteFoodHandler : IRequestHandler<DeleteFoodCommand, GeneralResponse>
    {
        private readonly IRepository<Food> _repository;

        public DeleteFoodHandler(IRepository<Food> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralResponse> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var food = await _repository.GetByIdAsync(request.FoodId);
                if (food == null)
                {
                    return new GeneralResponse { IsSucceded = false, Message = "Şehir bulunamadı" };
                }

                await _repository.RemoveAsync(food);

                return new GeneralResponse
                {
                    IsSucceded = true,
                    Message = $"{food.FoodName} başarılı şekilde silindi"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { IsSucceded = false, Message = ex.Message };
            }
        }
    }
}
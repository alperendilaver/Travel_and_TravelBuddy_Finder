using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.FoodQueries;
using Application.Features.Results.FoodResults;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.FoodHandlers
{
    public class GetFoodHandler : IRequestHandler<GetFoodQuery, FoodResult>
    {
        private readonly IRepository<Food> _repository;

        public GetFoodHandler(IRepository<Food> repository)
        {
            _repository = repository;
        }

        public async Task<FoodResult> Handle(GetFoodQuery request, CancellationToken cancellationToken)
        {
            var food = await _repository.GetByIdAsync(request.FoodId);

            return new FoodResult
            {
                FoodId = food.FoodId,
                FoodName = food.FoodName,

            };

        }
    }
}

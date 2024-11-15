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
    public class GetCitiesByCountryHandler : IRequestHandler<GetAllFoodsQuery, List<FoodResult>>
    {
        private readonly IRepository<Food> _repository;

        public GetCitiesByCountryHandler(IRepository<Food> repository)
        {
            _repository = repository;
        }
        public async Task<List<FoodResult>> Handle(GetAllFoodsQuery request, CancellationToken cancellationToken)
        {
            var cities = await _repository.GetAllAsync();
            return cities
                .Select(c => new FoodResult
                {
                    FoodId = c.FoodId,
                    FoodName = c.FoodName,
                })
                .ToList();
        }
    }
}
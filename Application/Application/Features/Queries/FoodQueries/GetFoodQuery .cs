using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.FoodResults;
using MediatR;

namespace Application.Features.Queries.FoodQueries
{
    public class GetFoodQuery : IRequest<FoodResult>
    {
        public int FoodId { get; set; }

        public GetFoodQuery(int foodId)
        {
            FoodId = foodId;
        }
    }
}
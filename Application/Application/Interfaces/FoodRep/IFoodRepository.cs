using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.FoodRep
{
    public interface IFoodRepository
    {
        public Task<List<Food>> GetFoodsByIds(List<int> ints);
    }
}
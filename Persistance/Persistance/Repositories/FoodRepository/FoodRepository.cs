using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Application.Interfaces.FoodRep;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.FoodRepository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly JourneyCloudContext _journeyCloudContext;

        public FoodRepository(JourneyCloudContext journeyCloudContext)
        {
            _journeyCloudContext = journeyCloudContext;
        }

        public async Task<List<Food>> GetFoodsByIds(List<int> ints)
        {
            return await _journeyCloudContext.Foods.Where(f => ints.Contains(f.FoodId)).ToListAsync();
        }
    }
}
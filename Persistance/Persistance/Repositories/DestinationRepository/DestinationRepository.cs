using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.DestinationRepository
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly JourneyCloudContext _journeyCloudContext;

        public DestinationRepository(JourneyCloudContext journeyCloudContext)
        {
            _journeyCloudContext = journeyCloudContext;
        }

        public async Task<List<TravelDestination>> GetTravelDestinationsById(List<int> ints)
        {
            return await _journeyCloudContext.TravelDestinations.Where(x => ints.Contains(x.TravelDestinationId)).ToListAsync();
        }
    }
}
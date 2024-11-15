using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.RouteRep;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.RouteRepository
{
    public class RouteRepository : IRouteRepository
    {
        private readonly JourneyCloudContext _journeyCloudContext;

        public RouteRepository(JourneyCloudContext journeyCloudContext)
        {
            _journeyCloudContext = journeyCloudContext;
        }

        public async Task<TravelRoute> GetTravelRoute(int id)
        {
            return await _journeyCloudContext.TravelRoutes.Include(x => x.Foods).Include(x => x.Hotels).Include(x => x.Destinations).FirstOrDefaultAsync(x => x.RouteId == id);
        }

        public async Task<List<TravelRoute>> GetTravelRoutes()
        {
            return await _journeyCloudContext.TravelRoutes.Include(x => x.Foods).Include(x => x.Hotels).Include(x => x.Destinations).ToListAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.RouteRep
{
    public interface IRouteRepository
    {
        public Task<TravelRoute> GetTravelRoute(int id);
        public Task<List<TravelRoute>> GetTravelRoutes();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.TravelRouteResults;
using MediatR;

namespace Application.Features.Queries.TravelRouteQueries
{
    public class GetTravelRouteQuery : IRequest<TravelRouteResult>
    {
        public GetTravelRouteQuery(int routeId)
        {
            this.RouteId = routeId;

        }
        public int RouteId { get; set; }

    }
}
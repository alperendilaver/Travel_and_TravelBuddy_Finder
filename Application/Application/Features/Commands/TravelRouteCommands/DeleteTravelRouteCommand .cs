using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.TravelRouteCommands
{
    public class DeleteTravelRouteCommand : IRequest<GeneralResponse>
    {
        public DeleteTravelRouteCommand(int routeId)
        {
            this.RouteId = routeId;

        }
        public int RouteId { get; set; }
    }

}
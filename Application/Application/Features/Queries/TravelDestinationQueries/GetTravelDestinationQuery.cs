using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.TravelDestinationResults;
using MediatR;

namespace Application.Features.Queries.TravelDestinationQueries
{
    public class GetTravelDestinationQuery : IRequest<TravelDestinationResult>
    {
        public GetTravelDestinationQuery(int travelDestinationId)
        {
            this.TravelDestinationId = travelDestinationId;

        }
        public int TravelDestinationId { get; set; }

    }
}
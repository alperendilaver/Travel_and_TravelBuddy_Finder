using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.TravelDestinationResults;
using MediatR;

namespace Application.Features.Queries.TravelDestinationQueries
{
    public class GetTravelDestinationsByCityQuery : IRequest<List<TravelDestinationResult>>
    {
        public int CityId { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.TravelRouteResults;
using MediatR;

namespace Application.Features.Queries.TravelRouteQueries
{
    public class GetTravelRoutesBySuggestionQuery : IRequest<List<TravelRouteResult>>
    {

    }
}
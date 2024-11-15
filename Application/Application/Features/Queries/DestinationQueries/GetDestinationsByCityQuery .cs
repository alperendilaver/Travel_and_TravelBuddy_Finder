using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.DestinationResults;
using MediatR;

namespace Application.Features.Queries.DestinationQueries
{
    public class GetDestinationsByCityQuery : IRequest<List<DestinationResult>>
    {
        public int CityId { get; set; }
    }
}
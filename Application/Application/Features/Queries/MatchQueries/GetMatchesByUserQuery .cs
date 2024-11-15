using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.MatchResults;
using MediatR;

namespace Application.Features.Queries.MatchQueries
{
    public class GetMatchesByUserQuery : IRequest<List<MatchResult>>
    {
        public string UserId { get; set; }

    }
}
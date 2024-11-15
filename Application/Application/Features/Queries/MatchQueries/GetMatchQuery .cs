using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.MatchResults;
using MediatR;

namespace Application.Features.Queries.MatchQueries
{
    public class GetMatchQuery : IRequest<MatchResult>
    {
        public GetMatchQuery(int matchId)
        {
            this.MatchId = matchId;

        }
        public int MatchId { get; set; }
    }
}
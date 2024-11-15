using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.MatchResults;
using Application.Features.Results.SuggestedUserResults;
using MediatR;

namespace Application.Features.Queries.MatchQueries
{
    public class GetLikesForUserQuery : IRequest<List<MatchedUserDTO>>
    {
        public string userId { get; set; }

        public GetLikesForUserQuery(string userId)
        {
            this.userId = userId;
        }
    }
}
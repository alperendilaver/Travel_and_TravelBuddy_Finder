using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.SuggestedUserResults;
using MediatR;

namespace Application.Features.Queries.SuggestedUserQueries
{
    public class GetSuggestedUsersQuery : IRequest<List<SuggestedUsersResult>>
    {
        public string UserId { get; set; }

        public GetSuggestedUsersQuery(string userId)
        {
            UserId = userId;
        }
    }
}
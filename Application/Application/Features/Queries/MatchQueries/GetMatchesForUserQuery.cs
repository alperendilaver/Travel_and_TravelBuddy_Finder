using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.UserResults;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.MatchQueries
{
    public class GetMatchesForUserQuery : IRequest<List<UserMatchDTO>>
    {
        public string UserId { get; set; }

        public GetMatchesForUserQuery(string userId)
        {
            UserId = userId;
        }
    }
}
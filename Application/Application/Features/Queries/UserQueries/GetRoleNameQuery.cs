using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.UserResults;
using MediatR;

namespace Application.Features.Queries.UserQueries
{
    public class GetRoleNameQuery : IRequest<GetRoleNameQueryResult>
    {
        public GetRoleNameQuery(string userId)
        {
            UserId = userId;
        }
        public string UserId { get; set; }
    }
}
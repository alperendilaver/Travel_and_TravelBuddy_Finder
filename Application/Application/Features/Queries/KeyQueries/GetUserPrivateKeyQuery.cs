using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.KeyResults;
using MediatR;

namespace Application.Features.Queries.KeyQueries
{
    public class GetUserPrivateKeyQuery : IRequest<GetPrivateKeyResponse>
    {
        public string UserId { get; set; }

        public GetUserPrivateKeyQuery(string userId)
        {
            UserId = userId;
        }
    }
}
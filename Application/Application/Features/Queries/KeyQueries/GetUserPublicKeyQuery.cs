using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.KeyResults;
using MediatR;

namespace Application.Features.Queries.KeyQueries
{
    public class GetUserPublicKeyQuery : IRequest<GetPublicKeyResponse>
    {
        public string userId { get; set; }

        public GetUserPublicKeyQuery(string userId)
        {
            this.userId = userId;
        }
    }
}
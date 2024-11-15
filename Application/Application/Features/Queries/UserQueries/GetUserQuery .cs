using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Queries.UserQueries
{
    public class GetUserQuery : IRequest<GeneralResponse>
    {
        public GetUserQuery(string userId)
        {
            this.UserId = userId;

        }
        public string UserId { get; set; }
    }
}
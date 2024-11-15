using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Queries.MessageQueries
{
    public class GetUnreadMessagesCountQuery : IRequest<int>
    {
        public string UserId { get; }

        public GetUnreadMessagesCountQuery(string userId)
        {
            UserId = userId;
        }
    }
}
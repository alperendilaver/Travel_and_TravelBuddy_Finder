using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.NotifyResults;
using MediatR;

namespace Application.Features.Queries.NotificationQueries
{
    public class GetNotificationByUserIdQuery : IRequest<List<NotificationResult>>
    {
        public string UserId { get; set; }

        public GetNotificationByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Queries.NotificationQueries
{
    public class NotifyMarkAsReadQuery : IRequest<GeneralResponse>
    {
        public int NotificationId { get; set; }

        public NotifyMarkAsReadQuery(int notificationId)
        {
            NotificationId = notificationId;
        }
    }
}
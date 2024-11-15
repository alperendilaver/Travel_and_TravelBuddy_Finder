using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.NotificationQueries;
using Application.Features.Results.General;
using Application.Interfaces.NotificationRep;
using MediatR;

namespace Application.Features.Handlers.NotificationHandlers
{
    public class NotifyMarkAsReadHandler : IRequestHandler<NotifyMarkAsReadQuery, GeneralResponse>
    {
        private readonly INotificationRepository _notificationRepository;

        public NotifyMarkAsReadHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<GeneralResponse> Handle(NotifyMarkAsReadQuery request, CancellationToken cancellationToken)
        {
            return await _notificationRepository.MarkAsRead(request.NotificationId);
        }
    }
}
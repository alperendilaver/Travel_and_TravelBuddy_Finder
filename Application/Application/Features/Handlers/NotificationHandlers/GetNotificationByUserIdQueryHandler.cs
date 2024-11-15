using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.NotificationQueries;
using Application.Features.Results.NotifyResults;
using Application.Interfaces.NotificationRep;
using MediatR;

namespace Application.Features.Handlers.NotificationHandlers
{
    public class GetNotificationByUserIdQueryHandler : IRequestHandler<GetNotificationByUserIdQuery, List<NotificationResult>>
    {
        private readonly INotificationRepository _notificationRepository;

        public GetNotificationByUserIdQueryHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<List<NotificationResult>> Handle(GetNotificationByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _notificationRepository.GetUserNotifications(request.UserId);
        }
    }
}
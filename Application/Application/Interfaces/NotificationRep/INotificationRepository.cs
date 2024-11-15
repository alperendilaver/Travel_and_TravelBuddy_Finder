using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using Application.Features.Results.NotifyResults;

namespace Application.Interfaces.NotificationRep
{
    public interface INotificationRepository
    {
        public Task<List<NotificationResult>> GetUserNotifications(string userId);

        public Task<GeneralResponse> MarkAsRead(int NotificationId);
    }
}
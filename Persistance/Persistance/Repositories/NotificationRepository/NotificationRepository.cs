using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using Application.Features.Results.NotifyResults;
using Application.Interfaces.NotificationRep;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.NotificationRepository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly JourneyCloudContext _journeyCloudContext;

        public NotificationRepository(JourneyCloudContext journeyCloudContext)
        {
            _journeyCloudContext = journeyCloudContext;
        }

        public async Task<List<NotificationResult>> GetUserNotifications(string userId)
        {
            var entities = await _journeyCloudContext.Notifications.Where(x => x.ReceiverUserId == userId).ToListAsync();
            return entities.Select(x => new NotificationResult { CreatedAt = x.CreatedAt, Id = x.Id, IsRead = x.IsRead, Message = x.Message, ReceiverUserId = x.ReceiverUserId, Subject = x.Subject }).ToList();
        }

        public async Task<GeneralResponse> MarkAsRead(int NotificationId)
        {
            var response = new GeneralResponse();
            var entity = await _journeyCloudContext.Notifications.FirstOrDefaultAsync(x => x.Id == NotificationId);
            entity.IsRead = true;

            try
            {
                _journeyCloudContext.Notifications.Update(entity);
                await _journeyCloudContext.SaveChangesAsync();
                response.IsSucceded = true;
                response.Message = "Bildirim okundu olarak işaretlendi";
            }
            catch (System.Exception ex)
            {
                response.Message += " " + ex.Message;
                response.IsSucceded = false;

            }
            return response;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.NotificationCommands
{
    public class RemoveNotificationCommand : IRequest<GeneralResponse>
    {
        public int NotificationId { get; set; }

        public RemoveNotificationCommand(int notificationId)
        {
            NotificationId = notificationId;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.NotificationCommands
{
    public class MatchNotificationCommand : IRequest<GeneralResponse>
    {
        public MatchNotificationCommand(string receiverUserEmail, string message, string subject, string receiverUserId)
        {
            ReceiverUserEmail = receiverUserEmail;
            Message = message;
            Subject = subject;
            ReceiverUserId = receiverUserId;
        }
        public string ReceiverUserId { get; set; }
        public string ReceiverUserEmail { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
    }
}
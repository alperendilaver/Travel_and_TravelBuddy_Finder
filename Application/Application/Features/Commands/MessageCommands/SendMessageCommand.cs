using System;
using MediatR;

namespace Application.Features.Commands.MessageCommands
{
    public record SendMessageCommand(string SenderUserId, string ReceiverUserId, string EncryptedMessageForReceiver, string EncryptedMessageForSender) : IRequest<int>;
}
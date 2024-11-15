using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.MessageCommands;
using Application.Interfaces.ChatRep;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.MessageHandlers
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, int>
    {
        private readonly IChatMessageRepository _repository;

        public SendMessageCommandHandler(IChatMessageRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<int> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new ChatMessage
            {
                SenderUserId = request.SenderUserId,
                ReceiverUserId = request.ReceiverUserId,
                EncryptedMessageForReceiver = request.EncryptedMessageForReceiver,
                EncryptedMessageForSender = request.EncryptedMessageForSender,
                Timestamp = DateTime.Now
            };

            await _repository.AddMessageAsync(message);
            return message.Id;
        }
    }
}
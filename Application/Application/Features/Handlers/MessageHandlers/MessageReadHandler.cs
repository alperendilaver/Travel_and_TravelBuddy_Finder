using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.MessageCommands;
using Application.Interfaces.ChatRep;
using MediatR;

namespace Application.Features.Handlers.MessageHandlers
{
    public class MessageReadHandler : IRequestHandler<MessageReadCommand, int>
    {
        private readonly IChatMessageRepository _repository;

        public MessageReadHandler(IChatMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(MessageReadCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ReadAMessage(request.messageId);
        }
    }
}
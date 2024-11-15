using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.MessageCommands;
using Application.Interfaces.ChatRep;
using MediatR;

namespace Application.Features.Handlers.MessageHandlers
{
    public class DeleteMessagesCommandHandler : IRequestHandler<DeleteMessagesCommand, bool>
    {
        private readonly IChatMessageRepository _repository;

        public DeleteMessagesCommandHandler(IChatMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteMessagesCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteMessages(request.messageids) > 0 ? true : false;
        }
    }
}
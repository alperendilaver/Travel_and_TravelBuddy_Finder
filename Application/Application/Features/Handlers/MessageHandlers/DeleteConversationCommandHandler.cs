using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.MessageCommands;
using Application.Interfaces.ChatRep;
using MediatR;

namespace Application.Features.Handlers.MessageHandlers
{
    public class DeleteConversationCommandHandler : IRequestHandler<DeleteConversationCommand, bool>
    {
        private readonly IChatMessageRepository _repository;

        public DeleteConversationCommandHandler(IChatMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteConversationCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteConversation(request.firstUserId, request.secondUserId) > 0 ? true : false;
        }
    }
}
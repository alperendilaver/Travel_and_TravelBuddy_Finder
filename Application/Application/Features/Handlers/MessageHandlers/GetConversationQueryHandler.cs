using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Features.Queries.MessageQueries;
using Application.Interfaces.ChatRep;
using MediatR;

namespace Application.Features.Handlers.MessageHandlers
{
    public class GetConversationQueryHandler : IRequestHandler<GetConversationQuery, List<ConversationDTO>>
    {
        private readonly IChatMessageRepository _repository;

        public GetConversationQueryHandler(IChatMessageRepository repository)
        {
            _repository = repository;
        }

        public Task<List<ConversationDTO>> Handle(GetConversationQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetConversations(request.UserId);
        }
    }
}
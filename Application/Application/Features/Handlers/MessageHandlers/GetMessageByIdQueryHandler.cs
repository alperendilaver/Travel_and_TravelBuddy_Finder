using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.MessageQueries;
using Application.Interfaces.ChatRep;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.MessageHandlers
{
    public class GetMessageByIdQueryHandler : IRequestHandler<GetMessageByIdQuery, ChatMessage>
    {
        private readonly IChatMessageRepository _repository;

        public GetMessageByIdQueryHandler(IChatMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<ChatMessage> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetMessage(request.MessageId);
        }
    }
}
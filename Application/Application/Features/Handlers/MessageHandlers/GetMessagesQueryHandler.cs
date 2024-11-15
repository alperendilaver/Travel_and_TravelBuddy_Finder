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
    public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, List<ChatMessage>>
    {
        private readonly IChatMessageRepository _repository;

        public GetMessagesQueryHandler(IChatMessageRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ChatMessage>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetMessagesAsync(request.SenderUserId, request.ReceiverUserId);
        }
    }
}
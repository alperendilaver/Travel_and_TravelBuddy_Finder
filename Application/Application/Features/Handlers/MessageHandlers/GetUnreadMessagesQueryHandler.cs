using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.MessageQueries;
using Application.Interfaces.ChatRep;
using MediatR;

namespace Application.Features.Handlers.MessageHandlers
{
    public class GetUnreadMessagesQueryHandler : IRequestHandler<GetUnreadMessagesCountQuery, int>
    {
        private readonly IChatMessageRepository _repository;
        public GetUnreadMessagesQueryHandler(IChatMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(GetUnreadMessagesCountQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetUnreadMessagesCount(request.UserId);
        }
    }
}
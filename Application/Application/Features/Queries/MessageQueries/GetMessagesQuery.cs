using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.MessageQueries
{
    public record GetMessagesQuery(string SenderUserId, string ReceiverUserId) : IRequest<List<ChatMessage>>;
}
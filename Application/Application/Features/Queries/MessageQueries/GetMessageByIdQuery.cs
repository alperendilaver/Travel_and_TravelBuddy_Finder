using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.MessageQueries
{
    public class GetMessageByIdQuery : IRequest<ChatMessage>
    {
        public int MessageId { get; set; }

        public GetMessageByIdQuery(int messageId)
        {
            MessageId = messageId;
        }
    }
}
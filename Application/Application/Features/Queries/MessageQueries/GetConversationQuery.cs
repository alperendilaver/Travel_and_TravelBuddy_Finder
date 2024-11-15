using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using MediatR;

namespace Application.Features.Queries.MessageQueries
{
    public class GetConversationQuery : IRequest<List<ConversationDTO>>
    {
        public string UserId { get; set; }

        public GetConversationQuery(string userId)
        {
            UserId = userId;
        }
    }
}
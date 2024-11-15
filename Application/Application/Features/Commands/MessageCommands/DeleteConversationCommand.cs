using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Commands.MessageCommands
{
    public record DeleteConversationCommand(string firstUserId, string secondUserId) : IRequest<bool>;
}
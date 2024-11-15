using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Commands.MessageCommands
{
    public record MessageReadCommand(int messageId, string receiverUserId) : IRequest<int>;

}
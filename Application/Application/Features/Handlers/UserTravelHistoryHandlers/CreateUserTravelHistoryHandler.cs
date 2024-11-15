using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.UserTravelHistoryCommands;
using Application.Features.Results.UserTravelHistoryResult;
using MediatR;

namespace Application.Features.Handlers.UserTravelHistoryHandlers
{
    public class CreateUserTravelHistoryHandler : IRequestHandler<CreateUserTravelHistoryCommand, UserTravelHistoryResult>
    {

        public Task<UserTravelHistoryResult> Handle(CreateUserTravelHistoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
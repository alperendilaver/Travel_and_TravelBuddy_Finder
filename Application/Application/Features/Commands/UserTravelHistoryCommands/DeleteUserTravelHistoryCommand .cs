using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.UserTravelHistoryCommands
{
    public class DeleteUserTravelHistoryCommand : IRequest<GeneralResponse>
    {
        public int LogId { get; set; }
    }
}
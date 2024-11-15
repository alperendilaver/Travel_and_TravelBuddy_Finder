using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.UserCommands
{
    public class DeleteUserCommand : IRequest<GeneralResponse>
    {
        public DeleteUserCommand(string userId)
        {
            this.UserId = userId;

        }
        public string UserId { get; set; }


    }
}
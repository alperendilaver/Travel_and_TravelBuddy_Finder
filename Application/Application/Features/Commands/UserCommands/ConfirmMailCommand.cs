using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.UserCommands
{
    public class ConfirmMailCommand : IRequest<GeneralResponse>
    {
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
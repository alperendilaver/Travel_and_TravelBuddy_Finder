using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.UserCommands
{
    public class ResetPasswordRequestCommand : IRequest<GeneralResponse>
    {
        public string Email { get; set; }
    }
}
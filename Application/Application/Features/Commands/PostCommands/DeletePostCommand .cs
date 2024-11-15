using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.PostCommands
{
    public class DeletePostCommand : IRequest<GeneralResponse>
    {
        public DeletePostCommand(int postId)
        {
            this.PostId = postId;

        }
        public int PostId { get; set; }
    }
}
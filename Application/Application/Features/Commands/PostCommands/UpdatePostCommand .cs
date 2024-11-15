using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.PostCommands
{
    public class UpdatePostCommand : IRequest<GeneralResponse>
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
    }
}
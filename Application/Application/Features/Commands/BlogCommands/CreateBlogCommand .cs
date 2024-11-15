using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.BlogCommands
{
    public class CreateBlogCommand : IRequest<GeneralResponse>
    {
        public string BlogName { get; set; }
        public string Context { get; set; }

    }
}
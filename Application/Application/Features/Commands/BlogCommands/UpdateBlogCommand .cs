using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.BlogCommands
{
    public class UpdateBlogCommand : IRequest<GeneralResponse>
    {
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public string Context { get; set; }
    }
}
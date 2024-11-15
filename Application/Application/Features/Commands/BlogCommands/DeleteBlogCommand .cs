using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.BlogCommands
{
    public class DeleteBlogCommand : IRequest<GeneralResponse>
    {
        public DeleteBlogCommand(int blogId)
        {
            this.BlogId = blogId;

        }
        public int BlogId { get; set; }
    }
}
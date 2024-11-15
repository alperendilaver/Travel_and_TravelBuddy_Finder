using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using Application.Features.Results.PostResults;
using MediatR;

namespace Application.Features.Commands.PostCommands
{
    public class CreatePostCommand : IRequest<ResponseCreatePost>
    {
        public string Context { get; set; }
        public string UserId { get; set; }
        public int BlogId { get; set; }
        public DateTime postedTime = DateTime.Now;
    }
}
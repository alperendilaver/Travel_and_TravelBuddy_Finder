using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.PostResults;
using MediatR;

namespace Application.Features.Queries.PostQueries
{
    public class GetPostQuery : IRequest<PostResult>
    {
        public GetPostQuery(int postId)
        {
            this.PostId = postId;

        }
        public int PostId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.PostResults;
using MediatR;

namespace Application.Features.Queries.PostQueries
{
    public class GetPostsByBlogQuery : IRequest<List<PostResult>>
    {
        public int BlogId { get; set; }

    }
}
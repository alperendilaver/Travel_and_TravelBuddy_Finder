using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.PostQueries;
using Application.Features.Results.PostResults;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.PostHandlers
{
    public class GetPostsHandler : IRequestHandler<GetPostsByBlogQuery, List<PostResult>>
    {
        private readonly IRepository<Post> _repository;

        public GetPostsHandler(IRepository<Post> repository)
        {
            _repository = repository;
        }
        public async Task<List<PostResult>> Handle(GetPostsByBlogQuery request, CancellationToken cancellationToken)
        {
            var Posts = await _repository.GetAllAsync();
            return Posts
                .Select(c => new PostResult
                {
                    PostId = c.PostId,
                    BlogId = c.BlogId,
                    Context = c.Context,

                    UserId = c.UserId,
                    PostedTime = c.PostedTime
                })
                .ToList();
        }
    }
}
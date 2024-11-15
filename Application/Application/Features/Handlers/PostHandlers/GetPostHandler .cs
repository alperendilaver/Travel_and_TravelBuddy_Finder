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
    public class GetPostHandler : IRequestHandler<GetPostQuery, PostResult>
    {
        private readonly IRepository<Post> _repository;

        public GetPostHandler(IRepository<Post> repository)
        {
            _repository = repository;
        }

        public async Task<PostResult> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            var Post = await _repository.GetByIdAsync(request.PostId);

            return new PostResult
            {
                PostId = Post.PostId,
                BlogId = Post.BlogId,
                Context = Post.Context,
                UserId = Post.UserId,
                PostedTime = Post.PostedTime
            };

        }
    }
}

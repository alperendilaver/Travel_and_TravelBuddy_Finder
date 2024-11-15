using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.PostCommands;
using Application.Features.Results.General;
using Application.Features.Results.PostResults;
using Application.Interfaces.IGeneralRepository;
using Application.Interfaces.PostRep;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.PostHandlers
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, ResponseCreatePost>
    {
        private readonly IPostRepository _repository;

        public CreatePostHandler(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseCreatePost> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _repository.CreatePost(new Post
            {
                BlogId = request.BlogId,
                Context = request.Context,
                UserId = request.UserId,
                PostedTime = request.postedTime,
            });
            return post;
        }


    }

}
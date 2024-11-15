using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.BlogQueries;
using Application.Features.Results.BlogResults;
using Application.Features.Results.PostResults;
using Application.Features.Results.UserResults;
using Application.Interfaces.BlogRep;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.BlogHandlers
{
    public class GetBlogHandler : IRequestHandler<GetBlogQuery, BlogDTO>
    {
        private readonly IBlogRepository _repository;

        public GetBlogHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<BlogDTO> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetBlogWithPostsAsync(request.BlogId);
            //postların tarihleri gelmiyor onları düzenle
            return blog;
        }
    }
}
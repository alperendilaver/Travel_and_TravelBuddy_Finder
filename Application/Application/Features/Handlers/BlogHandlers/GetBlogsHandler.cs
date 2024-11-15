using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.BlogQueries;
using Application.Features.Results.BlogResults;
using Application.Interfaces.IGeneralRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.BlogHandlers
{
    public class GetBlogByCountryHandler : IRequestHandler<GetAllBlogsQuery, List<BlogResult>>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByCountryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }
        public async Task<List<BlogResult>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetAllAsync();
            return blog
                .Select(c => new BlogResult
                {
                    BlogId = c.BlogId,
                    BlogName = c.BlogName,
                    Context = c.Context
                })
                .ToList();
        }
    }
}
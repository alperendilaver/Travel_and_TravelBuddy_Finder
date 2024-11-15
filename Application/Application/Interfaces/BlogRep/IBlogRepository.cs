using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.BlogResults;
using Domain.Entities;

namespace Application.Interfaces.BlogRep
{
    public interface IBlogRepository
    {
        public Task<BlogDTO> GetBlogWithPostsAsync(int id);
    }
}
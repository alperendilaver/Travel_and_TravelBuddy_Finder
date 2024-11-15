using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.PostResults;
using Domain.Entities;

namespace Application.Interfaces.PostRep
{
    public interface IPostRepository
    {
        public Task<ResponseCreatePost> CreatePost(Post post);
    }
}
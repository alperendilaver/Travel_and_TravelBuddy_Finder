using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.PostResults;
using Application.Interfaces.PostRep;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.PostRepository
{
    public class PostRepository : IPostRepository
    {
        private readonly JourneyCloudContext _context;

        public PostRepository(JourneyCloudContext context)
        {
            _context = context;
        }

        public async Task<ResponseCreatePost> CreatePost(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            var addedpost = await _context.Posts.Include(x => x.User).FirstOrDefaultAsync(x => x.PostId == post.PostId);
            return new ResponseCreatePost
            {
                BlogId = addedpost.BlogId,
                Context = addedpost.Context,
                PostId = addedpost.PostId,
                postedTime = addedpost.PostedTime.ToString("HH:mm dd/MM/yyyy"),
                User = addedpost.User
            };
        }
    }
}
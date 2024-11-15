using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.BlogResults;
using Application.Features.Results.PostResults;
using Application.Features.Results.UserResults;
using Application.Interfaces.BlogRep;
using Domain.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.BlogRepository
{
    public class BlogRepository : IBlogRepository
    {
        private JourneyCloudContext _journeyCloudContext;

        public BlogRepository(JourneyCloudContext journeyCloudContext)
        {
            _journeyCloudContext = journeyCloudContext;
        }

        public async Task<BlogDTO> GetBlogWithPostsAsync(int id)
        {
            return await _journeyCloudContext.Blogs
        .Where(b => b.BlogId == id)
        .Select(b => new BlogDTO
        {
            BlogId = b.BlogId,
            BlogName = b.BlogName,
            Context = b.Context,
            Posts = b.Posts.Select(p => new PostDTO
            {
                PostId = p.PostId,
                postedTime = p.PostedTime.ToString("HH:mm  dd/MM/yyyy"),
                Context = p.Context,
                UserId = p.UserId,
                User = new UserDTO
                {
                    UserId = p.User.Id, //burası kullanıcın idsini çeker 
                    UserName = p.User.UserName // Sadece UserName çekilir
                }
            }).ToList()
        })
        .FirstOrDefaultAsync();
        }
    }
}
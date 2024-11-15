using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Features.Results.PostResults
{
    public class ResponseCreatePost
    {
        public int PostId { get; set; }
        public AppUser User { get; set; }
        public string Context { get; set; }
        public int BlogId { get; set; }
        public string postedTime { get; set; }

    }
}
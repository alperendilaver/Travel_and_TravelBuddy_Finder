using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Features.Results.BlogResults
{
    public class BlogResult
    {
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public string Context { get; set; }
        public List<Post> Posts { get; set; }
    }
}